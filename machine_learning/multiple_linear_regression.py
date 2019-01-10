# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2019/1/10 11:23
Software: PyCharm Community Edition
'''
# Importing the libraries
import pandas as pd
import numpy as np
from  pandas import DataFrame
# Importing the dataset
dataset = pd.read_csv('50_Startups.csv')
print(type(dataset))
X = dataset.iloc[ : , :-1].values
Y = dataset.iloc[ : ,  4 ].values
dataset1 = DataFrame(dataset)
print(type(dataset))
# print(dataset1.head())
print(dataset1.iloc[0:2])
# Encoding Categorical data 将类别数据数字化
from sklearn.preprocessing import LabelEncoder, OneHotEncoder
labelencoder = LabelEncoder()
X[: , 3] = labelencoder.fit_transform(X[ : , 3])
onehotencoder = OneHotEncoder(categorical_features = [3])
X = onehotencoder.fit_transform(X).toarray()

# Avoiding Dummy Variable Trap 避免伪数据陷阱
X = X[: , 1:]
# print('x:',X ,'\n','y:',Y)
# Splitting the dataset into the Training set and Test set
from sklearn.model_selection import train_test_split
X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size = 0.2, random_state = 0)

# Fitting Multiple Linear Regression to the Training set
from sklearn.linear_model import LinearRegression
regressor = LinearRegression()
regressor.fit(X_train, Y_train)

# Predicting the Test set results
y_pred = regressor.predict(X_test)
# print(y_pred)
# regression evaluation
from sklearn.metrics import r2_score
print('socre: ',r2_score(Y_test,y_pred))

#结果可视化

import matplotlib.pyplot as plt
# X = X[:,0]
# print('x:',X)
# plt.scatter(X,Y,marker = 'o')
# plt.show()
plt.scatter(dataset1.Profit ,dataset1.Administration,color = 'green', label = 'profit' )
plt.xlabel('x')
plt.ylabel('y')
plt.show()