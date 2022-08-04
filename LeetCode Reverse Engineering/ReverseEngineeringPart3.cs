using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Reverse_Engineering
{
    internal class ReverseEngineeringPart3
    {
        /*private List<string> say = new List<string>() { "1" };
        private List<string> newSay = new List<string>() { };
        public string CountAndSay(int n)
        {
            while (n > 1)
            {
                int counter = 1;
                for (int i = 0; i < say.Count; i++)
                {
                    if(i+1 < say.Count && say[i] == say[i+1])
                    {
                        counter++;
                    }
                    else
                    {
                        newSay.Add(counter.ToString());
                        newSay.Add(say[i]);
                        counter = 1;
                    }
                }
                say = new List<string>(newSay);
                newSay.Clear();
                n--;
            }

            return new string(string.Join("", say));
        }*/

        
        public string CountAndSay2(int n)
        {
            //Initialize the base case.
            string say = "1";
            //A way to build strings.
            StringBuilder newSay = new StringBuilder();

            //We already have the base case set, so we want anything greater than 1.
            while (n > 1)
            {
                //Reset the counter every loop.
                int counter = 1;
                //Loop through the string.
                for (int i = 0; i < say.Length; i++)
                {
                    //Check to see if the next number is the same, if it is increase the counter and continue. 
                    if (i + 1 < say.Length && say[i] == say[i + 1]) counter++;
                    //Otherwise, we can add our counter and the current element. 
                    //Reset the counter and start again.
                    else
                    {
                        newSay.Append(counter.ToString() + say[i]);
                        counter = 1;
                    }
                }
                //Update say to the new string.
                say = newSay.ToString();
                //Clear the string builder.
                newSay.Clear();
                //Lower the iteration account.
                n--;
            }
            //Return the string. 
            return say;
        }

        public string CountAndSay(int n)
        {
            //This is our base case and where the recurse functions will start.
            if (n == 1) return "1";
            //This will call multiple functions till it reaches the base case. 
            string say = CountAndSay(n - 1);
            //Create a stringBuilder to return.
            StringBuilder newSay = new StringBuilder();
            int count = 1;

            //Basically the same logic as the iterative approach.
            for (int i = 0; i < say.Length; i++)
            {
                if (i + 1 < say.Length && say[i] == say[i + 1])
                {
                    count++;
                }
                else
                {
                    newSay.Append(count.ToString() + say[i]);
                    count = 1;
                }
            }
            //return the new string we created. 
            return newSay.ToString();
        }













        public void Rotate2(int[][] matrix)
        {
            List<int> rightValues = new List<int>();
            List<int> topValues = new List<int>();
            List<int> bottomValues = new List<int>();
            List<int> leftValues = new List<int>();

            int top = 0;
            int right = matrix[top].Length - 1;
            int bottom = matrix.Length - 1;
            int left = 0;



            while(top <= bottom)
            {
                for (int vertical = top; vertical <= right; vertical++)
                {
                    rightValues.Add(matrix[vertical][right]);
                }

                for (int horizontal = left; horizontal <= bottom; horizontal++)
                {
                    topValues.Add(matrix[top][horizontal]);
                }

                for (int horizontal = left; horizontal <= bottom; horizontal++)
                {
                    bottomValues.Add(matrix[bottom][horizontal]);
                }

                for (int vertical = top; vertical <= right; vertical++)
                {
                    leftValues.Add(matrix[vertical][left]);
                }

                //Add all top values to the right
                for (int vertical = top ; vertical <= right; vertical++)
                {
                    matrix[vertical][right] = topValues[vertical - top];
                }

                //Add all right values to the bottom, which needs to be done in reverse order.
                for (int horizontal = left; horizontal <= right; horizontal++)
                {
                    matrix[bottom][horizontal] = rightValues[right - horizontal];
                }

                //Add all bottom values to the left
                for (int vertical = top; vertical <= right; vertical++)
                {
                    matrix[vertical][left] = bottomValues[vertical - top];
                }

                //Add all left values to the top, which needs to be done in reverse order.
                for (int horizontal = left; horizontal <= right; horizontal++)
                {
                    matrix[top][horizontal] = leftValues[right - horizontal];
                }

                rightValues.Clear();
                bottomValues.Clear();
                leftValues.Clear();
                topValues.Clear();

                right--;
                bottom--;
                top++;
                left++;

            }
        }

        public void Rotate5(int[][] matrix)
        {
            int top = 0;
            int right = matrix[top].Length - 1;
            int bottom = matrix.Length - 1;
            int left = 0;

            while (top <= bottom)
            {
                
                //The counter allows us to iterate through each inner layer. 
                int counter = 0;
                for (int i = top; i < right; i++)
                {
                    //top left becomes bottom left
                    //top right becomes top left
                    //bottom right becomes top right
                    //bottom left becomes bottom right
                    (matrix[top][left + counter], matrix[top + counter][right], matrix[bottom][right - counter], matrix[bottom - counter][left]) = (matrix[bottom - counter][left], matrix[top][left + counter], matrix[top + counter][right], matrix[bottom][right - counter]);
                    //Since we change them all at the same time, we just spin around the matrix with the counter. 
                    counter++;
                }
                //The for loop stops once all 4 sides are changed.
                //Then we go to the inner layer and do it again. 
                top++;
                bottom--;
                left++;
                right--;
            }
        }


        public void Rotate3(int[][] matrix)
        {
            int top = 0;
            int right = matrix[top].Length - 1;
            int bottom = matrix.Length - 1;
            int left = 0;

            RecurseRotate(matrix, top, right, bottom, left);
        }

        private void RecurseRotate(int[][] matrix, int top, int right, int bottom, int left)
        {

            if (top > bottom) return;
            if (top <= bottom) RecurseRotate(matrix, top + 1, right - 1, bottom - 1, left + 1);

            int counter = 0;
                for (int i = top; i < right; i++)
                {
                    (matrix[top][left + counter], matrix[top + counter][right], matrix[bottom][right - counter], matrix[bottom - counter][left]) = (matrix[bottom - counter][left], matrix[top][left + counter], matrix[top + counter][right], matrix[bottom][right - counter]);
                    counter++;
                }
            return;
        }




        public void Rotate(int[][] matrix)
        {
            if (matrix == null) return;

            int low = 0;
            int high = matrix[0].Length - 1;

            while (high > low)
            {
                for (int i = 0; i <= high - low - 1; i++)
                {
                    int temp1 = matrix[low + i][high];
                    matrix[low + i][high] = matrix[low][low + i];

                    int temp2 = matrix[high][high - i];
                    matrix[high][high - i] = temp1;

                    temp1 = matrix[high - i][low];
                    matrix[high - i][low] = temp2;

                    matrix[low][low + i] = temp1;
                }

                low++;
                high--;
            }
        }




        //BFS solution
        public bool IsSameTree2(TreeNode p, TreeNode q)
        {
            //PreCheck to make sure p and q are worth traversing.
            if (p == null && q == null) return true;
            if (p == null && q != null || (p != null && q == null) || (p.val != q.val)) return false;

            //Queues so we can traverse both with BFS
            Queue<TreeNode> queue1 = new Queue<TreeNode>();
            Queue<TreeNode> queue2 = new Queue<TreeNode>();
            //Initializing the queues.
            queue1.Enqueue(p);
            queue2.Enqueue(q);

            //Temp nodes to traverse both trees
            TreeNode node1;
            TreeNode node2;

            //We try to dequeue, if nothing is in the queue then the while loop stops.
            //Otherwise, node1 becomes the Dequeued element.
            while (queue1.TryDequeue(out node1))
            {
                //If this fails to dequeue, then we return false because the both trees aren't equal. 
                if(!queue2.TryDequeue(out node2)) return false;
                //Null checks to make sure we have real values to continue wiht. 
                if (node1 == null && node2 != null || (node2 == null && node1 != null)) return false;

                if (node1 != null && node2 != null)
                {
                    //Make sure both values are the same.
                    if (node1.val != node2.val) return false;
                    //Setting up the next layer to be traversed
                    queue1.Enqueue(node1.left);
                    queue1.Enqueue(node1.right);

                    queue2.Enqueue(node2.left);
                    queue2.Enqueue(node2.right);
                    
                }
            }

            return true;
        }




        //DFS PreOrder solution
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            //Initial null checks
            if (q == null && p != null) return false;
            if (p == null && q != null) return false;

            //Verify one of the nodes exist to traverse
            if (p != null || q != null)
            {
                //If one left node doesn't equal the other, return false.
                if (p.val != q.val) return false;
                //Otherwise keep going down left
                if (!IsSameTree(p.left, q.left)) return false;
            }
            
            //Verify one of the nodes exists to traverse
            if (p != null || q != null)
            {
                //Verify the nodes are equal, otherwise return false. 
                if (p.val != q.val) return false;
                //Keep going right.
                if (!IsSameTree(p.right, q.right)) return false;
            }

            return true;
        }

        //Cool solution from leetcode
        /*public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (Equals(p, null) || Equals(q, null))
                return Equals(q, p);
            return Equals(p.val, q.val) && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }*/











        /*public bool IsSymmetric(TreeNode root)
        {
            Queue<TreeNode> leftq = new Queue<TreeNode>();
            Stack<TreeNode> rightq = new Stack<TreeNode>();

            if (Equals(root.left, null) && Equals(root.right, null)) return true;
            if (Equals(root.left, null) || Equals(root.right, null))
            {
                if (!Equals(root.left, root.right)) return false;
            }
            if (!Equals(root.left.val, root.right.val)) return false;

            leftq.Enqueue(root.left);
            rightq.Push(root.right);

            TreeNode currentLeft;
            TreeNode currentRight;

            while(leftq.TryDequeue(out currentLeft))
            {
                if(!rightq.TryPop(out currentRight)) return false;

                if(Equals(currentLeft, null) && !Equals(currentRight, null)) return false;
                if(!Equals(currentLeft, null) && Equals(currentRight, null)) return false;
                if(Equals(currentLeft.left, null) || Equals(currentRight.right, null))
                {
                    if (!Equals(currentLeft.left, currentRight.right)) return false;
                }
                if(Equals(currentLeft.right, null) || Equals(currentRight.left, null))
                {
                    if (!Equals(currentLeft.right, currentRight.left)) return false;
                }

                try
                {
                    leftq.Enqueue(currentLeft.left);
                    rightq.Push(currentRight.right);
                    if (!Equals(currentLeft.left.val, currentRight.right.val)) return false;
                }
                catch
                {
                    if (!Equals(currentLeft.left, currentRight.right)) return false;
                }

                try
                {
                    leftq.Enqueue(currentLeft.right);
                    rightq.Push(currentRight.left);
                    if (!Equals(currentLeft.right.val, currentRight.left.val)) return false;
                }
                catch
                {
                    if (!Equals(currentLeft.right, currentRight.left)) return false;
                }

            }

            return true;
        }*/










        public bool IsSymmetric2(TreeNode root)
        {
            //Queues to initialize the left and right branch traversals
            Queue<TreeNode> leftQ = new Queue<TreeNode>();
            Queue<TreeNode> rightQ = new Queue<TreeNode>();

            //null check to make sure we should continue
            if (Equals(root.left, null) && Equals(root.right, null)) return true;
            if (Equals(root.left, null) || Equals(root.right, null)) return false;

            //Initializing our queues.
            leftQ.Enqueue(root.left);
            rightQ.Enqueue(root.right);

            //Node variables to dequeue to.
            TreeNode currentLeft;
            TreeNode currentRight;

            //While leftQ can Dequeue something, which becomes the variable currentLeft.
            //If our Queue is empty, then this while loop ends.
            while (leftQ.TryDequeue(out currentLeft))
            {
                //If the right queue is empty, then they are not equal. 
                if (!rightQ.TryDequeue(out currentRight)) return false;
                //If both nodes are null, continue from the beginning of the loop. 
                if (Equals(currentLeft, null) && Equals(currentRight, null)) continue;
                //If one node is null then the tree is false
                if (Equals(currentLeft, null) || Equals(currentRight, null)) return false;
                //Since we did the null checks above, we can check the left and right value here.
                if (!Equals(currentLeft.val, currentRight.val)) return false;

                // After all our checks we add the left and right branches to our queues.
                // Left to right on the left queue
                // Right to left on the right queue
                leftQ.Enqueue(currentLeft.left);
                leftQ.Enqueue(currentLeft.right);

                rightQ.Enqueue(currentRight.right);
                rightQ.Enqueue(currentRight.left);
            }

            return true;
        }

        public bool IsSymmetric(TreeNode root)
        {
            return RecurseSymmetric(root.left, root.right);
        }

        public bool RecurseSymmetric(TreeNode left, TreeNode right)
        {
            //The checks to make sure each node is correct. 
            //Null checks are done first so the left.val and right.val doesn't error out.
            if (Equals(left, null) && Equals(right, null)) return true;
            if (Equals(left, null) || Equals(right, null)) return false;
            if (left.val != right.val) return false;

            //Check the left.left with the right.right
            if (!RecurseSymmetric(left.left, right.right)) return false;
            //Check the left.right with the right.left
            if (!RecurseSymmetric(left.right, right.left)) return false;

            //Otherwise return true
            return true;
        }









        //100% less memory
        //outer variable that the recursive function updates
        private int maxDepth = 0;
        public int MaxDepth2(TreeNode root)
        {
            //null check
            if (root == null) return 0;

            //Returns the maxDepth variable
            return RecurseDepth(root, 1); 
        }

        private int RecurseDepth(TreeNode root, int count)
        {
            if (root.left != null)
            {
                //Keep moving left and keep track of the count as you go
                RecurseDepth(root.left, count + 1);
            }

            if (root.right != null)
            {
                //Keep moving right and keep track of the count as you go
                RecurseDepth(root.right, count + 1);
            }

            //If maxDepth is lower than count, maxDepth = count. 
            return maxDepth = Math.Max(count, maxDepth); 
        }

        public int MaxDepth(TreeNode root)
        {
            //Null check
            if (root == null) return 0;
            //2 layers to count and traverse down the tree
            Queue<TreeNode> layer1 = new Queue<TreeNode>();
            Queue<TreeNode> layer2 = new Queue<TreeNode>();

            //Booleans to switch between Queue layers
            bool checkLayer1 = true;
            bool checkLayer2 = false;

            //Initializing the traversal. 
            layer1.Enqueue(root);

            //A node that can traverse down the tree
            TreeNode currentNode = null;

            //Initializing the count for what to return.
            int maxDepth = 1;

            while(layer1.Count > 0 || layer2.Count > 0)
            {
                //If checkLayer1 is true and layer1 Queue is empty
                if (checkLayer1 && !layer1.TryDequeue(out currentNode))
                {
                    //Count maxDepth
                    maxDepth++;
                    //Flip the boolean triggers
                    checkLayer1 = false;
                    checkLayer2 = true;
                    //Restart the loop because currentNode is currently null
                    continue;
                }
                //Otherwise, if checkLayer2 is true and layer2 Queue is empty, flip the boolean triggers
                if (checkLayer2 && !layer2.TryDequeue(out currentNode))
                {
                    maxDepth++;
                    checkLayer1 = true;
                    checkLayer2 = false;
                    //Restart the loop because currentNode is currently null
                    continue;
                }

                //If we are currently checking layer1, then we want to add the next layer to layer2 
                if (checkLayer1)
                {
                    //null checks before adding the node
                    if (currentNode.left != null) layer2.Enqueue(currentNode.left);
                    if (currentNode.right != null) layer2.Enqueue(currentNode.right);
                }

                //If we are currently checking layer2, then we want to add the next layer to layer1
                if (checkLayer2)
                {
                    //null checks before adding the node
                    if (currentNode.left != null) layer1.Enqueue(currentNode.left);
                    if (currentNode.right != null) layer1.Enqueue(currentNode.right);
                }

            }

            //Return the maxDepth.
            return maxDepth;
        }











        public TreeNode SortedArrayToBST(int[] nums)
        {
            //Return the recursive function.
            return RecurseBST(nums, 0, nums.Length - 1);
        }

        public TreeNode RecurseBST(int[] nums, int left, int right)
        {
            //If left crosses right return null;
            if (left > right) return null;
            //Calculate the mid
            int mid = (left + right) / 2;
            //The left side will always be to the left of mid. 
            //The right side is always to the right of mid. 
            //So we calculate the mid, and keep calculating the mid as far left as we can.
            //Then as far right as we can, and assign the nodes as we go. 
            TreeNode node = new TreeNode(nums[mid], RecurseBST(nums, left, mid - 1), RecurseBST(nums, mid + 1, right));
            return node;
        }
        public TreeNode RecurseBST2(int[] nums, int left, int right)
        {
            //If left crosses right return null;
            if (left > right) return null;
            //Calculate the mid
            int mid = (left + right) / 2;
            //The left side will always be to the left of mid. 
            //The right side is always to the right of mid. 
            //So we calculate the mid, and keep calculating the mid as far left as we can.
            //Then as far right as we can, and assign the nodes as we go. 
            TreeNode node = new TreeNode(nums[mid]);
            node.left = RecurseBST(nums, left, mid - 1);
            node.right = RecurseBST(nums, mid + 1, right);
            return node;
        }









        public IList<IList<int>> Generate(int numRows)
        {
            //Initialize the list with the first row.
            List<IList<int>> triangle = new List<IList<int>>() { new List<int>() { 1 } };
            //Return the first row if numRows is 1.
            if (numRows == 1) return triangle;

            //Continue this loop till we get to 1
            while (numRows > 1)
            {
                //Initialize the next row with 1, since every row starts with 1.
                List<int> nextRow = new List<int>() { 1 };

                //Get the last row of the triangle
                IList<int> lastRow = triangle[triangle.Count - 1];

                //Loop through the length of the last row.
                //We - 1 from the count because we are adding i+1 below.
                for (int i = 0; i < lastRow.Count - 1; i++)
                {
                    //Add the upper two elements from the last row, and add them to the next row.
                        nextRow.Add(lastRow[i] + lastRow[i + 1]);
                }

                //Every row ends with 1.
                nextRow.Add(1);
                //Add the row to the triangle.
                triangle.Add(nextRow);
                //Decrease numRows and continue.
                numRows--;
            }

            return triangle;
        }








    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
