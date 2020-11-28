rm(list=ls())

library(survival)
library(ggplot2)

library(survminer)
#Read the data file
fullData= read.table('LungCancer.txt')
#Make a list of variables in order of columns
variable_list= list('treatment', 'cell_type','survival_days','status','karnofsky','diagnosis_months','age','prior_chemo')
#MAke variable names actual variables
colnames(fullData)=c(variable_list)

summary(fullData)
#Check survival days distribution
table(status)

#Check correlations

library(PerformanceAnalytics)
PerformanceAnalytics::chart.Correlation(fullData)
library(lattice)
#Survival days distribution and summary stats
histogram(fullData$survival_days, main='Survival Days Distribution')
summary(fullData$survival_days)

table(cell_type)
#Fix prior chemo dummy to 0 and 1 instead of 10 and 1
fullData$prior_chemo= ifelse(fullData$prior_chemo==10,1,0)

#Fix cell_type
fullData$cell_type= as.factor(fullData$cell_type)


str(fullData)
d= fullData
attach(d)
km1 <- survfit(Surv(survival_days, status) ~ 1)      
summary(km1)
ggsurvplot(km1, data= d)

# Kaplan-Meier non-parametric analysis by group
km2 <- survfit(Surv(survival_days, status) ~ treatment) 
summary(km2)

ggsurvplot(km2, data= d, legend.labs=c('Standard Treatment','Test Treatment'))
#Choose km2 as best model because graph suggests the treatment has an effect on surival time

# semi parametric: Cox proportional hazard models

cox <- coxph(Surv(survival_days, status) ~age+diagnosis_months+treatment+karnofsky+cell_type, method="breslow", data=d)
summary(cox)

# Parametric: Exponential, Weibull
exp <- survreg(Surv(survival_days, status)  ~age+diagnosis_months+treatment+karnofsky+cell_type, dist="exponential", data=d)
summary(exp)



wb <- survreg(Surv(survival_days, status)  ~age+diagnosis_months+treatment+karnofsky+cell_type, dist="weibull", data=d)
summary(wb)


library(stargazer)
stargazer(cox, exp, wb, type="text")

#coefficients of coxph for better interpretation
exp(coef(cox))-1
# This shows percent change in hazard probability for increase in variable
#or on average compared to base level for categorical
