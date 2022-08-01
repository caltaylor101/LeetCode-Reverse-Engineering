using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode_Reverse_Engineering
{
    internal class ReverseEngineeringPart2
    {
        public string IntToRoman(int num)
        {
            if (num >= 1000) return "M" + IntToRoman(num - 1000);

            if (num >= 500) return num >= 900 ? ("CM" + IntToRoman(num - 900)) : ("D" + IntToRoman(num - 500));

            if (num >= 100) return num >= 400 ? ("CD" + IntToRoman(num - 400)) : ("C" + IntToRoman(num - 100));

            if (num >= 50) return num >= 90 ? ("XC" + IntToRoman(num - 90)) : ("L" + IntToRoman(num - 50));

            if (num >= 10) return num >= 40 ? ("XL" + IntToRoman(num - 40)) : ("X" + IntToRoman(num - 10));

            if (num >= 5) return num >= 9 ? "IX" : ("V" + IntToRoman(num - 5));

            if (num > 0) return num == 4 ? "IV" : ("I" + IntToRoman(num - 1));

            return "";
        }

        public int RemoveElement2(int[] nums, int val)
        {
            if (nums.Length == 0) return 0;
            //Our offset
            int offsetShift = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                //If we hit a value that equals ours, then we don't count our offset. 
                //So for example, if i = 3, and it equals val, then offset will become 2, essentially shifting every element over.
                if (nums[i] != val)
                {
                    nums[offsetShift++] = nums[i];
                }

            }
            return offsetShift;
        }

        public int RemoveElement(int[] nums, int val)
        {
            if (nums.Length == 0) return 0;

            //right pointer
            int right = nums.Length - 1;
            int counter = nums.Length;

            for (int i = 0; i <= right; i++)
            {
                if (nums[i] == val)
                {
                    //If the right index is the same as our val, we can skip past it and keep track of the counter. 
                    while (i < right && nums[right] == val)
                    {
                        right--;
                        counter--;
                    }
                    //Then we replace the element with the right side element.
                    nums[i] = nums[right];
                    //move the right index over again and continue.
                    right--;
                    counter--;
                }

            }
            return counter;
        }




        public int StrStr(string haystack, string needle)
        {
            if (needle == "") return 0;
            if (needle.Length > haystack.Length) return -1;
            int needleIndex = 0;
            int checkIndex = -1;

            for (int i = 0; i < haystack.Length; i++)
            {
                //If the remaining haystack is smaller than our needle, then return -1 because it is impossible for needle to exist.
                if (haystack.Length - i < needle.Length) return -1;

                if (haystack[i] == needle[needleIndex])
                {
                    //Set our index to check. 
                    checkIndex = i;
                    //Loop through the needle using the check index.
                    while (needleIndex < needle.Length)
                    {
                        //If it doesn't match, then reset the variables and break the loop.
                        if (haystack[checkIndex] != needle[needleIndex])
                        {
                            needleIndex = 0;
                            checkIndex = -1;
                            break;
                        }
                        //If we check the last index of the needle, and it equals, then we found the string.
                        //Return i, as that is where we started.
                        else if (haystack[checkIndex] == needle[needleIndex] && needleIndex == needle.Length - 1)
                        {
                            return i;
                        }
                        //Otherwise, increase and keep comparing. 
                        checkIndex++;
                        needleIndex++;
                    }
                }
            }
            return checkIndex;
        }








        public int LengthOfLastWord(string s)
        {
            int startIndex = 0;
            bool startCount = false;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                //If we are counting a word and find a whitespace, then we return the end of the word - index of the white space.
                if (s[i] == ' ' && startCount)
                {
                    return startIndex - i;
                }
                //If we are hitting whitespace at the end of the string, keep going going till we find a letter.
                //Mark a boolean trigger, startCount, then keep track of the end of the word, startIndex.
                else if (s[i] != ' ' && !startCount)
                {
                    startCount = true;
                    startIndex = i;
                }
            }

            //Return the startIndex + 1. 
            //This scenario happens when the loop ends at 0.
            //So if we had a string, "x      ", then x would index 0, and start index would be 0.
            //We add 1 to account for that extra space. 
            return startIndex + 1;
        }













        public int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                //If a digit is 9 make it 0 and continue.
                //No need to calculate anything.
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                }
                //Otherwise add 1 and break the loop to return digits.
                else
                {
                    digits[i] += 1;
                    break;
                }
            }

            //Since we know there are no leading 0's, we can quickly check if this is a 0.
            if (digits[0] == 0)
            {
                //Create an empty array with 1 extra spot than digits for the extra value. 
                int[] result = new int[digits.Length + 1];
                //Set the first spot in the result array to 1.
                result[0] = 1;
                //Copy digits to the result array starting at index 1.
                digits.CopyTo(result, 1);
                return result;
            }


            return digits;
        }





        public string AddBinary2(string a, string b)
        {
            string longString = (a.Length >= b.Length) ? a : b;
            string shortString = (a.Length < b.Length) ? a : b;
            List<char> newString = new List<char>();

            Console.WriteLine(longString);
            int longStringIndex = longString.Length - 1;
            int shortStringIndex = shortString.Length - 1;
            int calculateValue = 0;

            while (shortStringIndex >= 0)
            {
                if (longString[longStringIndex--] == '1')
                {
                    calculateValue++;
                }
                if (shortString[shortStringIndex--] == '1')
                {
                    calculateValue++;
                }

                if (calculateValue == 3)
                {
                    newString.Insert(0, '1');
                    calculateValue = 1;
                }
                else if (calculateValue == 2)
                {
                    newString.Insert(0, '0');
                    calculateValue = 1;
                }
                else if (calculateValue == 1)
                {
                    newString.Insert(0, '1');
                    calculateValue = 0;
                }
                else
                {
                    newString.Insert(0, '0');
                }
            }

            while (longStringIndex != -1)
            {
                if (longString[longStringIndex--] == '1')
                {
                    calculateValue++;
                }

                if (calculateValue == 2)
                {
                    newString.Insert(0, '0');
                    calculateValue = 1;
                }
                else if (calculateValue == 1)
                {
                    newString.Insert(0, '1');
                    calculateValue = 0;
                }
                else
                {
                    newString.Insert(0, '0');
                }
            }

            while (calculateValue != 0)
            {
                if (calculateValue == 3)
                {
                    newString.Insert(0, '1');
                    calculateValue = 1;
                }
                else if (calculateValue == 2)
                {
                    newString.Insert(0, '0');
                    calculateValue = 1;
                }
                else if (calculateValue == 1)
                {
                    newString.Insert(0, '1');
                    calculateValue = 0;
                }
                else
                {
                    newString.Insert(0, '0');
                }
            }

            return new string(newString.ToArray());

        }



        public string AddBinary3(string a, string b)
        {
            string longString = (a.Length >= b.Length) ? a : b;
            string shortString = (a.Length < b.Length) ? a : b;

            int longStringIndex = longString.Length - 1;
            int shortStringIndex = shortString.Length - 1;

            while (shortStringIndex >= 0)
            {
                if (longString[longStringIndex--] == '1')
                {
                    calculateValue++;
                }
                if (shortString[shortStringIndex--] == '1')
                {
                    calculateValue++;
                }

                CalculateValue();
            }

            while (longStringIndex != -1)
            {
                if (longString[longStringIndex--] == '1')
                {
                    calculateValue++;
                }

                CalculateValue();
            }

            while (calculateValue != 0)
            {
                CalculateValue();
            }

            return new string(newString.ToArray());

        }

        private void CalculateValue2()
        {
            if (calculateValue == 3)
            {
                newString.Insert(0, '1');
                calculateValue = 1;
            }
            else if (calculateValue == 2)
            {
                newString.Insert(0, '0');
                calculateValue = 1;
            }
            else if (calculateValue == 1)
            {
                newString.Insert(0, '1');
                calculateValue = 0;
            }
            else
            {
                newString.Insert(0, '0');
            }
        }

        public string AddBinary4(string a, string b)
        {
            //Ternary operators to find long and short strings.
            string longString = (a.Length >= b.Length) ? a : b;
            string shortString = (a.Length < b.Length) ? a : b;

            //Index values for our strings.
            int longStringIndex = longString.Length - 1;
            int shortStringIndex = shortString.Length - 1;

            while (shortStringIndex >= 0)
            {
                if (longString[longStringIndex--] == '1')
                {
                    calculateValue++;
                }
                if (shortString[shortStringIndex--] == '1')
                {
                    calculateValue++;
                }

                CalculateValue();
            }

            while (longStringIndex != -1)
            {
                if (longString[longStringIndex--] == '1')
                {
                    calculateValue++;
                }

                CalculateValue();
            }

            while (calculateValue != 0)
            {
                CalculateValue();
            }
            newString.Reverse();
            return new string(newString.ToArray());

        }




        private int calculateValue = 0;
        private List<char> newString = new List<char>();
        public string AddBinary(string a, string b)
        {
            //Ternary operators to find long and short strings.
            //Basically read as: if a.Length >= b.Length longString = a; else longString = b;
            string longString = (a.Length >= b.Length) ? a : b;
            //If longString == a, shorstring = b; else shortstring = a
            string shortString = (longString == a) ? b : a;

            //Index values for our strings.
            int longStringIndex = longString.Length - 1;
            int shortStringIndex = shortString.Length - 1;

            //Optional. Since we know the general capacity of our list, we can save an O(n log(n)) operation by setting capacity.
            newString.Capacity = longString.Length + shortString.Length + 1;

            while (longStringIndex >= 0)
            {
                //After this condition executes, lower longStringIndex by 1
                if (longString[longStringIndex--] == '1')
                {
                    calculateValue++;
                }

                //check if shortString index is 0, if not then lower it's index when checking the if condition.
                if (shortStringIndex >= 0 && shortString[shortStringIndex--] == '1')
                {
                    calculateValue++;
                }

                CalculateValue();
            }

            //Clean up the remaining CalculateValue.
            if (calculateValue != 0) CalculateValue();

            //Reverse our list and then transfer it to a char array to return as a new string. 
            newString.Reverse();
            return new string(newString.ToArray());
        }
        private void CalculateValue()
        {
            switch (calculateValue)
            {
                case 3:
                    newString.Add('1');
                    calculateValue = 1;
                    break;
                case 2:
                    newString.Add('0');
                    calculateValue = 1;
                    break;
                case 1:
                    newString.Add('1');
                    calculateValue = 0;
                    break;
                default:
                    newString.Add('0');
                    break;
            }
        }






        //Possible range of roots are 0 - 46,340
        public int MySqrt(int x)
        {
            //Takes care of max edge case.
            if (x >= 2147395600) return 46340;
            //Takes care of min edge case.
            if (x == 0) return 0;

            //The maximum ceiling.
            int maxSquare = 46340;
            //The minimum square we will return
            int minSquare = 1;

            //The root calculated for our guess.
            int guessRoot = 0;
            //The guess.
            int guess = 0;

            // if this is 1, then minSquare is our answer. 
            while (maxSquare - minSquare != 1)
            {
                //Get the middle value of maxSquare and minSquare
                guessRoot = (maxSquare + minSquare) / 2;
                //Multiply the root and check the guess with a standard binary search pattern.
                guess = guessRoot * guessRoot;
                if (guess == x) return guessRoot;
                else if (guess > x)
                {
                    maxSquare = guessRoot;
                }
                else
                {
                    minSquare = guessRoot;
                }
            }

            return minSquare;

        }



















        public ListNode DeleteDuplicates3(ListNode head)
        {
            ListNode followNode = new ListNode(0, head);
            ListNode traverseNode = head;
            HashSet<int> values = new HashSet<int>();

            while (traverseNode != null)
            {
                if (!values.Add(traverseNode.val))
                {
                    followNode.next = traverseNode.next;
                    traverseNode = traverseNode.next;
                }
                else
                {
                    traverseNode = traverseNode.next;
                    followNode = followNode.next;
                }
            }

            return head;

        }




        public ListNode DeleteDuplicates2(ListNode head)
        {
            ListNode followNode = new ListNode(-101, head);
            ListNode traverseNode = head;

            while (traverseNode != null)
            {
                if (followNode.val == traverseNode.val)
                {
                    followNode.next = traverseNode.next;
                    traverseNode = traverseNode.next;
                }
                else
                {
                    traverseNode = traverseNode.next;
                    followNode = followNode.next;
                }
            }

            return head;

        }


        public ListNode DeleteDuplicates(ListNode head)
        {
            //A reference to the list so that we can return the head at the end
            ListNode traverseNode = head;

            while (traverseNode != null)
            {
                //Make sure the next exists, if it does and the values equal, then reassign the traversal node to skip it.
                if (traverseNode.next != null && traverseNode.val == traverseNode.next.val)
                {
                    traverseNode.next = traverseNode.next.next;
                }
                else
                {
                    //Otherwise, traverse through the list.
                    traverseNode = traverseNode.next;
                }
            }

            //Return the head.
            return head;

        }


        private Dictionary<Node, Node> map = new Dictionary<Node, Node>();
        public Node CloneGraph2(Node node)
        {
            if (node == null) return null;
            if (!map.ContainsKey(node))
            {
                map.Add(node, new Node(node.val));
                foreach (var n in node.neighbors)
                {
                    map[node].neighbors.Add(CloneGraph(n));
                }
            }
            return map[node];
        }

        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return null;
            }

            Dictionary<Node, Node> dict = new Dictionary<Node, Node>();
            dict.Add(node, new Node(node.val));

            dfs(node, dict);
            return dict[node];

        }

        private void dfs(Node node, Dictionary<Node, Node> dict)
        {
            if (node == null) return;

            foreach (var neighbor in node.neighbors)
            {
                if (!dict.ContainsKey(neighbor))
                {
                    dict.Add(neighbor, new Node(neighbor.val));
                    dfs(neighbor, dict);
                }

                dict[node].neighbors.Add(dict[neighbor]);
            }


        }






        public int[] SearchRange2(int[] nums, int target)
        {
            if (nums.Length == 0) return new int[] { -1, -1 };

            int left = 0;
            int right = nums.Length - 1;
            var mid = 0;

            //First do a binary search for the target. 
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (nums[mid] == target) break;
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            //If the target wasn't found, then return {-1, -1}
            if (nums[mid] != target) return new int[] { -1, -1 };

            //Otherwise, we find the range it exists in, and return that range.
            left = mid;
            right = mid;
            while (left - 1 >= 0 && nums[left - 1] == nums[mid])
            {
                left--;
            }
            while (right + 1 <= nums.Length - 1 && nums[right + 1] == nums[mid])
            {
                right++;
            }

            return new int[] { left, right };

        }



        public int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0) return new int[] { -1, -1 };

            int left = 0;
            int right = nums.Length - 1;

            //First do a binary search for the target. 
            int result = Array.BinarySearch(nums, target);

            //If the target wasn't found, then return {-1, -1}
            //When BinarySearch() doesn't find the target, it will return a negative number. 
            if (result < 0) return new int[] { -1, -1 };

            //Otherwise, we find the range it exists in, and return that range.
            else
            {
                left = result;
                right = result;
                while (left - 1 >= 0 && nums[left - 1] == nums[result])
                {
                    left--;
                }
                while (right + 1 <= nums.Length - 1 && nums[right + 1] == nums[result])
                {
                    right++;
                }
            }

            return new int[] { left, right };

        }








        private Regex regex = new Regex(@"^\d$");
        private HashSet<string> flag = new HashSet<string>();
        public bool IsValidSudoku2(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int k = 0; k < board[i].Length; k++)
                {
                    if (char.IsNumber(board[i][k]))
                    {
                        //Check the block
                        int vertical = i / 3;
                        vertical *= 3;
                        int horizontal = k / 3;
                        horizontal *= 3;
                        for (int verticalTest = vertical; verticalTest < vertical + 3; verticalTest++)
                        {
                            for (int horizontalTest = horizontal; horizontalTest < horizontal + 3; horizontalTest++)
                            {
                                if (!flag.Add(verticalTest.ToString() + horizontalTest.ToString() + board[i][k])) continue;
                                if (board[verticalTest][horizontalTest] == board[i][k] && (k != horizontalTest || i != verticalTest)) return false;
                            }
                        }
                        // test vertically
                        vertical = 0;
                        while (vertical < board.Length)
                        {
                            //cache the result and continue if it has already been checked.
                            if (!flag.Add(vertical.ToString() + k.ToString() + board[i][k].ToString()))
                            {
                                vertical++;
                                continue;
                            }
                            if (board[i][k] == board[vertical][k] && i != vertical)
                            {
                                return false;
                            }
                            vertical++;
                        }
                        // test horizontally
                        horizontal = 0;
                        while (horizontal < board[i].Length)
                        {
                            //cache the result and continue if it has already been checked.
                            if (!flag.Add(i.ToString() + horizontal.ToString() + board[i][k].ToString()))
                            {
                                horizontal++;
                                continue;
                            }
                            if (board[i][k] == board[i][horizontal] && k != horizontal)
                            {
                                return false;
                            }
                            horizontal++;
                        }
                    }
                }
            }

            return true;
        }


        private HashSet<char> checkBlock = new HashSet<char>();
        private HashSet<string> blockFlag = new HashSet<string>();
        private int counter = 0;
        public bool IsValidSudoku3(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int k = 0; k < board[i].Length; k++)
                {
                    counter++;
                    if (char.IsNumber(board[i][k]))
                    {
                        int vertical = i / 3;
                        vertical *= 3;
                        int horizontal = k / 3;
                        horizontal *= 3;

                        //A cache to stop iterations.
                        if (blockFlag.Add("v" + vertical.ToString() + "h" + horizontal.ToString()))
                        {
                            for (int verticalTest = vertical; verticalTest < vertical + 3; verticalTest++)
                            {
                                for (int horizontalTest = horizontal; horizontalTest < horizontal + 3; horizontalTest++)
                                {
                                    if (board[verticalTest][horizontalTest] == '.') continue;
                                    if (char.IsNumber(board[verticalTest][horizontalTest]) && !checkBlock.Add(board[verticalTest][horizontalTest])) return false;
                                    flag.Add(verticalTest.ToString() + horizontalTest.ToString() + board[verticalTest][horizontalTest].ToString());
                                }
                            }
                            checkBlock.Clear();
                            k += 3;
                        }
                    }
                }
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int k = 0; k < board[i].Length; k++)
                {
                    if (char.IsNumber(board[i][k]))
                    {
                        // test vertically
                        int vertical = 0;
                        while (vertical < board.Length)
                        {
                            if (board[vertical][k] == '.')
                            {
                                vertical++;
                                continue;
                            }
                            if (i != vertical && flag.Contains(vertical.ToString() + k.ToString() + board[i][k].ToString()))
                            {
                                return false;
                            }
                            vertical++;
                        }
                        // test horizontally
                        int horizontal = 0;
                        while (horizontal < board[i].Length)
                        {
                            if (board[i][horizontal] == '.')
                            {
                                horizontal++;
                                continue;
                            }
                            if (k != horizontal && flag.Contains(i.ToString() + horizontal.ToString() + board[i][k].ToString()))
                            {
                                return false;
                            }
                            horizontal++;
                        }
                    }
                }
            }

            return true;
        }


        private Dictionary<char, List<List<int>>> dict = new Dictionary<char, List<List<int>>>();
        public bool IsValidSudoku4(char[][] board)
        {
            //Check each block
            for (int i = 0; i < board.Length; i += 3)
            {
                for (int k = 0; k < board[i].Length; k += 3)
                {
                    int vertical = i / 3;
                    vertical *= 3;
                    int horizontal = k / 3;
                    horizontal *= 3;

                    if (blockFlag.Add("v" + vertical.ToString() + "h" + horizontal.ToString()))
                    {
                        for (int verticalTest = vertical; verticalTest < vertical + 3; verticalTest++)
                        {
                            for (int horizontalTest = horizontal; horizontalTest < horizontal + 3; horizontalTest++)
                            {
                                if (board[verticalTest][horizontalTest] == '.') continue;
                                if (char.IsNumber(board[verticalTest][horizontalTest]) && !checkBlock.Add(board[verticalTest][horizontalTest])) return false;
                                flag.Add(verticalTest.ToString() + horizontalTest.ToString() + board[verticalTest][horizontalTest].ToString());
                                
                            }
                        }
                        checkBlock.Clear();
                    }
                }
            }
            foreach (var key in flag)
            {
                int vertical = Convert.ToInt32(key[0].ToString());
                int horizontal = Convert.ToInt32(key[1].ToString());
                int value = key[2];

                int verticalCheck = 0;
                int horizontalCheck = 0;
                while (verticalCheck < 9)
                {
                    
                    if (vertical != verticalCheck && board[verticalCheck][horizontal] == value) return false;
                    verticalCheck++;
                }

                while (horizontalCheck < 9)
                {
                    if (horizontal != horizontalCheck && board[vertical][horizontalCheck] == value) return false;
                    horizontalCheck++;
                }

            }

            return true;
        }


        public bool IsValidSudoku(char[][] board)
        {
            HashSet<char> checkBlock = new HashSet<char>();
            Dictionary<char, List<List<int>>> valueDict = new Dictionary<char, List<List<int>>>();
            HashSet<int> verticalSet = new HashSet<int>();
            HashSet<int> horizontalSet = new HashSet<int>();

            //Check each 3x3 block first.
            //These first 2 for loops make sure we switch to a new block on each iteration, which is why they are incrementing by 3.
            for (int i = 0; i < board.Length; i += 3)
            {
                for (int k = 0; k < board[i].Length; k += 3)
                {
                    //This represents our vertical test, we want the 3 rows.
                    for (int verticalTest = i; verticalTest < i + 3; verticalTest++)
                    {
                        //This represents the horizontal test on the next 3 columns. 
                        for (int horizontalTest = k; horizontalTest < k + 3; horizontalTest++)
                        {
                            //If it's a "." then we just continue through the loop. 
                            if (board[verticalTest][horizontalTest] == '.') continue;
                            //We add each value to a checkBlock set. 
                            //If there are duplicate values in this hashset we return false. 
                            if (!checkBlock.Add(board[verticalTest][horizontalTest])) return false;
                            //We try to add the value to the dictionary. 
                            //If the value exists, then we add the coordinates to a list of values. 
                            if (!valueDict.TryAdd(board[verticalTest][horizontalTest], new List<List<int>>() { new List<int>() { verticalTest, horizontalTest } }))
                            {
                                valueDict[board[verticalTest][horizontalTest]].Add(new List<int>() { verticalTest, horizontalTest });
                            }
                        }
                    }
                    //Clear the checkBlock for the next iteration. 
                    checkBlock.Clear();
                }
            }

            foreach (var key in valueDict)
            {
                //for each list in the values recorded, we check to see if any vertical or horizontal values match. 
                foreach (var list in key.Value)
                {
                    if (!verticalSet.Add(list[0])) return false;
                    if (!horizontalSet.Add(list[1])) return false;
                }
                //Clear the sets and test the next key.
                verticalSet.Clear();
                horizontalSet.Clear();
            }

            return true;
        }

        





    }
}
