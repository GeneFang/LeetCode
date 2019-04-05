using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using Demo.LeetCode.Algorithms.Models;

namespace Demo.LeetCode.Algorithms
{
    public static class Solutions
    {
        /// <summary>
        /// 1. Two Sum
        /// https://leetcode.com/problems/two-sum/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] arr, int target)
        {
            var dic = new Dictionary<int,int>();
            for (int i = 0; i < arr.Length; i++)
            {
                var anotherEle = target - arr[i];
                if (dic.ContainsKey(anotherEle))
                {
                    return new int[]{dic[anotherEle],i};
                }

                if (!dic.ContainsKey(arr[i]))
                {
                    dic.Add(arr[i],i);
                }
            }
            throw new ArgumentException("No elements found for target");
        }

        /// <summary>
        /// 7. Reverse Integer
        /// https://leetcode.com/problems/reverse-integer/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            long result = 0;
            while (x!=0)
            {
                result = result * 10 + x % 10;
                x = x / 10;
            }

            return result > int.MaxValue || result < int.MinValue ? 0 : (int) result;
        }

        /// <summary>
        /// 13. Roman to Integer
        /// https://leetcode.com/problems/roman-to-integer/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int RomanToInt(string s)
        {
            var sum = 0;
            if (s.Contains("IV"))
            {
                sum -= 2;
            }
            if(s.Contains("IX"))
            {
                sum -= 2;
            }
            if (s.Contains("XL"))
            {
                sum -= 20;
            }
            if (s.Contains("XC"))
            {
                sum -= 20;
            }
            if (s.Contains("CD"))
            {
                sum -= 200;
            }
            if (s.Contains("CM"))
            {
                sum -= 200;
            }


            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'I')
                {
                    sum += 1;
                }
                else if (s[i] == 'V')
                {
                    sum += 5;
                }
                else if (s[i] == 'X')
                {
                    sum += 10;
                }
                else if (s[i] == 'L')
                {
                    sum += 50;
                }
                else if (s[i] == 'C')
                {
                    sum += 100;
                }
                else if (s[i] == 'D')
                {
                    sum += 500;
                }
                else if (s[i] == 'M')
                {
                    sum += 1000;
                }
            }


            return sum;
        }

        /// <summary>
        /// 14. Longest Common Prefix
        /// https://leetcode.com/problems/longest-common-prefix/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string GetLongestCommonPrefix(string[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return string.Empty;
            }

            var pre = arr[0];
            var i = 0;
            while (i < arr.Length)
            {
                while (!arr[i].Contains(pre))
                {
                    pre = pre.Substring(0, pre.Length - 1);
                }
                i++;
            }

            return pre;
        }

        /// <summary>
        /// 20. Valid Parentheses
        /// https://leetcode.com/problems/valid-parentheses/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValidParentheses(string s)
        {
            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (ParenthesesPair.ContainsKey(c))
                {
                    var key = stack.Count == 0 ? '#' : stack.Pop();
                    if (key != ParenthesesPair[c])
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
                
            }

            return stack.Count == 0;
        }

        private static readonly Dictionary<char,char> ParenthesesPair = new Dictionary<char, char>()
        {
            {')','(' },
            {']','[' },
            {'}','{' }
        };


        /// <summary>
        /// 21. Merge Two Sorted Lists
        /// https://leetcode.com/problems/merge-two-sorted-lists/
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoSortedList(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            if (l1.Val<l2.Val)
            {
                l1.Next = MergeTwoSortedList(l1.Next, l2);
                return l1;
            }

            l2.Next = MergeTwoSortedList(l1, l2.Next);
            return l2;
            
        }

        /// <summary>
        /// 53. Maximum Subarray
        /// https://leetcode.com/problems/maximum-subarray/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int MaxSubArray(int[] arr)
        {
            var dp = new int[arr.Length];
            dp[0] = arr[0];
            var max = dp[0];
            for (var i = 1; i < arr.Length; i++)
            {
                dp[i] = arr[i] + (dp[i - 1] > 0 ? dp[i - 1] : 0);
                max = Math.Max(max, dp[i]);
            }

            return max;
        }

        /// <summary>
        /// https://leetcode.com/problems/climbing-stairs/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int ClimbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            var dp = new int[n+1];
            dp[1] = 1;
            dp[2] = 2;
            for (var i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        /// <summary>
        /// https://leetcode.com/problems/symmetric-tree/
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static bool IsSymmetric(TreeNode tree)
        {
            return IsMirror(tree, tree);
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

        /// <summary>
        /// https://leetcode.com/problems/maximum-depth-of-binary-tree/
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        public static int MaxDepth(TreeNode tree)
        {
            if (tree == null)
            {
                return 0;
            }

            return 1 + Math.Max(MaxDepth(tree.Left), MaxDepth(tree.Right));
        }

        /// <summary>
        /// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] prices)
        {
            if (prices==null || prices.Length == 0)
            {
                return 0;
            }

            var min = prices[0];
            var profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                profit = Math.Max(profit, prices[i] - min);
                min = Math.Min(min, prices[i]);
            }

            return profit;
        }

        /// <summary>
        /// https://leetcode.com/problems/single-number/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int SingleNumber(int[] arr)
        {
            var s = 0;
            foreach (var t in arr)
            {
                s ^= t;
            }

            return s;
        }

        /// <summary>
        /// https://leetcode.com/problems/intersection-of-two-linked-lists/
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public static ListNode GetInterSectionModel(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
            {
                return null;
            }

            while (!Equals(headA, headB))
            {
                headA = headA == null ? headB : headA.Next;
                headB = headB == null ? headA : headB.Next;
            }

            return headA;
        }

        public static ListNode GetInterSectionModelBySameLength(ListNode headA, ListNode headB)
        {
            int lenA = GetLength(headA), lenB = GetLength(headB);
            // move headA and headB to the same start point
            while (lenA > lenB)
            {
                headA = headA.Next;
                lenA--;
            }
            while (lenA < lenB)
            {
                headB = headB.Next;
                lenB--;
            }
            // find the intersection until end
            while (!ListNode.Equals(headA,headB))
            {
                headA = headA.Next;
                headB = headB.Next;
            }
            return headA;
        }
        private static int GetLength(ListNode node)
        {
            int length = 0;
            while (node != null)
            {
                node = node.Next;
                length++;
            }
            return length;
        }


        /// <summary>
        /// https://leetcode.com/problems/majority-element/
        /// https://www.zhihu.com/question/49973163/answer/235921864
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int MajorityElement(int[] arr)
        {
            int major = arr[0], count = 1;
            for (var i = 1; i < arr.Length; i++)
            {
                if (count == 0)
                {
                    count++;
                    major = arr[i];
                }else if (major == arr[i])
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
        
        
        /// <summary>
        /// https://leetcode.com/problems/linked-list-cycle/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            var walker = head;
            var runner = head;
            while (runner.Next!=null && runner.Next.Next!=null)
            {
                walker = walker.Next;
                runner = runner.Next.Next;
                if (walker == runner)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool HasCycleViaHashSet(ListNode head)
        {
            var nodesSeen = new HashSet<ListNode>();
            while (head!=null)
            {
                if (nodesSeen.Contains(head))
                {
                    return true;
                }

                nodesSeen.Add(head);

                head = head.Next;
            }


            return false;
        }

        public static int NumUniqueEmails(string[] emails)
        {
            var actualEmails = new HashSet<string>();

            for (int i = 0; i < emails.Length; i++)
            {
                var emailNames = emails[i].Split('@');
                if (emailNames.Length == 2)
                {
                    var actualLocalNames = emailNames[0].Split('+');
                    if (actualLocalNames.Length>0)
                    {
                        var localName = actualLocalNames[0].Replace(".","");
                        var actualEmail = localName+"@"+emailNames[1];
                        if (!actualEmails.Contains(actualEmail))
                        {
                            actualEmails.Add(actualEmail);
                        }
                    }
                }
            }

            return actualEmails.Count;
        }

        /// <summary>
        /// https://leetcode.com/problems/house-robber/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int Rob(int[] arr)
        {
            var rob = 0;
            var notRob = 0;
            foreach (var t in arr)
            {
                var curRob = notRob + t;
                notRob = Math.Max(notRob, rob);
                rob = curRob;
            }

            return Math.Max(rob, notRob);
        }

        /// <summary>
        /// https://leetcode.com/problems/reverse-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode ReverseList(ListNode head)
        {
            ListNode pre = null;
            var cur = head;
            while (cur != null)
            {
                var nextTemp = cur.Next;
                cur.Next = pre;
                pre = cur;
                cur = nextTemp;
            }

            return pre;
        }

        /// <summary>
        /// https://leetcode.com/problems/invert-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            var right = InvertTree(root.Right);
            var left = InvertTree(root.Left);
            root.Left = right;
            root.Right = left;

            return root;
        }

        /// <summary>
        /// https://leetcode.com/problems/palindrome-linked-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool IsPalindrome(ListNode head)
        {
            ListNode fast = head, slow = head;
            while (fast?.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            if (fast!=null)
            {
                slow = slow.Next;
            }

            slow = ReverseList(slow);
            fast = head;

            while (slow!=null)
            {
                if (fast.Val!=slow.Val)
                {
                    return false;
                }

                fast = fast.Next;
                slow = slow.Next;
            }

            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/move-zeroes/
        /// </summary>
        /// <param name="arr"></param>
        public static void MoveZeroes(int[] arr)
        {
            var lastNonZeroFoundAt = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]!=0)
                {
                    arr[lastNonZeroFoundAt++] = arr[i];
                }
            }

            for (int i = lastNonZeroFoundAt; i < arr.Length; i++)
            {
                arr[i] = 0;
            }
        }


        public static int PathSum(TreeNode root, int sum)
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

            return (node.Val == sum ? 1 : 0) + PathSumFrom(node.Left, sum - node.Val) +
                   PathSumFrom(node.Right, sum - node.Val);
        }

        /// <summary>
        /// https://leetcode.com/problems/find-all-anagrams-in-a-string/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        public static List<int> FindAnagrams_My(string s, string p)
        {
            var result = new List<int>();
            var anagrams = new Dictionary<char, int>();
            foreach (var an in p)
            {
                if (anagrams.ContainsKey(an))
                {
                    anagrams[an] = anagrams[an] + 1;
                }
                else
                {
                    anagrams.Add(an, 1);
                }
            }

            for (int i = 0; i < s.Length - p.Length + 1; i++)
            {
                var ans = new Dictionary<char, int>();
                for (int j = i; j < p.Length + i; j++)
                {
                    if (!anagrams.ContainsKey(s[j]))
                    {
                        break;
                    }

                    if (ans.ContainsKey(s[j]))
                    {
                        ans[s[j]] = ans[s[j]] - 1;
                    }
                    else
                    {
                        ans.Add(s[j], anagrams[s[j]] - 1);
                    }
                }

                if (ans.Count == anagrams.Count && ans.Keys.All(k => ans[k] == 0))
                {
                    result.Add(i);
                }
            }

            return result;

        }

        /// <summary>
        /// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static IList<int> FindDisappearedNumbers(int[] arr)
        {
            var ret = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                var val = Math.Abs(arr[i]) - 1;
                if (arr[val]>0)
                {
                    arr[val] = -arr[val];
                }
            }


            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]>0)
                {
                    ret.Add(i+1);
                }
            }


            return ret;
        }

        /// <summary>
        /// https://leetcode.com/problems/hamming-distance/
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int HammingDistance(int x, int y)
        {
            var xor = x ^ y;
            var n = 0;

            while (xor>0)
            {
                xor = xor & (xor - 1);
                n++;
            }


            return n;
        }

        /// <summary>
        /// https://leetcode.com/problems/convert-bst-to-greater-tree/
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static TreeNode ConvertBstToGreaterTree(TreeNode tree)
        {
          
            var sum = 0;
            return ConvertBst(tree, ref sum);
        }

        private static TreeNode ConvertBst(TreeNode node, ref int sum)
        {
            if (node == null)
            {
                return null;
            }
            ConvertBst(node.Right, ref sum);
            sum += node.Val;
            node.Val = sum;
            ConvertBst(node.Left, ref sum);

            return node;
        }

        /// <summary>
        /// https://leetcode.com/problems/diameter-of-binary-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int DiameterOfBinaryTree(TreeNode root)
        {
            var umberOfNodes = 0;
            MaxDepth(root, ref umberOfNodes);
            return umberOfNodes;
        }

        private static int MaxDepth(TreeNode node,ref int max)
        {
            if (node == null)
            {
                return 0;
            }

            var left = MaxDepth(node.Left,ref max);
            var right = MaxDepth(node.Right, ref max);
            max = Math.Max(max, left + right);

            return Math.Max(left, right) + 1;
        }

        public static bool IsSubtree(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
            {
                return false;
            }

            if (IsSame(t1,t2))
            {
                return true;
            }

            return IsSubtree(t1.Left, t2) || IsSubtree(t1.Right, t2);
        }

        public static bool IsSame(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2==null)
            {
                return true;
            }

            if (t1 == null || t2 == null)
            {
                return false;
            }

            return t1.Val == t2.Val && IsSame(t1.Left, t2.Left) && IsSame(t1.Right, t2.Right);
        }

        /// <summary>
        /// https://leetcode.com/problems/shortest-unsorted-continuous-subarray/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindUnsortedSubarray(int[] arr)
        {
            int min = int.MaxValue, max = int.MinValue;

            var flag = false;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i]<arr[i-1])
                {
                    flag = true;
                }

                if (flag)
                {
                    min = Math.Min(arr[i], min);
                }
            }


            flag = false;
            for (int i = arr.Length - 2; i >=0 ; i--)
            {
                if (arr[i]>arr[i+1])
                {
                    flag = true;
                }

                if (flag)
                {
                    max = Math.Max(max, arr[i]);
                }
            }

            int l, r;
            for (l  = 0; l < arr.Length; l++)
            {
                if (min<arr[l])
                {
                    break;
                }
            }

            for (r = arr.Length-2; r >= 0; r--)
            {
                if (max>arr[r])
                {
                    break;
                }
            }

            return r - l< 0 ? 0 : r - l + 1;
        }

        public static int FindUnsortSubArrary(int[] arr, out int[] subArr)
        {
            int min = int.MaxValue, max = int.MinValue;
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i]>arr[i+1])
                {
                    min = Math.Min(min, arr[i + 1]);
                }
            }

            for (int i = arr.Length-1; i > 0 ; i--)
            {
                if (arr[i]<arr[i-1])
                {
                    max = Math.Max(max, arr[i - 1]);
                }
            }

            int l, r = 0;
            for (l = 0; l < arr.Length; l++)
            {
                if(min<arr[l])
                    break;
            }

            for (r  = arr.Length-1; r >= 0; r--)
            {
                if (max > arr[r])
                {
                    break;
                }
            }

            subArr = null;
            if (r - l < 0)
            {
                return 0;
            }

            subArr = new int[r-l+1];
            for (int i = 0; i <= r-l; i++)
            {
                subArr[i] = arr[i + l];
            }

            return subArr.Length;
        }

        /// <summary>
        /// https://leetcode.com/problems/merge-two-binary-trees/
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
            {
                return t2;
            }

            if (t2 == null)
            {
                return t1;
            }

            t1.Val = t1.Val + t2.Val;
            var left = MergeTrees(t1.Left, t2.Left);
            var right = MergeTrees(t1.Right, t2.Right);
            t1.Left = left;
            t1.Right = right;
            return t1;
        }

        /// <summary>
        /// https://leetcode.com/problems/jewels-and-stones/
        /// </summary>
        /// <param name="j"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int NumJewelsInStones(string j, string s)
        {
            var jewels = new HashSet<char>();
            for (int i = 0; i < j.Length; i++)
            {
                if (!jewels.Contains(j[i]))
                {
                    jewels.Add(j[i]);
                }
            }

            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (jewels.Contains(s[i]))
                {
                    count++;
                }
            }

            return count;
        }


        public static int TotalFruit(int[] tree)
        {
            
            var fruitAmount = 0;

            for (int i = 0; i < tree.Length; i++)
            {
                var basket1 = new HashSet<int>();
                var basket2 = new HashSet<int>();
                var curFruitAmout = 1;
                basket1.Add(tree[i]);
                for (int j = i+1; j < tree.Length; j++)
                {
                    if (basket1.Contains(tree[j]))
                    {
                        curFruitAmout++;
                    }
                    else if(basket2.Contains(tree[j]))
                    {
                        curFruitAmout++;
                    }
                    else if(basket2.Count == 0)
                    {
                        basket2.Add(tree[j]);
                        curFruitAmout++;
                    }
                    else
                    {
                        break;
                    }
                }

                fruitAmount = Math.Max(curFruitAmout, fruitAmount);
            }

            return fruitAmount;
        }

        /// <summary>
        /// 915. Partition Array into Disjoint Intervals
        /// https://leetcode.com/problems/partition-array-into-disjoint-intervals/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int PartitionDisjoint(int[] arr)
        {
            var n = arr.Length;
            var maxLeft = new int[n];
            var minRight = new int[n];

            var m = arr[0];
            for (int i = 0; i < n; i++)
            {
                m = Math.Max(m, arr[i]);
                maxLeft[i] = m;
            }

            m = arr[n - 1];
            for (int i = n-1; i >=0; i--)
            {
                m = Math.Min(m, arr[i]);
                minRight[i] = m;
            }

            for (int i = 1; i < n; i++)
            {
                if (maxLeft[i-1]<=minRight[i])
                {
                    return i;
                }
            }

            return 0;
        }


        public static IList<int> PreOrderTraversalTreeViaRecursive(TreeNode root)
        {
            var result = new List<int>();
            if (root ==null)
            {
                return result;
            }
            result.Add(root.Val);
            result.AddRange(PreOrderTraversalTreeViaRecursive(root.Left));
            result.AddRange(PreOrderTraversalTreeViaRecursive(root.Right));
            return result;
        }

        public static IList<int> PreOrderTraversalTreeViaIterative(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
            {
                return result;
            }
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count!=0)
            {
                var visiting = stack.Pop();
                result.Add(visiting.Val);
                if (visiting.Right!=null) 
                {
                    stack.Push(visiting.Right);
                }
                if (visiting.Left != null)
                {
                    stack.Push(visiting.Left);
                }
            }

            return result;
        }



        public static IList<int> InOrderTraversalTreeViaRecursive(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
            {
                return result;
            }

            result.AddRange(InOrderTraversalTreeViaRecursive(root.Left));
            result.Add(root.Val);
            result.AddRange(InOrderTraversalTreeViaRecursive(root.Right));
            return result;
        }

        public static IList<int> InOrderTraversalTreeViaIterative(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
            {
                return result;
            }
            var stack = new Stack<TreeNode>();
            var cur = root;
            while (cur != null || stack.Count != 0)
            {
                if(cur != null)
                {
                    stack.Push(cur);
                    cur = cur.Left;
                }
                else
                {
                    cur = stack.Pop();
                    result.Add(cur.Val);
                    cur = cur.Right;
                }

              
            }

            return result;
        }


        public static IList<int> PostOrderTraversalTreeViaRecursive(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
            {
                return result;
            }

            result.AddRange(PostOrderTraversalTreeViaRecursive(root.Left));
            result.AddRange(PostOrderTraversalTreeViaRecursive(root.Right));
            result.Add(root.Val);

            return result;
        }


        public static IList<int> PostOrderTraversalTreeViaIterative(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
            {
                return result;
            }
           
            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count!=0)
            {
                var cur = stack.Pop();
                result.Add(cur.Val);
                if (cur.Left!=null)
                {
                    stack.Push(cur.Left);
                }

                if (cur.Right!=null)
                {
                    stack.Push(cur.Right);
                }
            }

            result.Reverse(0, result.Count);
            return result;
        }

        public static IList<IList<int>> LevelOrderTree(TreeNode root)
        {
            
            var result = new List<IList<int>>();
            GetLevels(root,0,ref result);
            return result;
        }

        private static void GetLevels(TreeNode node,int level,ref List<IList<int>> result)
        {
            if (node == null)
            {
                return;
            }
            
            if (level>=result.Count)
            {
                result.Add(new List<int>());
            }
            result[level].Add(node.Val);
            GetLevels(node.Left,level+1,ref result);
            GetLevels(node.Right,level+1,ref result);
        }


        public static int CountUniValueSubtrees(TreeNode root)
        {
            var count = 0;
            RecursiveCountUniValueTrees(root,ref count);
            return count;
        }


        private static bool RecursiveCountUniValueTrees(TreeNode node, ref int count)
        {
            if (node == null)
            {
                return true;
            }

            if (node.Left == null && node.Right == null)
            {
                count++;
                return true;
            }

            var left = RecursiveCountUniValueTrees(node.Left,ref count);
            var right = RecursiveCountUniValueTrees(node.Right,ref count);
            if (left && right && (node.Left == null || node.Left.Val == node.Val) && (node.Right == null || node.Right.Val == node.Val))
            {
                count++;
                return true;
            }

            return false;
        }


        

    }
}