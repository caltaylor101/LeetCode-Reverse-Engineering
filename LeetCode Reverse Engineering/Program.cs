// See https://aka.ms/new-console-template for more information
using LeetCode_Reverse_Engineering;

Console.WriteLine("Hello, World!");

ListNode node1 = new ListNode(5); 
ListNode node2 = new ListNode(4, node1); 
ListNode node3 = new ListNode(3, node2); 
ListNode node4 = new ListNode(2, node3); 
ListNode node5 = new ListNode(1);

ReverseEngineering engine = new ReverseEngineering();
Console.WriteLine(int.MinValue);

Console.WriteLine("answer " + engine.Divide(103892580, int.MinValue));