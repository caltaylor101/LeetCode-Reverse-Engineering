// See https://aka.ms/new-console-template for more information
using LeetCode_Reverse_Engineering;
using System.Text;



ReverseEngineeringPart3 engine = new ReverseEngineeringPart3();

TreeNode node1 = new TreeNode(3, null, null);
TreeNode node2 = new TreeNode(2, null, null);
TreeNode node3 = new TreeNode(1, node2, node1);

TreeNode node7 = new TreeNode(49, null, null);
TreeNode node4 = new TreeNode(3,null, node7);
TreeNode node5 = new TreeNode(2, null, null);
TreeNode node6 = new TreeNode(1, node5, node4);

Console.WriteLine(engine.IsSameTree(node3, node6));













