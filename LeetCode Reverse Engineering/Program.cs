// See https://aka.ms/new-console-template for more information
using LeetCode_Reverse_Engineering;
using System.Text;



ReverseEngineeringPart2 engine = new ReverseEngineeringPart2();

//int[] testNums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//int[] testNums = new int[] { 11,12,13,14,1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//int[] testNums = new int[] { 4,5,6,7,0,1,2 };
int[] testNums = new int[] { 9,9,9,9,9 };
//int[] testNums = new int[] { 1,3 };
// mid = 3, left = 11, right 10
//Console.WriteLine(Array.BinarySearch(testNums, 3, testNums.Length - 3, 10));




string binary = engine.AddBinary("111111111111111111010101010110110011000", "1111111111111111111000101101110101010101111001011111");

List<int> testList = new List<int>();

ListNode node1 = new ListNode(3, null);
ListNode node2 = new ListNode(3, node1);
ListNode node3 = new ListNode(2, node2);
ListNode node4 = new ListNode(1, node3);
ListNode node5 = new ListNode(1, node4);

ListNode returnHead = engine.DeleteDuplicates(node5);

while (returnHead != null)
{
    Console.WriteLine(returnHead.val);
    returnHead = returnHead.next;
}









