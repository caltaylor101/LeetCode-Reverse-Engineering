using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            for (int i = 0; i < haystack.Length && haystack.Length -i -1 < needle.Length ; i++)
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

    }
}
