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
    }
}
