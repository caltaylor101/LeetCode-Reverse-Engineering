using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Reverse_Engineering
{
    internal class ReverseEngineeringPart4
    {
public void DeleteNode2(ListNode node)
        {
            ListNode follower = node;
            int count = 0;
            while(node != null)
            {
                if (node.next == null)
                {
                    follower.next = null;
                    node = null;
                }
                else
                {
                    node.val = node.next.val;
                    node = node.next;
                }
                    
                if (count >= 1) follower = follower.next;

                count++;

            }
        }


        public void DeleteNode(ListNode node)
        {
            //Follower that traverses behind the node.
            ListNode follower = node;
            //A constraint is that the node will never be the tail, so this is always available. 
            node = node.next;
            while (node != null)
            {
                //Change the follower value first.
                follower.val = follower.next.val;
                //If this is null, then we are at the tail and want the follower to be the new tail. 
                if (node.next == null)
                {
                    follower.next = null;
                    break;
                }
                //traverse both nodes.
                follower = follower.next;
                node = node.next;
            }
        }



        public bool IsAnagram2(string s, string t)
        {
            //Put the characters in t to a list O(n)
            List<char> tList = t.ToList();
            //Sort the list O(n log n).
            tList.Sort();
            if (t.Length != s.Length) return false;

            //Loop through the string O(n)
            for(int i = 0; i < s.Length; i++)
            {
                //BinarySearch the list O(log n)
                int index = tList.BinarySearch(s[i]);
                //Binary search returns a negative index if it can't find it.
                if (index < 0) return false;
                //Remove the element O(n)
                tList.RemoveAt(index);
            }

            return true;
        }

        public bool IsAnagram3(string s, string t)
        {
            if (s.Length != t.Length) return false;
            Dictionary<int, int> tDict = new Dictionary<int, int>();
            //Add each element of t (or s) into the dictionary.
            foreach (var c in t)
            {
                //Try to add it, if it fails then it already exists,
                //therefore we can add 1 to where it exists in the dictionary. 
                if(!tDict.TryAdd(c, 1))
                {
                    tDict[c]++;
                }
            }

            foreach (var c in s)
            {
                //Check every character to see if it exists in the dictionary.
                if(tDict.ContainsKey(c))
                {
                    if (tDict[c] == 0) return false;
                    //Remove a count of it. 
                    tDict[c]--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsAnagram4(string s, string t)
        {
            if (s.Length != t.Length) return false;
            //Put both into a charArray
            char[] sArray = s.ToCharArray();
            char[] tArray = t.ToCharArray();
            //Sort both arrays
            Array.Sort(sArray);
            Array.Sort(tArray);

            for (int i = 0; i < sArray.Length; i++)
            {
                //Compare both arrays side by side
                if (sArray[i] != tArray[i]) return false;
            }

            return true;
        }















        public string ValidIPAddress2(string queryIP)
        {
            if (IsIPV4Address2(new string[] { queryIP })) return "IPv4";
            if (IsIPV6Address2(new string[] { queryIP })) return "IPv6";
            return "Neither";
        }

        public bool IsIPV4Address2(string[] lines)
        {
            var arr = new List<string>();
            foreach (var line in lines)
            {
                arr = line.Split('.').ToList();
                if (arr.Count != 4) return false;
                foreach (var s in arr)
                {
                    if (s.Length == 0 || (s[0] == '0' && s.Length != 1)) return false;
                    try
                    {
                        if (Convert.ToInt32(s) < 0 || Convert.ToInt32(s) > 255) return false;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        

        public bool IsIPV6Address2(string[] lines)
        {
            var arr = new List<string>();
            foreach (var line in lines)
            {
                arr = line.Split(':').ToList();
                if (arr.Count != 8) return false;
                foreach (var s in arr)
                {
                    if (s.Length <= 0 || s.Length > 4) return false;
                    foreach (var c in s)
                    {
                        if (!((c >= 'a' && c <= 'f')
                            ||
                            (c >= 'A' && c <= 'F')
                            ||
                            (char.IsDigit(c)))) return false; 
                    }
                }
            }

            return true;
        }

        public void IsIPV4Address(string[] lines)
        {
            var arr = new List<string>();
            foreach (var line in lines)
            {
                arr = line.Split('.').ToList();
                if (arr.Count != 4)
                {
                    Console.WriteLine("Neither");
                    continue;
                }

                foreach (var s in arr)
                {
                    if (s.Length == 0 || (s[0] == '0' && s.Length != 1))
                    {
                        Console.WriteLine("Neither");
                        goto End;
                    }

                    try
                    {
                        if (Convert.ToInt32(s) < 0 || Convert.ToInt32(s) > 255)
                        {
                            Console.WriteLine("Neither");
                            goto End;
                        };
                    }
                    catch
                    {
                        Console.WriteLine("Neither");
                        goto End;
                    }

                }
                Console.WriteLine("IPv4");
                End:
                continue;
            }

            return;
        }

        

        public void IsIPV6Address(string[] lines)
        {
            var arr = new List<string>();
            foreach (var line in lines)
            {
                arr = line.Split(':').ToList();
                if (arr.Count != 8)
                {
                    Console.WriteLine("Neither");
                    continue;
                }

                foreach (var s in arr)
                {
                    if (s.Length <= 0 || s.Length > 4)
                    {
                        Console.WriteLine("Neither");
                        break;
                    }
                        
                    foreach (var c in s)
                    {
                        if (!((c >= 'a' && c <= 'f')
                            ||
                            (c >= 'A' && c <= 'F')
                            ||
                            (char.IsDigit(c))))
                        {
                            Console.WriteLine("Neither");
                            goto End;
                        }
                    }
                }
            Console.WriteLine("IPv6");

            End:
                continue;
            }
            return;
        }


        public bool CanJump(int[] nums)
        {
            // Reference to the max jump
            int maxJump = 0;
            // Reference to the array
            int numsLength = nums.Length - 1;

            //Check if maxJump is >= i, or if it is less than numsLength
            //if maxJump is less than i, then it's impossible to move further down the array. 
            //if maxJump is greater than numsLength, then we reached our goal. 
            for (int i =0; maxJump >= i && maxJump < numsLength; i++)
            {
                // if index + nums[i] > maxJump, then we set max jump to that number. 
                // This way we know it is possible to continue moving. 
                if (i + nums[i] > maxJump)
                {
                    maxJump = i + nums[i]; 
                }
            }

            //if max jump is greater than numsLength, then we reached the end. 
            return maxJump >= numsLength; 
        }























    }
}
