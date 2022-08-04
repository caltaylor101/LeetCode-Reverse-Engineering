// See https://aka.ms/new-console-template for more information
using LeetCode_Reverse_Engineering;
using System.Text;



ReverseEngineeringPart3 engine = new ReverseEngineeringPart3();

TreeNode node2 = new TreeNode(3);
TreeNode node3 = new TreeNode(3);
TreeNode node4 = new TreeNode(3);
TreeNode node5 = new TreeNode(3, node4, node2);
TreeNode node6 = new TreeNode(2, node5, node3);

UInt64 num = 00000010100101000001111010011100;
Console.WriteLine(engine.reverseBits(num));












