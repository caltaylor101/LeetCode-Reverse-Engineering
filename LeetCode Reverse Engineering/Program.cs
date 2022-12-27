// See https://aka.ms/new-console-template for more information
using LeetCode_Reverse_Engineering;
using System.Text;



ReverseEngineeringPart4 engine = new ReverseEngineeringPart4();



ListNode node1 = new ListNode(9);
ListNode node2 = new ListNode(1, node1);
ListNode node3 = new ListNode(5, node2);
ListNode node4 = new ListNode(4, node3);


//Console.WriteLine(engine.IsIPV4Address(new string[] { "256.168.256.1" }));

Console.WriteLine(engine.CanJump(new int[] { 3, 2, 1, 0, 4 }));









