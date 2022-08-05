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


























    }
}
