using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LeetCode.Algorithms.Models
{
    public class ListNode
    {
        public int Val { get; set; }

        public ListNode Next { get; set; }

        public ListNode(int val)
        {
            Val = val;
        }

        public ListNode(int val, ListNode next)
        {
            Val = val;
            Next = next;
        }

        public override bool Equals(object obj)
        {
            var otherListNode = obj as ListNode;
            if (otherListNode == null)
            {
                return false;
            }

            return otherListNode.Val == Val &&
                   ((otherListNode.Next == null && Next == null) || (Next!=null && Next.Equals(otherListNode.Next) || otherListNode.Next!=null && otherListNode.Next.Equals(Next)) );
        }


        public static bool Equals(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                return true;
            }

            if (l1 == null || l2 == null)
            {
                return false;
            }
            return l1.Val == l2.Val &&
                   ((l1.Next == null && l2.Next == null) || (l2.Next != null && l2.Next.Equals(l1.Next) || l1.Next != null && l1.Next.Equals(l2.Next)));
        }

    }
}
