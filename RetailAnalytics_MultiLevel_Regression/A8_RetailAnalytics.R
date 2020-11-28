
# Activate libraries
library(data.table)
library(lme4) 
library(rio)
library(stargazer)
library(Hmisc)
library(corrplot)
library(car)
library(lattice)
library(PerformanceAnalytics)
library(MASS)
library(AICcmodavg)
library(readxl)
library(lattice)
library(base)
library(tidyverse)
library(AER)
library(DHARMa)
# Read data 
stores = read_xlsx('RetailChain.xlsx', sheet='stores' )
products= read_xlsx('RetailChain.xlsx', sheet= 'products')
transactions= read_xlsx('RetailChain.xlsx', sheet= 'transactions')



#Merge transactions and producs using keys to join
store_tran= merge(transactions, stores, by.x = "STORE_NUM", by.y = "STORE_ID")

#Merge stores into the df with products and transactions
df=merge(store_tran, products, by.x = "UPC", by.y = "UPC")

#lowercase all column names
colnames(df)= tolower(colnames(df))

#Convert columns to right data types
df$segment= as.factor(df$segment)
df$state= as.factor(df$state)
df$city= as.factor(df$city)
df$store_name= as.factor(df$store_name)
#product size needs to be converted into same units for liquids/solids
df$sub_category= as.factor(df$sub_category)
df$category= as.factor(df$category)
df$manufacturer= as.factor(df$manufacturer)
df$description= as.factor(df$description)
df$upc= as.factor(df$upc)
df$store_num= as.factor(df$store_num)

#Drop all oral hygiene products
df = df[which(df$category!= 'ORAL HYGIENE PRODUCTS'),]
# Look into NA values
colSums(is.na(df))

#Drop parking variable due to missing data
df$parking=NULL

# 10 rows with missing prices and 173 missing base price, eliminate
df= df[which(!is.na(df$price)),]
df= df[which(!is.na(df$base_price)),]

#Check Na values again
colSums(is.na(df))


# Do we have any rows with sales= 0(might cause issues with log model)

no_spend=df[(df$price<=0),]

# Get rid of any row with price=0
df= df[which(df$price>0),]

# Feature engineering
#Price difference to explore elasticity
df$price_diff= df$base_price-df$price

head(df)

# Order df by week
df=arrange(df,week_end_date)

# Week as a sequence starting at 1
df$week_num= as.factor(df$week_end_date)
describe(df$week_num)#156 distinct weeks
levels(df$week_num)= seq(1,156)

# Make a month and year column
df$month= format(df$week_end_date,format="%m")
df$year= format(df$week_end_date,format="%Y")
df$month_int= as.numeric(df$month)
df$year_int= as.numeric(df$year)

#Factorize them
df$month= as.factor(df$month)
df$year = as.factor(df$year)

# Make them int to capture week over week variation
df$week_num= as.numeric(df$week_num)

#Correlations for numeric data
quant_cols= c('units','visits','hhs','spend','price','base_price','feature','display','tpr_only','msa','size','avg_weekly_baskets','month_int','year_int')
quant_data= df[quant_cols]
#Compute correlations
correlations= cor(quant_data)
chart.Correlation()
corrplot(correlations, method = 'circle')


#by product segment/ product category
bwplot(~units| category*segment, data= df, xlim = c(0,500))

bwplot(~spend| category*segment, data = df, xlim = c(0,500))

# by product/ by store

bwplot(~units| upc, data= df, xlim = c(0,500))
bwplot(~units| store_num, data= df)
bwplot(~spend| upc, data= df, xlim = c(0,500))
bwplot(~spend| store_num, data = df, xlim = c(0,500))



# Visualisations
#spend Distribution
histogram(~spend, data= df, main='Spend')
histogram(~log(spend), data=df, main= 'Log(Spend)')

#unit sales dist-
histogram(~units, data= df)
histogram(~log(units), data=df, main= 'Log(units)')

#households
histogram(~hhs, data= df)
histogram(~log(hhs), data=df, main= 'Log(Household Purchases)')

#Build simple models to answer question 1
m_spend = lmer(log(spend)~tpr_only+log(price)+month+year+feature+display+category+feature+price_diff
                +(1|upc)+(1|store_num), REML = FALSE, data=df)


m_units = lmer(log(units)~tpr_only+log(price)+month+year+feature+display+category+feature+price_diff
                +(1|upc)+(1|store_num), REML = FALSE, data=df)

m_hhs = lmer(log(hhs)~tpr_only+log(price)+month+year+feature+display+category+feature+price_diff
              +(1|upc)+(1|store_num), REML = FALSE, data=df)
# Combined output
stargazer(m_spend, m_units, m_hhs, single.row= TRUE, type= 'text')


# Interaction model to explore elasticity questions 3 and 4
m3_sales=lm( log(spend) ~ tpr_only + log(price) * upc + feature + 
               display + category + year + month + price_diff + segment + 
               size + store_num, data = df)
#Explore elasticity
summary(m3_sales)

#Build interaction models to answer question 2
m2_spend = lmer(log(spend)~tpr_only*category+log(price)+month+year+feature*category+display*category+feature*segment+display*segment+tpr_only*segment+price_diff
               +(1|upc)+(1|store_num), REML = FALSE, data=df)

m2_units = lmer(log(units)~tpr_only*category+month+year+log(price)+feature*category+display*category+feature*segment+display*segment+tpr_only*segment+price_diff
               +(1|upc)+(1|store_num), REML = FALSE, data=df)

m2_hhs = lmer(log(hhs)~tpr_only*category+log(price)+feature*category+month+year+display*category+feature*segment+display*segment+tpr_only*segment+price_diff
             +(1|upc)+(1|store_num), REML = FALSE, data=df)

#Combined output

stargazer(m2_spend, m2_units, m2_hhs, single.row= TRUE, type= 'text')


# Assumptions

#Multicollinearity
vif(m_spend)
vif(m_units)
vif(m_hhs)

# Use DHARMa that specializes in multi level residual analysis
#Simulate results of model residuals and plot qq with KS
simulation_sales_output =simulateResiduals(fittedModel = m_spend, plot = T)
simulation_units_output = simulateResiduals(fittedModel = m_units, plot = T)
simulation_hhs_output = simulateResiduals(fittedModel = m_hhs, plot = T)



