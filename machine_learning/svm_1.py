# -*- coding: UTF-8 -*-
''''
author: neo
Created on: 2019/1/9 10:00
Software: PyCharm Community Edition
'''
from sklearn.datasets import load_iris
from sklearn.svm import SVC
from sklearn.linear_model import LogisticRegression
import numpy as np
import matplotlib.pyplot as plt

iris = load_iris()
X = iris.data[:, [2, 3]]
y = iris.target

"""
kernel='linear'时，为线性核，C越大分类效果越好，但有可能会过拟合（defaul C=1）。

kernel='rbf'时（default），为高斯核，gamma值越小，分类界面越连续；gamma值越大，分类界面越“散”，
分类效果越好，但有可能会过拟合。

decision_function_shape='ovr'时，为one v rest，即一个类别与其他类别进行划分，

decision_function_shape='ovo'时，为one v one，即将类别两两之间进行划分，用二分类的方法模拟多分类的结果。
"""
clf1 = SVC(kernel='poly',gamma='auto', decision_function_shape='ovr')
clf1.fit(X, y)

clf2 = LogisticRegression()
clf2.fit(X, y)


def plot_estimator(estimator, X, y):
    x_min, x_max = X[:, 0].min() - 1, X[:, 0].max() + 1
    y_min, y_max = X[:, 1].min() - 1, X[:, 1].max() + 1
    xx, yy = np.meshgrid(np.arange(x_min, x_max, 0.1),
                         np.arange(y_min, y_max, 0.1))
    Z = estimator.predict(np.c_[xx.ravel(), yy.ravel()])
    Z = Z.reshape(xx.shape)
    plt.plot()
    plt.contourf(xx, yy, Z, alpha=0.4, cmap ='RdYlBu')
    plt.scatter(X[:, 0], X[:, 1], c=y, cmap= 'brg')
    plt.xlabel('Petal.Length')
    plt.ylabel('Petal.Width')
    plt.show()


plot_estimator(clf1, X, y)
