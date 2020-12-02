# Description

In this folder are two small web scraping scripts that were used as part of an ETL process for different projects.

## Project 1- IMDb Data

This script scraped movie related data directly from the IMDb website. This data was used to complement a dataset obtained through the IMDbPy package for a movie database project. 
Due to the static nature of the website, the BeautifulSoup Python library was used to parse through the HTML content and extract the desired information.

## Project 2 - Wunderground Weather Data 

This script extracted weather related data form the Wunderground website. This wesbite relies on JavaScript to display its dynamic content. 
The Selenium Python library was used to simulate user interaction and extract the data. The website's URL, which includes the date for the weather data, was leveraged to automate data extraction for a year(365 webpages).
The data was used in the Taxi Analysis Project to explore weather impact on tipping behavior in NYC.
