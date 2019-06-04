#coding=utf-8
'''
@author: neo
@file: cnndemo1.py
@time: 2019/5/4 10:41
'''
import torch
import torch.nn as nn
import torch.nn.functional as F
import torchvision
import torch.optim as optim
from torchvision import datasets, models, transforms
from torch.autograd import Variable

class CNNnet(torch.nn.Module):
    def __init__(self):
        super(CNNnet, self).__init__()
        self.conv1 = torch.nn.Sequential(
            torch.nn.Conv2d(in_channels=3,
                            out_channels=2,
                            kernel_size=5,
                            stride=2,
                            padding=1),
            torch.nn.BatchNorm2d(2),
            torch.nn.ReLU()
        )
        self.conv2 = torch.nn.Sequential(
            torch.nn.Conv2d(2, 2, 3, 2, 1),
            torch.nn.BatchNorm2d(2),
            torch.nn.ReLU()
        )
        self.conv3 = torch.nn.Sequential(
            torch.nn.Conv2d(2, 2, 3, 2, 1),
            torch.nn.BatchNorm2d(2),
            torch.nn.ReLU()
        )
        self.conv4 = torch.nn.Sequential(
            torch.nn.Conv2d(2, 2, 2, 2, 0),  # 2*32*48
            torch.nn.BatchNorm2d(2),
            torch.nn.ReLU()
        )
        self.mlp1 = torch.nn.Linear(2*2*2*16*24, 2000)
        self.mlp2 = torch.nn.Linear(2000, 2)

    def forward(self, x):
        x = self.conv1(x)
        x = self.conv2(x)
        x = self.conv3(x)

        x = self.conv4(x)
        # print(x.shape)
        # t = x.size(0)
        x = self.mlp1(x.view(x.size(0), -1))
        x = self.mlp2(x)
        return x
        x = self.mlp2(x)
        return x


train_data = torchvision.datasets.ImageFolder('D:/debug/python/pytorchdemo/pic/train',
                                            transform=transforms.Compose([
                                                transforms.Scale(512),
                                                # transforms.CenterCrop(256),
                                                transforms.ToTensor()])
                                            )
test_data = torchvision.datasets.ImageFolder('D:/debug/python/pytorchdemo/pic/val',
                                            transform=transforms.Compose([
                                                transforms.Scale(512),
                                                # transforms.CenterCrop(256),
                                                transforms.ToTensor()])
                                            )
train_loader = torch.utils.data.DataLoader(train_data, batch_size=2,shuffle=True)
test_loader = torch.utils.data.DataLoader(test_data,batch_size=2, shuffle=True)

model = CNNnet()
loss_func = nn.CrossEntropyLoss()
optimizer = optim.SGD(model.parameters(), lr=0.02)  # 设置学习方法
# num_epochs = 100 # 设置训练次数
# print(model)

def train_fun():
    epochs = 0
    loss_list = []
    # for eopch in range(EPOCH):
    for data in (train_loader):
        b_x,b_y=data
        b_x,b_y=Variable(b_x),Variable(b_y)
        out_put=model(b_x)
        loss=loss_func(out_put,b_y)

        optimizer.zero_grad()
        loss.backward()
        optimizer.step()

        #
        if epochs < 20:
            epochs += 1
            print('Epoch: ', epochs, 'loss: ', float(loss))
            loss_list.append(float(loss))
        # else:
        #     epochs += 1

    return loss_list


# criterion = nn.MSELoss()  # 设定误差函数
def test_fun():
    eval_loss = 0
    eval_acc = 0
    # for eopch in range(EPOCH):
    for data in (test_loader):
        b_x, b_y = data
        b_x, b_y = Variable(b_x), Variable(b_y)  # b_x �img b_y是标�
        out_put = model(b_x)
        loss = loss_func(out_put, b_y)
        eval_loss += loss.data.item() * b_y.size(0)
        _, pred = torch.max(out_put, 1)
        # print("pred",pred,b_y)
        num_correct = (pred == b_y).sum()
        eval_acc += num_correct.item()
        # print(eval_acc)
        print('Test Loss: {:.4f}, Acc: {:.4f}'.format(
        eval_loss / (len(test_data)),
        eval_acc / (len(test_data)), 100. * eval_acc / len(test_data)
    ))



# params = list(model.parameters())
# print(len(params))
# print(params[0].size())  # conv1's .weight
# train_fun()
# torch.save(model,"mycnn1")
# test_fun()