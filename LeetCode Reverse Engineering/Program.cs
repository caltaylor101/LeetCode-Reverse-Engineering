// See https://aka.ms/new-console-template for more information
using LeetCode_Reverse_Engineering;
using System.Text;



ReverseEngineeringPart3 engine = new ReverseEngineeringPart3();

TreeNode node12 = new TreeNode(8, null, null);
TreeNode node11 = new TreeNode(9, null, null);

TreeNode node9 = new TreeNode(8, null, null);
TreeNode node10 = new TreeNode(9, null, null);

TreeNode node7 = new TreeNode(5, null, null);
TreeNode node8 = new TreeNode(4, node11, node12);

TreeNode node1 = new TreeNode(5, node9, node10);
TreeNode node2 = new TreeNode(4, null, null);

TreeNode node4 = new TreeNode(3, node7, node8);
TreeNode node5 = new TreeNode(3, node2, node1);
TreeNode node6 = new TreeNode(2, node5, node4);

Console.WriteLine(engine.IsSymmetric(node6));













