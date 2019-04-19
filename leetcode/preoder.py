'''
@author: neo
@file: preoder.py
@time: 2019/4/19 15:33
'''

class TreeNode:
    def __init__(self, val):
        self.val = val
        self.left, self.right = None, None

class Solution:
    """
    @param root: A Tree
    @return: Preorder in ArrayList which contains node values.
    """
    result = []

    def postorderTraversal(self, root):
        # write your code here
        # print(type(root))
        self.left(root)
        return self.result

    def left(self, root):
        if root == None:
            return
        self.left(root.left)
        self.right(root.right)
        self.result.append(root.val)

    def right(self, root):
        if root == None:
            return
        self.left(root.left)
        self.right(root.right)
        self.result.append(root.val)

if __name__ == '__main__':
    Tree = TreeNode(1)
    Tree.left = TreeNode(2)
    Tree.right = TreeNode(3)

    s = Solution()
    print(s.postorderTraversal(Tree))
