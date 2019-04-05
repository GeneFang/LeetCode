using System;
using System.Collections.Generic;
using System.Text;
using LeetCode.Explore.Learn.Models;

namespace LeetCode.Explore.Learn
{
    public class BinarySearchTree
    {
        /// <summary>
        /// https://leetcode.com/problems/validate-binary-search-tree/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBinarySearchTree(TreeNode root)
        {
            return IsBinarySearchTreeHelper(root, long.MinValue, long.MaxValue);
        }

        private bool IsBinarySearchTreeHelper(TreeNode node, long min, long max)
        {
            if (node == null)
            {
                return true;
            }
            if (node.Val<=min || node.Val >= max)
            {
                return false;
            }

            return IsBinarySearchTreeHelper(node.Left, min, node.Val) && IsBinarySearchTreeHelper(node.Right,node.Val,max);
            
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/141/basic-operations-in-a-bst/1000/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode SearchBinaryTreeNode(TreeNode root, int val)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Val == val)
            {
                return root;
            }
            var left = SearchBinaryTreeNode(root.Left,val);
            if (left!=null)
            {
                return left;
            }
            var right = SearchBinaryTreeNode(root.Right, val);
            return right;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/141/basic-operations-in-a-bst/1003/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode InsertToBinarySearchTree(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }

            if (root.Val>val)
            {
                root.Left = InsertToBinarySearchTree(root.Left, val);
            }
            else
            {
                root.Right = InsertToBinarySearchTree(root.Right, val);
            }

            return root;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/141/basic-operations-in-a-bst/1006/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode DeleteNode(TreeNode root, int val)
        {
            if (root == null)
            {
                return null;
            }

            if (val<root.Val)
            {
                root.Left = DeleteNode(root.Left, val);
            }
            else if (val>root.Val)
            {
                root.Right = DeleteNode(root.Right, val);
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }

                if (root.Right == null)
                {
                    return root.Left;
                }

                var minNode = FindMin(root.Right);
                root.Val = minNode.Val;
                root.Right = DeleteNode(root.Right, root.Val);
            }

            
            return root;
        }

        private TreeNode FindMin(TreeNode node)
        {
            while (node.Left!=null)
            {
                node = node.Left;
            }

            return node;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/introduction-to-data-structure-binary-search-tree/143/appendix-height-balanced-bst/1027/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return GetHeight(root) != -1;

        }

        private int GetHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            var lh = GetHeight(node.Left);
            if (lh == -1)
            {
                return -1;
            }

            var rh = GetHeight(node.Right);
            if (rh == -1)
            {
                return -1;
            }

            if (lh - rh<1 || lh-rh>1)
            {
                return -1;
            }

            return Math.Max(lh, rh) + 1;
        }
    }


    public class BinarySearchTreeIterator
    {
        private Stack<TreeNode> _stack = new Stack<TreeNode>();
        private TreeNode _current;
        public BinarySearchTreeIterator(TreeNode root)
        {
            _current = root;
        }

        public int Next()
        {
            while (_current!=null)
            {
                _stack.Push(_current);
                _current = _current.Left;
            }

            var t = _stack.Pop();
            _current = t.Right;
            return t.Val;
        }

        public bool HasNext()
        {
            return _stack.Count != 0 || _current != null;
        }
    }
}
