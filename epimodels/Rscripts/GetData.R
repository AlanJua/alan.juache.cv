library(dplyr)
library(ggplot2)
library(lubridate)

data <- read.csv('/Users/ajuache/Downloads/COVID-19 - Johns Hopkins University.csv')
data <- data[which(data$Country == "Mexico"),]

dataweekly <- read.csv('/Users/ajuache/Downloads/weekly_cases.csv')
plot(data$Weekly.cases)
colnames(data)

# POPULATION Mexico	Mexico	North America	2022	127504120
dataweekly <- dataweekly %>% mutate(datef = as.Date(date))
dataweekly_2 <- dataweekly %>% select(c(datef, Mexico))

plot(dataweekly_2$datef, dataweekly_2$Mexico)


dataweekly_3 <- dataweekly_2[which(dataweekly_2$datef > as.Date("2021-12-31") & dataweekly_2$datef < as.Date("2023-01-01")),]
plot(dataweekly_3$datef, dataweekly_3$Mexico)


dataweekly_3$newCases <- dataweekly_3$Mexico - lag(dataweekly_3$Mexico, default = first(dataweekly_3$Mexico))
dataweekly_3$newCases14 <- dataweekly_3$Mexico - lag(dataweekly_3$Mexico, n = 14, default = first(dataweekly_3$Mexico))
dataweekly_4 <-dataweekly_3[which(dataweekly_3$datef > as.Date("2021-12-31") & dataweekly_3$datef < as.Date("2022-04-01")),]
dataweekly_4$newCases14 <- dataweekly_4$Mexico - lag(dataweekly_4$Mexico, n = 14, default = first(dataweekly_4$Mexico))

ggplot() + 
  geom_line(data = dataweekly_3, aes(x=datef, y=Mexico)) + scale_x_date(date_breaks = "month") +
  geom_line(data = dataweekly_3, aes(x=datef, y=newCases), color="blue") + scale_x_date(date_breaks = "month") +
  geom_line(data = dataweekly_3, aes(x=datef, y=newCases14), color="red") + scale_x_date(date_breaks = "month") +
  geom_line(data = dataweekly_4, aes(x=datef, y=newCases14), color="green") + scale_x_date(date_breaks = "month") +
  theme_classic() + theme(axis.text.x = element_text(angle = 90, hjust = 1))




# data_incidence <- 
#   dataweekly_3 %>% 
#   mutate(
#     week = floor_date(datef, "week")
#   ) %>%
#   group_by(week) %>%
#   summarise(weekInc = mean(Mexico)) %>% 
#   ungroup()
#   
# 
# ggplot() + 
#   geom_line(data = data_incidence, aes(x=week, y=weekInc)) + scale_x_date(date_breaks = "month") +
#   theme_classic() + theme(axis.text.x = element_text(angle = 90, hjust = 1))
# 
