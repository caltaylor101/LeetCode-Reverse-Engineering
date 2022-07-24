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
    internal class ReverseEngineering
    {
        //This list is added as private outside both functions so both may access it.
        private IList<string> result = new List<string>();

        public IList<string> GenerateParenthesis(int n)
        {
            //Call the recurse function
            BuildParenthesis(new StringBuilder(), n, n);

            return result;
        }

        public void BuildParenthesis(StringBuilder para, int leftPara, int rightPara)
        {
            if (rightPara == 0)
            {
                //Step4: Add the string to the result list.
                result.Add(para.ToString());
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
                        BuildParenthesis(para, leftPara, rightPara-1);
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

            for (int i = 0; i < halfParentheses1.Length; i ++)
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
