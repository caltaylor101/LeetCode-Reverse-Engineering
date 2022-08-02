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








    }
}
