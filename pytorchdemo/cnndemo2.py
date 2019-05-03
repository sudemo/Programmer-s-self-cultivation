'''
@author: neo
@file: cnndemo2.py
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
import cnndemo1
# import visdom

path = 'd:/debug/python/pytorchdemo/'
mymodel = torch.load('mycnn1')
mymodel.eval()
test_data = torchvision.datasets.ImageFolder('D:/debug/python/pytorchdemo/pic/val',
                                            transform=transforms.Compose([
                                                transforms.Scale(512),
                                                # transforms.CenterCrop(256),
                                                transforms.ToTensor()])
                                            )
test_loader = torch.utils.data.DataLoader(test_data,batch_size=2, shuffle=True)



loss_func = nn.CrossEntropyLoss()
optimizer = optim.SGD(mymodel.parameters(), lr=0.02)  # 设置学习方法

def test_fun():

    eval_loss = 0
    eval_acc = 0
    # for eopch in range(EPOCH):
    for data in (test_loader):
        b_x, b_y = data
        b_x, b_y = Variable(b_x), Variable(b_y)  # b_x 是 img b_y是标签
        out_put = mymodel(b_x)
        loss = loss_func(out_put, b_y)
        eval_loss += loss.data.item() * b_y.size(0)
        _, pred = torch.max(out_put, 1)
        # print("pred",pred,b_y)
        num_correct = (pred == b_y).sum()
        eval_acc += num_correct.item()
        # print(eval_acc)
        print('Test Loss: {:.4f}, acc:{}/{} ({:.0f}%)'.format(
        eval_loss / (len(test_data)),
        eval_acc ,(len(test_data)), 100. * eval_acc / len(test_data)
        ))
test_fun()