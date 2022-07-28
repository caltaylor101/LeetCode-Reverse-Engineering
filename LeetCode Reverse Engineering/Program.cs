// See https://aka.ms/new-console-template for more information
using LeetCode_Reverse_Engineering;
using System.Text;

Console.WriteLine("Hello, World!");

ListNode node1 = new ListNode(5); 
ListNode node2 = new ListNode(4, node1); 
ListNode node3 = new ListNode(3, node2); 
ListNode node4 = new ListNode(2, node3); 
ListNode node5 = new ListNode(1);

ReverseEngineering engine = new ReverseEngineering();

//int[] testNums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//int[] testNums = new int[] { 11,12,13,14,1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//int[] testNums = new int[] { 4,5,6,7,0,1,2 };
int[] testNums = new int[] { 1,2,3 };
//int[] testNums = new int[] { 1,3 };
// mid = 3, left = 11, right 10
//Console.WriteLine(Array.BinarySearch(testNums, 3, testNums.Length - 3, 10));

int[] list = new int[] { 833, 736, 953, -584, -448, 207, 128, -445, 126, 248, 871, 860, 333, -899, 463, 488, -50, -331, 903, 575, 265, 162, -733, 648, 678, 549, 579, -172, -897, 562, -503, -508, 858, 259, -347, -162, -505, -694, 300, -40, -147, 383, -221, -28, -699, 36, -229, 960, 317, -585, 879, 406, 2, 409, -393, -934, 67, 71, -312, 787, 161, 514, 865, 60, 555, 843, -725, -966, -352, 862, 821, 803, -835, -635, 476, -704, -78, 393, 212, 767, -833, 543, 923, -993, 274, -839, 389, 447, 741, 999, -87, 599, -349, -515, -553, -14, -421, -294, -204, -713, 497, 168, 337, -345, -948, 145, 625, 901, 34, -306, -546, -536, 332, -467, -729, 229, -170, -915, 407, 450, 159, -385, 163, -420, 58, 869, 308, -494, 367, -33, 205, -823, -869, 478, -238, -375, 352, 113, -741, -970, -990, 802, -173, -977, 464, -801, -408, -77, 694, -58, -796, -599, -918, 643, -651, -555, 864, -274, 534, 211, -910, 815, -102, 24, -461, -146 };

Console.WriteLine(engine.ThreeSumClosest(list, -7111));








