'''
@author: neo
@file: cnndemo4.py
@time: 2019/3/25 15:35
'''
import argparse
import torch
import torch.nn as nn
import torch.nn.functional as F
import torch.optim as optim
from torch.autograd import Variable
import torchvision
from torchvision import datasets, transforms
from PIL import Image
from cnndemo3 import  CNNnet
import cv2
from visdom import *
import visdom
import numpy as np
from matplotlib import pyplot as plt

path = 'd:/debug/python/pytorchdemo'
try:
    mymodel = torch.load("mycnn2")
except Exception as ex :
    print(ex)
mymodel.eval()
test_data = torchvision.datasets.ImageFolder('D:/debug/python/pytorchdemo/pic/val',
                                            transform=transforms.Compose([
                                                # transforms.Resize((768,512)),
                                                transforms.CenterCrop(512),
                                                transforms.ToTensor()])
                                            )
test_loader = torch.utils.data.DataLoader(test_data,batch_size=2, shuffle=True)



loss_func = nn.CrossEntropyLoss()
optimizer = optim.SGD(mymodel.parameters(), lr=0.02)  # 设置学习方法

def test_fun():

    eval_loss = 0
    eval_acc = 0
    correct = 0
    # for eopch in range(EPOCH):
    for data in (test_loader):

        b_x, b_y = data
        b_x, b_y = Variable(b_x), Variable(b_y)  # b_x 是 img b_y是标签
        out_put = mymodel(b_x)

        loss = loss_func(out_put, b_y)
        eval_loss += loss.data.item() * b_y.size(0)

        predict_y = torch.argmax(out_put, 1).data.numpy()
        _, pred = torch.max(out_put, 1)
        correct += pred.eq(b_y.view_as(pred)).sum().item()
        # print(correct, len(test_loader.dataset))
        print(predict_y, b_y)
        # vz = Visdom()
        # assert vz.check_connection()
        # vz.images(b_x, opts=dict(title='images', caption='How'))
        # print(type(b_x.numpy()))
        # cv2.imshow("x",b_x)
        # plt.imshow("x", b_x.numpy())
        # plt.show()
        # print("predict:", predict_y, "actuall",b_y)
    print("acc:", correct/len(test_loader.dataset))
    # print(b_x)


    # print("pred",pred,b_y)
    # print("single",pred/b_y)
    # num_correct = (pred == b_y).sum()
    # print('Accuracy in Test : ', (num_correct * 100 ,len(predict_y)))
    # print("acc: ", num_correct/b_y)
    # eval_acc += num_correct.item()
    # print(eval_acc)
    # print('Test Loss: {:.4f}, acc:{}/{} ({:.0f}%)'.format(
    # eval_loss / (len(test_data)),
    # eval_acc ,(len(test_data)), 100. * eval_acc / len(test_data)
    # ))
test_fun()