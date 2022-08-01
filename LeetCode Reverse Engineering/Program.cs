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





List<int> testList = new List<int>();

ListNode node1 = new ListNode(3, null);
ListNode node2 = new ListNode(3, node1);
ListNode node3 = new ListNode(2, node2);
ListNode node4 = new ListNode(1, node3);
ListNode node5 = new ListNode(1, node4);

ListNode returnHead = engine.DeleteDuplicates(node5);

char[][] board = new char[][]{
 new char[] {'8','3','.','.','7','2','.','.','.'}
,new char[] {'6','.','.','1','9','5','.','.','.'}
,new char[] {'.','9','2','.','.','.','.','6','.'}
,new char[] {'3','.','.','.','6','.','.','.','3'}
,new char[] {'4','.','.','8','.','3','.','.','1'}
,new char[] {'7','.','.','.','2','.','.','.','6'}
,new char[] {'.','6','.','.','.','.','2','8','.'}
,new char[] {'.','.','.','4','1','9','.','.','5'}
,new char[] {'.','.','.','.','8','.','.','7','9'}};

char[][] board2 = new char[][]
{
  new char[]{'5', '3', '.', '.', '7', '.', '.', '.', '.'}
, new char[] {'6','.','.','1','9','5','.','.','.'}
, new char[] {'.','9','8','.','.','.','.','6','.'}
, new char[] {'8','.','.','.','6','.','.','.','3'}
, new char[] {'4','.','.','8','.','3','.','.','1'}
, new char[] {'7','.','.','.','2','.','.','.','6'}
, new char[] {'.','6','.','.','.','.','2','8','.'}
, new char[] {'.','.','.','4','1','9','.','.','5'}
, new char[] {'.','.','.','.','8','.','.','7','9'}};

char[][] board3 = new char[][]
{
    new char[]{'.','.','.','.','.','.','.','5','.'}
,new char[]{'.','.','.','.','.','.','.','.','.'}
,new char[]{'.','.','6','1','.','.','2','.','.'}
,new char[]{'7','.','.','.','.','.','7','.','.'}
,new char[]{'.','.','.','.','.','.','.','.','.'}
,new char[]{'.','.','.','.','.','3','.','.','.'}
,new char[]{'.','3','.','.','.','5','8','.','.'}
,new char[]{'.','.','.','2','.','.','.','3','.'}
,new char[]{'.','.','.','.','.','.','.','.','.'}};


/*for (int i = 0; i < board.Length; i++)
{
    for (int k = 0; k < board[i].Length; k++) Console.WriteLine("k is {0} and borad is {1}",k,board[i][k]);
}*/

Console.WriteLine(engine.IsValidSudoku(board));










