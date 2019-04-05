using System;
using System.Collections.Generic;
using Demo.LeetCode.Algorithms;
using Demo.LeetCode.Algorithms.Models;

namespace LeetCode.Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LeetCode


            #region 1. Two Sum

            foreach (var i in Solutions.TwoSum(new int[] { -1, 5, 11, 15 }, 10))
            {
                Console.WriteLine(i);
            }

            #endregion

            #region 7. Reverse Integer

            Console.WriteLine(Solutions.Reverse(123) == 321);
            Console.WriteLine(Solutions.Reverse(-123) == -321);
            Console.WriteLine(Solutions.Reverse(120) == 21);
            Console.WriteLine(Solutions.Reverse(int.MaxValue) == 0);

            #endregion

            #region 13. Roman to Integer

            Console.WriteLine(Solutions.RomanToInt("III") == 3);
            Console.WriteLine(Solutions.RomanToInt("IV") == 4);
            Console.WriteLine(Solutions.RomanToInt("IX") == 9);
            Console.WriteLine(Solutions.RomanToInt("LVIII") == 58);
            Console.WriteLine(Solutions.RomanToInt("MCMXCIV") == 1994);

            #endregion

            #region 14. Longest Common Prefix

            Console.WriteLine(Solutions.GetLongestCommonPrefix(new[] { "flower", "flow", "flight" }) == "fl");
            Console.WriteLine(Solutions.GetLongestCommonPrefix(new[] { "dog", "racecar", "car" }) == "");

            #endregion

            #region 20. Valid Parentheses

            Console.WriteLine(Solutions.IsValidParentheses("()"));
            Console.WriteLine(Solutions.IsValidParentheses("()[]{}"));
            Console.WriteLine(!Solutions.IsValidParentheses("(]"));
            Console.WriteLine(!Solutions.IsValidParentheses("([)]"));
            Console.WriteLine(Solutions.IsValidParentheses("{[]}"));

            #endregion

            #region 21.  Merge Two Sorted Lists

            Console.WriteLine(Solutions.MergeTwoSortedList(new ListNode(1, new ListNode(2, new ListNode(4))), new ListNode(1, new ListNode(3, new ListNode(4)))).Equals(new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(4))))))));

            #endregion

            #region 53. Maximum Subarray

            Console.WriteLine(Solutions.MaxSubArray(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }) == 6);

            #endregion

            #region 70. Climbing Stairs

            Console.WriteLine(Solutions.ClimbStairs(2) == 2);
            Console.WriteLine(Solutions.ClimbStairs(3) == 3);

            #endregion

            #region 101. Symmetric Tree

            Console.WriteLine(Solutions.IsSymmetric(new TreeNode(1, new TreeNode(2, new TreeNode(3), new TreeNode(4)), new TreeNode(2, new TreeNode(4), new TreeNode(3)))));
            Console.WriteLine(!Solutions.IsSymmetric(new TreeNode(1, new TreeNode(2, null, new TreeNode(3)), new TreeNode(2, null, new TreeNode(3)))));
            Console.WriteLine(IsSymmetric(new TreeNode(1, new TreeNode(2, new TreeNode(3), new TreeNode(4)), new TreeNode(2, new TreeNode(4), new TreeNode(3)))));
            Console.WriteLine(!IsSymmetric(new TreeNode(1, new TreeNode(2, null, new TreeNode(3)), new TreeNode(2, null, new TreeNode(3)))));

            #endregion

            #region 141. Linked List Cycle
            Console.WriteLine(Solutions.HasCycle(new ListNode(3, new ListNode(2, new ListNode(0, new ListNode(-4))))));
            Console.WriteLine(Solutions.HasCycle(new ListNode(1, new ListNode(2))));
            Console.WriteLine(Solutions.HasCycle(new ListNode(1)));

            Console.WriteLine(Solutions.HasCycleViaHashSet(new ListNode(3, new ListNode(2, new ListNode(0, new ListNode(-4))))));
            Console.WriteLine(Solutions.HasCycleViaHashSet(new ListNode(1, new ListNode(2))));
            Console.WriteLine(!Solutions.HasCycleViaHashSet(new ListNode(1)));
            #endregion

            #region 160. Intersection of Two Linked Lists
            var result = Solutions.GetInterSectionModelBySameLength(
                new ListNode(4, new ListNode(1, new ListNode(8, new ListNode(4, new ListNode(5))))),
                new ListNode(5, new ListNode(0, new ListNode(1, new ListNode(8, new ListNode(4, new ListNode(5)))))));
            #endregion

            #region 169. Majority Element
            Console.WriteLine(Solutions.MajorityElement(new[] { 3, 2, 3 }) == 3);
            Console.WriteLine(Solutions.MajorityElement(new[] { 2, 2, 1, 1, 1, 2, 2 }) == 2);
            Console.WriteLine(MajorityElement(new[] { 3, 2, 3 }) == 3);
            Console.WriteLine(MajorityElement(new[] { 2, 2, 1, 1, 1, 2, 2 }) == 2);
            #endregion

            #region 198. House Robber

            Console.WriteLine(Solutions.Rob(new[] { 1, 2, 3, 1 }) == 4);
            Console.WriteLine(Solutions.Rob(new[] { 2, 7, 9, 3, 1 }) == 12);

            Console.WriteLine(Rob(new[] { 1, 2, 3, 1 }) == 4);
            Console.WriteLine(Rob(new[] { 2, 7, 9, 3, 1 }) == 12);

            #endregion

            #region 206. Reverse Linked List
            Console.WriteLine(ListNode.Equals(Solutions.ReverseList(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))))), new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1)))))));
            Console.WriteLine(ListNode.Equals(ReverseList(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))))), new ListNode(5, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1)))))));
            #endregion

            #region 226. Invert Binary Tree
            Console.WriteLine(TreeNode.IsSame(Solutions.InvertTree(new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(7, new TreeNode(6), new TreeNode(9)))), new TreeNode(4, new TreeNode(7, new TreeNode(9), new TreeNode(6)), new TreeNode(2, new TreeNode(3), new TreeNode(1)))));
            Console.WriteLine(TreeNode.IsSame(InvertTree(new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(7, new TreeNode(6), new TreeNode(9)))), new TreeNode(4, new TreeNode(7, new TreeNode(9), new TreeNode(6)), new TreeNode(2, new TreeNode(3), new TreeNode(1)))));
            #endregion

            #region 234. Palindrome Linked List
            Console.WriteLine(!Solutions.IsPalindrome(new ListNode(1, new ListNode(2))));
            Console.WriteLine(Solutions.IsPalindrome(new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))))));
            Console.WriteLine(!IsPalindrome(new ListNode(1, new ListNode(2))));
            Console.WriteLine(IsPalindrome(new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))))));
            #endregion

            #region 283. Move Zeroes
            Solutions.MoveZeroes(new[] { 0, 1, 0, 3, 12 });
            MoveZeroes(new[] { 0, 1, 0, 3, 12 });
            #endregion

            #region 437. Path Sum III
            Console.WriteLine(PathSum(new TreeNode(10, new TreeNode(5, new TreeNode(3, new TreeNode(3), new TreeNode(-2)), new TreeNode(2, null, new TreeNode(1))), new TreeNode(-3, null, new TreeNode(11))), 8) == 3);
            #endregion

            #region 438. Find All Anagrams in a String

            //Console.WriteLine(Solutions.FindAnagrams("abab", "ab"));
            //Console.WriteLine(Solutions.FindAnagrams("cbaebabacd", "abc"));

            Console.WriteLine(Solutions.FindAnagrams_My("abab", "ab"));
            Console.WriteLine(Solutions.FindAnagrams_My("cbaebabacd", "abc"));
            Console.WriteLine(Solutions.FindAnagrams_My("ababababab", "aab"));
            #endregion

            #region 448. Find All Numbers Disappeared in an Array
            Console.WriteLine(Solutions.FindDisappearedNumbers(new[] { 4, 3, 2, 7, 8, 2, 3, 1 }));
            Console.WriteLine(FindDisappearedNumbers(new[] { 4, 3, 2, 7, 8, 2, 3, 1 }));
            #endregion

            #region 461. Hamming Distance
            Console.WriteLine(Solutions.HammingDistance(1, 4) == 2);
            #endregion

            #region 538. Convert BST to Greater Tree

            Console.WriteLine(
                TreeNode.IsSame(Solutions.ConvertBstToGreaterTree(new TreeNode(5, new TreeNode(2), new TreeNode(13))), new TreeNode(18, new TreeNode(20), new TreeNode(13))));


            Console.WriteLine(Solutions.ConvertBstToGreaterTree(new TreeNode(5, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(13, new TreeNode(10), new TreeNode(17)))));
            #endregion

            #region 543. Diameter of Binary Tree
            Console.WriteLine(Solutions.DiameterOfBinaryTree(new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3))) == 3);
            #endregion

            #region 581. Shortest Unsorted Continuous Subarray
            Console.WriteLine(Solutions.FindUnsortedSubarray(new[] { 2, 6, 4, 8, 10, 9, 15 }) == 5);

            int[] subArr;
            Console.WriteLine(Solutions.FindUnsortSubArrary(new int[] { 2, 6, 4, 8, 10, 9, 15 }, out subArr) == 5);

            #endregion

            #region 617. Merge Two Binary Trees
            Console.WriteLine(TreeNode.Equals(Solutions.MergeTrees(new TreeNode(1, new TreeNode(3, new TreeNode(5), null), new TreeNode(2)), new TreeNode(2, new TreeNode(1, null, new TreeNode(4)), new TreeNode(3, null, new TreeNode(7)))), new TreeNode(3, new TreeNode(4, new TreeNode(5), new TreeNode(4)), new TreeNode(5, null, new TreeNode(7)))));
            #endregion

            #region 771. Jewels and Stones
            Console.WriteLine(Solutions.NumJewelsInStones("z", "ZZZ") == 0);
            Console.WriteLine(Solutions.NumJewelsInStones("aA", "aAAbbbb") == 3);
            #endregion

            #region 915. Partition Array into Disjoint Intervals

            var o915 = Solutions.PartitionDisjoint(new int[] { 5, 0, 3, 8, 6 });
            Console.WriteLine(o915 == 3);

            o915 = Solutions.PartitionDisjoint(new int[] { 1, 1, 1, 0, 6, 12 });
            Console.WriteLine(o915 == 4);
            #endregion

            #region 250. Count Univalue Subtrees

            Console.WriteLine(Solutions.CountUniValueSubtrees(new TreeNode(5,
                                  new TreeNode(1, new TreeNode(5), new TreeNode(5)),
                                  new TreeNode(5, null, new TreeNode(5)))) == 4);


            Console.WriteLine(Solutions.CountUniValueSubtrees(new TreeNode(1,
                                  new TreeNode(3, new TreeNode(4), new TreeNode(5)),
                                  new TreeNode(2, null, new TreeNode(6)))) == 3);
            #endregion

            Console.WriteLine(Solutions.NumUniqueEmails(new[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" }) == 2);

            Console.WriteLine(Solutions.TotalFruit(new[] { 1, 2, 1 }) == 3);
            Console.WriteLine(Solutions.TotalFruit(new[] { 0, 1, 2, 2 }) == 3);
            Console.WriteLine(Solutions.TotalFruit(new[] { 1, 2, 3, 2, 2 }) == 4);
            Console.WriteLine(Solutions.TotalFruit(new[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 }) == 5);

            #endregion
            Console.ReadKey();

        }

        private static int PathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return 0;
            }

            return PathSumFrom(root, sum) + PathSum(root.Left, sum) + PathSum(root.Right, sum);
        }

        private static int PathSumFrom(TreeNode node, int sum)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Val == sum
                ? 1
                : 0 + PathSumFrom(node.Left, sum - node.Val) + PathSumFrom(node.Right, sum - node.Val);
        }


        private static IList<int> FindDisappearedNumbers(int[] arr)
        {
            var result = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                var val = Math.Abs(arr[i]) - 1;
                if (arr[val] > 0)
                {
                    arr[val] = -arr[val];
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }


        private static void MoveZeroes(int[] arr)
        {
            var lastNonZero = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    arr[lastNonZero++] = arr[i];
                }
            }

            for (int i = lastNonZero; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
        }

        private static bool IsPalindrome(ListNode head)
        {
            ListNode temp = head;
            var stack = new Stack<ListNode>();

            while (temp != null)
            {
                stack.Push(temp);
                temp = temp.Next;
            }

            while (head != null)
            {
                if (stack.Count == 0 || head.Val != stack.Pop().Val)
                {
                    return false;
                }
                head = head.Next;
            }

            return true;
        }

        private static TreeNode InvertTree(TreeNode tree)
        {
            if (tree == null)
            {
                return null;
            }

            var left = InvertTree(tree.Right);
            var right = InvertTree(tree.Left);
            tree.Left = left;
            tree.Right = right;

            return tree;
        }


        private static ListNode ReverseList(ListNode head)
        {
            ListNode pre = null;
            ListNode cur = head;
            while (cur != null)
            {
                var tempNext = cur.Next;
                cur.Next = pre;
                pre = cur;
                cur = tempNext;
            }
            return pre;
        }

        private static int Rob(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            var pre1 = 0;
            var pre2 = 0;
            foreach (var i in arr)
            {
                var tmp = pre1;
                pre1 = Math.Max(pre2 + i, pre1);
                pre2 = tmp;
            }


            return pre1;
        }


        private static int MajorityElement(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentException("Invalid input");
            }
            var count = 0;
            var major = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (count == 0)
                {
                    count++;
                    major = arr[i];
                }
                else if (major == arr[i])
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }


            return major;
        }


        private static bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return false;
            }

            return IsMirror(root.Right, root.Left);
        }

        private static bool IsMirror(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
            {
                return true;
            }

            if (t1 == null || t2 == null)
            {
                return false;
            }

            return t1.Val == t2.Val && IsMirror(t1.Left, t2.Right) && IsMirror(t1.Right, t2.Left);
        }


        private static int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return Math.Max(MaxDepth(root.Left), MaxDepth(root.Right)) + 1;
        }


        private static bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Left == null && root.Right == null && root.Val == sum)
            {
                return true;
            }

            return HasPathSum(root.Left, sum - root.Val) || HasPathSum(root.Right, sum - root.Val);
        }
    }
}
