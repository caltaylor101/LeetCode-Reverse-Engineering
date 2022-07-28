using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Reverse_Engineering
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }


    internal class ReverseEngineering
    {

        public int ThreeSumClosest(int[] nums, int target)
        {
            int closestSum = int.MaxValue;
            int minDifference = int.MaxValue;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == target) return target;
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }


                    if (minDifference > Math.Abs(target - sum))
                    {
                        minDifference = Math.Abs(target - sum);
                        closestSum = sum;
                    }


                }

            }
            return closestSum;

        }
























        public string Convert(string s, int numRows)
        {

            //If there is 1 row, just return the string.
            if (numRows == 1) return s;

            //The list that will hold each row
            List<StringBuilder> rows = new List<StringBuilder>();
            //Counter to add characters to the correct row.
            int counter = 0;
            //A trigger to zigzag through the string.
            bool reverse = false;
            string returnString = "";

            //Create the individual StringBuilders based off the number of rows.
            for (int i = 1; i <= numRows; i++)
            {
                rows.Add(new StringBuilder());
            }

            foreach (char c in s)
            {
                //This trigger allows us to move back and forth through the string evenly.
                if (counter == numRows - 1)
                {
                    reverse = true;
                }
                if (counter == 0)
                {
                    reverse = false;
                }

                //Add the character to the row it belongs in.
                rows[counter].Append(c);
                //Ternary operator that basically says if(reverse) counter--; else counter++;
                counter += (reverse) ? -1 : 1;
            }

            //Concatenate everything to the blank return string. 
            foreach(StringBuilder row in rows)
            {
                returnString += (row.ToString());
            }

            return returnString;
        }























        private List<IList<int>> resultThreeSum = new List<IList<int>>();
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            if(nums.Length > 2)
            {
                for (int i = 0; i < nums.Length && nums[i] <= 0; i++)
                {
                    if (i == 0 || nums[i - 1] != nums[i])
                    {
                        TwoSum(i, nums);
                    }
                }
            }
            
            return resultThreeSum;
        }

        private void TwoSum(int i, int[] nums)
        {
            int left = i + 1;
            int right = nums.Length - 1;

            while(left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                if (sum > 0)
                {
                        right--;
                }
                else if (sum < 0)
                {
                        left++;
                }
                else
                {
                    resultThreeSum.Add(new List<int>() { nums[i], nums[left], nums[right] });
                    left++;
                    right--;
                    while (left < right && nums[left] == nums[left - 1])
                    {
                        left++;
                    }
                }
            }
        }

















        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (!map.TryAdd(num, 1))
                {
                    map[num]++;
                }
                if (map[num] > (nums.Length / 2)) return num;
            }

            return 0;
        }



        public int MajorityElement3(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }




        public int MajorityElemen2(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            Array.Sort(nums);
            int currentVal = nums[0];
            int counter = 1;

            int maxVal = currentVal;
            int maxOccurence = 1;

            for (int i = 1; i  < nums.Length; i++)
            {
                if (nums[i] == currentVal)
                {
                    counter++;
                }
                else
                {
                    if (counter > nums.Length / 2)
                    {
                        return currentVal;
                    }
                    if (counter > maxOccurence)
                    {
                        maxVal = currentVal;
                        maxOccurence = counter;
                    }
                    currentVal = nums[i];
                    counter = 1;
                }
            }
            if (counter > maxOccurence)
            {
                maxVal = nums[nums.Length - 1];
                maxOccurence = counter;
            }


            return maxVal;
        }




        public int SingleNumber3(int[] nums)
        {
            var singleNumber = 0;

            foreach (var num in nums)
            {
                singleNumber ^= num;
            }

            return singleNumber;
        }





        public int SingleNumber2(int[] nums)
        {
            Array.Sort(nums);
            int result = 0;
            int counter = 2;

            result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == result)
                {
                    counter = 1;
                }
                if (nums[i] != result && counter == 1)
                {
                    result = nums[i];
                    counter++;
                }
            }

            return result; 
        }



















        //A result list both functions can easily access.
        private List<IList<int>> result = new List<IList<int>>();
        //A permutation list so we don't have to pass the list down to each function
        private List<int> permutations = new List<int>();

        public IList<IList<int>> Permute(int[] nums)
        {
            int numsLength = nums.Length;

            NumsPermutationDFS(nums, numsLength, new bool[numsLength]);

            return result;
        }

        private void NumsPermutationDFS(int[] nums, int numsLength, bool[] isVisited)
        {
            //Step5 create an if condition for when our list needs to be pushed up to our result list.
            if (permutations.Count == numsLength)
            {
                //A new list must be added, otherwise the List object will be stored, and any modification to our list will be modified in our result.
                result.Add(new List<int>(permutations));
            }

            //Step6 We want our function to end if it pushed to our result list.
            else
            {
                //Step1 is to create a for loop that will call each function. 
                //The for loop allows us to backtrack through each possible iteration. 

                for (int i = 0; i < numsLength; i++)
                {
                    //Step4 Check to make sure that the index hasn't been visited already. If it has, continue to the next index.
                    if (isVisited[i]) continue;

                    //Step2 Traverse down as far as possible in the for loop.
                    permutations.Add(nums[i]);
                    //Step2 continued Make sure that we are keeping a reference of which indices have been visited.
                    isVisited[i] = true;

                    //Step3 Call the function to have an instance of each index running.
                    NumsPermutationDFS(nums, numsLength, isVisited);

                    //Step7 Now we remove the last index and free its visitation.
                    permutations.RemoveAt(permutations.Count - 1);
                    isVisited[i] = false;
                }
            }

        }
















        private List<IList<int>> result2 = new List<IList<int>>();
        public IList<IList<int>> Permute2(int[] nums)
        {
            int numsLength = nums.Length;
            NumsDFS2(nums, numsLength, new bool[numsLength], new List<int>());

            return result2;
        }

        private void NumsDFS2(int[] nums, int numsLength, bool[] isVisited, List<int> permutation )
        {
            if (permutation.Count == numsLength)
            {
                result2.Add(new List<int>(permutation));
            }
            else
            {
                //step 1 traverse down
                for (int i = 0; i < numsLength; i++)
                {
                    //if we have used this number, continue the loop.
                    if (isVisited[i]) continue;
                    //Add each value and mark it visited.
                    permutation.Add(nums[i]);
                    isVisited[i] = true;
                    NumsDFS2(nums, numsLength, isVisited, permutation);
                    isVisited[i] = false;
                    permutation.RemoveAt(permutation.Count - 1);
                }
            }
        }



        public int Search(int[] nums, int target)
        {
            int endIndex = nums.Length - 1;
            int left = 0;
            int right = endIndex;
            int mid = (left + right) / 2;
            int middleDivider = -1;

            //Takes care of any single arrays.
            if (nums.Length == 1) return (nums[0] == target) ? 0 : -1;
            //If the first number is less than the last number, that means the array couldn't have been rotated. 
            //We can just binary search this.
            if (nums[left] < nums[right])
            {
                return BinarySearch(nums, 0, endIndex, target);
            }
            //Otherwise I created a method to find the middle index, which is really just a slightly modified binary search.
            else
            {
                middleDivider = GetMiddleIndex(nums, left, right, mid);
            }

            //Search the first half
            int firstSearch = BinarySearch(nums, 0, middleDivider, target);
            if (firstSearch >= 0) return firstSearch;
            //Search the second half and return it.
            //Middle divider is increased to search the second half of the array. 
            return BinarySearch(nums, middleDivider + 1, endIndex, target);
        }
        //Since we checked up above and know that the array has been rotated, we can focus on finding the left side with a simple binary search
        private int GetMiddleIndex(int[] nums, int left, int right, int mid)
        {
            //Basic search where the main difference is that we increased the left and right to end the function and give us the exact midpoint.
            while (left <= right)
            {
                mid = (left + right) / 2;
                if (nums[left] > nums[mid])
                {
                    right = mid;
                }
                else if (nums[left] < nums[mid])
                {
                    left = mid;
                }
                else
                {
                    left++;
                    right--;
                }
            }

            return mid;
        }
        //Basic binary search.
        public int BinarySearch(int[] nums, int startIndex, int endIndex, int target)
        {
            int left = startIndex;
            int right = endIndex;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target) return mid;
                else if (target > nums[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }




        public int Search3(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target <= nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] <= target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return -1;
        }


        private static int HALF_INT_MIN = -1073741824;
        public int Divide2(int dividend, int divisor)
        {
            // Special case: overflow.
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            /* We need to convert both numbers to negatives
             * for the reasons explained above.
             * Also, we count the number of negatives signs. */
            int negatives = 2;
            if (dividend > 0)
            {
                negatives--;
                dividend = -dividend;
            }
            if (divisor > 0)
            {
                negatives--;
                divisor = -divisor;
            }

            /*****************Approach 1 *********************/
            /* Count how many times the divisor has to be added
             * to get the dividend. This is the quotient. */
            //int quotient = 0;
            //while (dividend - divisor <= 0) {
            //    quotient--;
            //    dividend -= divisor;
            //}

            /* If there was originally one negative sign, then
             * the quotient remains negative. Otherwise, switch
             * it to positive. */
            //if (negatives != 1) {
            //    quotient = -quotient;
            //}
            //return quotient;

            /*****************Approach 2 *********************/
            int quotient = 0;
            /* Once the divisor is bigger than the current dividend,
             * we can't fit any more copies of the divisor into it. */
            while (divisor >= dividend)
            {
                /* We know it'll fit at least once as divivend >= divisor.
                 * Note: We use a negative powerOfTwo as it's possible we might have
                 * the case divide(INT_MIN, -1). */
                int powerOfTwo = -1;
                int value = divisor;
                /* Check if double the current value is too big. If not, continue doubling.
                 * If it is too big, stop doubling and continue with the next step */
                while (value >= HALF_INT_MIN && value + value >= dividend)
                {
                    value += value;
                    powerOfTwo += powerOfTwo;
                }
                // We have been able to subtract divisor another powerOfTwo times.
                quotient += powerOfTwo;
                // Remove value so far so that we can continue the process with remainder.
                dividend -= value;
            }

            /* If there was originally one negative sign, then
             * the quotient remains negative. Otherwise, switch
             * it to positive. */
            if (negatives != 1)
            {
                return -quotient;
            }
            return quotient;
        }
        public int Divide(int dividend, int divisor)
        {
            bool isPositive = false;
            int counter = 0;

            if (dividend == divisor) return 1;

            if (divisor == 1) return dividend;

            if (dividend == 0) return 0;

            if (divisor < 0 && dividend < 0 && divisor < dividend) return 0;
            if (divisor > 0 && dividend > 0 && divisor > dividend) return 0;
            if (divisor < 0 && dividend > 0 && -divisor > dividend) return 0;
            if (divisor > 0 && dividend < 0 && divisor > -dividend && dividend != int.MinValue) return 0;

            if (dividend == Int32.MinValue && divisor == -1)
            {
                return Int32.MaxValue;
            }

            if (dividend > 0 && divisor == int.MinValue && dividend != int.MaxValue) return 0;

            if ((divisor > 0 && dividend > 0) || (divisor < 0 && dividend < 0))
            {
                isPositive = true;
            }

            if (divisor < 0)
            {
                var tmpDivisor = divisor;
                divisor -= tmpDivisor;
                divisor -= tmpDivisor;
            }

            if (dividend < 0 && dividend != int.MinValue)
            {
                var tmpDividend = dividend;
                dividend -= tmpDividend;
                dividend -= tmpDividend;
            }

            if (dividend == int.MinValue)
            {
                dividend = int.MaxValue;
                dividend -= divisor;
                counter++;
                dividend++;
            }




            while (dividend > divisor + divisor)
            {
                int secondDivisor = divisor;
                int secondCounter = 1;
                while (secondDivisor + secondDivisor < 1073741823 && secondDivisor + secondDivisor < dividend)
                {
                    secondDivisor += secondDivisor;
                    secondCounter += secondCounter;
                }


                dividend -= secondDivisor;
                counter += secondCounter;
            }

            while (dividend >= divisor)
            {
                dividend -= divisor;
                counter++;
            }

            if (!isPositive)
            {
                var tmpCounter = counter;
                counter -= tmpCounter;
                counter -= tmpCounter;
            }

            return counter;
        }

        //This list is added as private outside both functions so both may access it.
        private IList<string> resultList = new List<string>();

        public IList<string> GenerateParenthesis(int n)
        {
            //Call the recurse function
            BuildParenthesis(new StringBuilder(), n, n);

            return resultList;
        }

        public void BuildParenthesis(StringBuilder para, int leftPara, int rightPara)
        {
            if (rightPara == 0)
            {
                //Step4: Add the string to the result list.
                resultList.Add(para.ToString());
            }
            //Step5: We want this tail function to end once it's added to the string list.
            //We add this else function so that the function ends now that there are no left or right parenthesis left. 
            //Now we must traverse back up through our functions.
            else
            {
                //Step1: If left bracket and right bracket equal each other, we want to start with the left bracket.
                if (leftPara == rightPara)
                {
                    //Step2: Keep getting all the left parenthesis.
                    para.Append("(");
                    BuildParenthesis(para, leftPara - 1, rightPara);
                    //Step8: Remove to start a new set combination
                    para.Remove(para.Length - 1, 1);
                }
                //If they don't equal, then we need to distribute them.
                else
                {
                    if (leftPara > 0)
                    {
                        //Step2: We are still in Step 2 getting all the left parenthesis.
                        para.Append("(");
                        BuildParenthesis(para, leftPara - 1, rightPara);
                        //Step7: We remove the last left parenthesis we added to continue the function.
                        para.Remove(para.Length - 1, 1);
                        //Step7 Continued: Now if we had n = 2, at this step we would be running BuildParenthesis("(", 1,1);
                    }
                    if (rightPara > 0)
                    {
                        //Step3: We got all of our left parenthesis, so now we need to get all of the right parenthesis.
                        para.Append(")");
                        BuildParenthesis(para, leftPara, rightPara - 1);
                        //Step6: We remove the last one added so the function 1 level up can figure out what to do.
                        //This function ends.
                        para.Remove(para.Length - 1, 1);
                    }
                }
            }
        }

        /*//Create a list to return and add to.
        //It is initialized outside the functions so both have access to it. 
        private IList<string> result = new List<string>();
        public IList<string> GenerateParenthesis(int n)
        {
            
            //We call the recursive function we built to create a new string, then add that string to our result.
            ParenthesesBuilder(new StringBuilder(), n, n);

            return result;

        }

        private void ParenthesesBuilder(StringBuilder parentheses, int left, int right)
        {
            //Step4: Add the result to the list.
            if (right == 0)
            {
                result.Add(parentheses.ToString());
            }
            else
            {
                if (left == right)
                {
                    //Step1: Create the first call that will start each recursive function
                    parentheses.Append('(');
                    ParenthesesBuilder(parentheses, left - 1, right);
                    //Step7: remove left bracket
                    parentheses.Remove(parentheses.Length - 1, 1);
                }
                else
                {
                    if (left > 0)
                    {
                        //Step2: Create all the open parentheses as many times as we can.
                        parentheses.Append('(');
                        ParenthesesBuilder(parentheses, left - 1, right);
                        //Step6: Remove left bracket
                        parentheses.Remove(parentheses.Length - 1, 1);
                    }
                    if (right > 0)
                    {
                        //Step3: Create as many right parentheses as many times as we can
                        parentheses.Append(')');
                        ParenthesesBuilder(parentheses, left, right -1);
                        //Step5: Remove the right bracket
                        parentheses.Remove(parentheses.Length - 1, 1);
                    }
                }
            }
        }*/

        public IList<string> GenerateParenthesis2(int n)
        {

            StringBuilder parentheses1 = new StringBuilder();
            StringBuilder parentheses2 = new StringBuilder();
            //BuildParentheses(n, parentheses1, parentheses2);
            string halfParentheses1 = parentheses1.ToString();
            string halfParentheses2 = parentheses2.ToString();
            parentheses1.Clear();
            parentheses2.Clear();

            for (int i = 0; i < halfParentheses1.Length; i++)
            {
                for (int j = 0; j < halfParentheses2.Length; j++)
                {
                    parentheses1.Append(halfParentheses1[i]);
                    parentheses1.Append(halfParentheses2[j]);
                }
                parentheses1.ToString();
                Console.WriteLine(parentheses1);
                parentheses1.Clear();
            }

            parentheses1.ToString();
            Console.WriteLine(parentheses1);

            return null;
        }

        public void BuildParentheses2(int n, StringBuilder parentheses, StringBuilder parentheses2)
        {
            int counter = n;
            while (n != 0)
            {
                parentheses.Append("(");
                n--;
            }
            while (counter != 0)
            {
                parentheses2.Append(")");
                counter--;
            }
        }

        public bool IsValidParentheses2(string parentheses)
        {
            Queue<char> q = new Queue<char>();
            for (int i = 0; i < parentheses.Length; i++)
            {
                char dequeued;
                if (parentheses[i] == '(')
                {
                    q.Enqueue(parentheses[i]);
                }
                if (parentheses[i] == ')')
                {
                    if (!q.TryDequeue(out dequeued))
                    {
                        return false;
                    }
                }
            }
            return true;
        }



        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //We use a currentNode to traverse.
            //We use the marker to tell us when our currentNode should stop. 
            ListNode currentNode = head;
            ListNode nodeMarker = head;

            //nodeMarker will go ahead of our current node. 
            // 1 <= n <= numberOfNodes
            //So we are guaranteed that n will never be above 0 when this while loop completes.
            while (nodeMarker != null)
            {
                //Marker moves ahead of our node.
                nodeMarker = nodeMarker.next;
                //Once the marker is n ahead of our current node, we start moving both together.
                //If [1,2,3,4,5] and n = 2, then we wait till our marker hits 4, and then start moving both together.
                //Once our marker hits 4, our current will start.
                //When our marker is null, our currentNode will be on 3.
                if (n < 0) currentNode = currentNode.next;
                n--;
            }

            //If n is exactly 0, that means the entire list was traversed. 
            //So if we had 5 nodes, [1,2,3,4,5]. This if statement accounts for n = 5, where we would need to remove the head.
            if (n == 0) head = head.next;
            //Any other condition we return whatever is next from the marker. 
            //Overwrite the currentNode.next to be the one after the next node.
            //From the example in the while loop, where n = 2, our currentNode landed on 3.
            //So 3.next would be 4, and we want 3.next to be 5, since we are deleting 4 on n=2.
            else currentNode.next = currentNode.next.next;

            return head;
        }




    }
}
