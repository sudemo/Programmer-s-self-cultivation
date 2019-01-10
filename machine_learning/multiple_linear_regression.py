# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2019/1/10 11:23
Software: PyCharm Community Edition
'''
# Importing the libraries
import pandas as pd
import numpy as np

# Importing the dataset
dataset = pd.read_csv('50_Startups.csv')
X = dataset.iloc[ : , :-1].values
Y = dataset.iloc[ : ,  4 ].values

# Encoding Categorical data
from sklearn.preprocessing import LabelEncoder, OneHotEncoder
labelencoder = LabelEncoder()
X[: , 3] = labelencoder.fit_transform(X[ : , 3])
onehotencoder = OneHotEncoder(categorical_features = [3])
X = onehotencoder.fit_transform(X).toarray()

# Avoiding Dummy Variable Trap
X = X[: , 1:]
print('x:',X ,'\n','y:',Y)
# Splitting the dataset into the Training set and Test set
from sklearn.model_selection import train_test_split
X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size = 0.2, random_state = 0)

# Fitting Multiple Linear Regression to the Training set
from sklearn.linear_model import LinearRegression
regressor = LinearRegression()
regressor.fit(X_train, Y_train)

# Predicting the Test set results
y_pred = regressor.predict(X_test)
print(y_pred)
# regression evaluation
from sklearn.metrics import r2_score
print('socre: ',r2_score(Y_test,y_pred))

#结果可视化

import matplotlib.pyplot as plt

# plt.scatter(X,Y,c = y_pred,marker = 'o')