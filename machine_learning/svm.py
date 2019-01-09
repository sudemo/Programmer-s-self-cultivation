# -*- coding: UTF-8 -*-
''''
author:neo
Created on: 2019/1/8 16:52
Software: PyCharm Community Edition
'''
import numpy as np
import matplotlib.pyplot as plt
import pandas as pd

dataset = pd.read_csv('Social_Network_Ads.csv')
X = dataset.iloc[:,[2,3]].values
y =dataset.iloc[:,4].values
from sklearn.model_selection import train_test_split
X_train,X_test,y_train,y_test = train_test_split(X,y,test_size= 0.25,random_state=0)
print('training ,wait')
from sklearn.svm import SVC
classifier = SVC(kernel='linear',random_state = 0)
classifier.fit(X_train,y_train)
y_pred = classifier.predict(X_test)
#创建混淆矩阵
from sklearn.metrics import confusion_matrix
cm =confusion_matrix(y_test,y_pred)
#训练集合 结果可视化
print('drawing')
from matplotlib.colors import ListedColormap
X_set,y_set = X_train, y_train
X1, X2 = np.meshgrid(np.arange(start = X_set[:,0].min()-1,
                               stop =X_set[:,0].max()+1,step = 0.01),
                     np.arange(start = X_set[:,1].min()-1,
                               stop = X_set[:,1].max()+1,step = 0.01))
plt.contourf(X1,X2,classifier.predict(np.array([X.ravel(),X2.ravel()]).T).reshape(X1.shape),
             alphha = 0.75, cmap = ListedColormap(('red','green')) )
plt.xlim(X1.min(),X1.max())
plt.ylim(X2.min(),X2.max())
for i,j in enumerate (np.unique(y_set)):
    plt.scatter(X_set[y_set == j,0],X_set[y_set == j,1],
                c = ListedColormap(('red','green'))(i),label = j)
plt.title('SVM (training set)')
plt.xlabel('age')
plt.ylabel('estimate salary')
plt.legend()
plt.show()