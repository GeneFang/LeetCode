using System.Runtime.InteropServices.ComTypes;
using LeetCode.Explore.Learn;
using LeetCode.Explore.Learn.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Explore.Test
{
    [TestClass]
    public class BinarySearchTreeTest
    {
        private readonly BinarySearchTree _binarySearchTree = new BinarySearchTree();

        [TestMethod]
        public void IsValidBinarySearchTreeTest()
        {
            Assert.IsTrue(_binarySearchTree.IsValidBinarySearchTree(new TreeNode(2,new TreeNode(1),new TreeNode(3) )));
            Assert.IsTrue(!_binarySearchTree.IsValidBinarySearchTree(new TreeNode(5,new TreeNode(1),new TreeNode(4,new TreeNode(3), new TreeNode(6)) )));
        }

        [TestMethod]
        public void SearchBinaryTreeNodeTest()
        {
            Assert.IsTrue(TreeNode.IsSame(_binarySearchTree.SearchBinaryTreeNode(new TreeNode(4,new TreeNode(2,new TreeNode(1),new TreeNode(3) ),new TreeNode(7) ),2),new TreeNode(2,new TreeNode(1),new TreeNode(3) )));
            Assert.IsTrue(TreeNode.IsSame(_binarySearchTree.SearchBinaryTreeNode(new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(7)), 5), null));
            Assert.IsTrue(TreeNode.IsSame(_binarySearchTree.SearchBinaryTreeNode(new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(7)), 7), new TreeNode(7)));
        }


        [TestMethod]
        public void InsertToBinarySearchTreeTest()
        {
            Assert.IsTrue(TreeNode.IsSame(_binarySearchTree.InsertToBinarySearchTree(new TreeNode(4,new TreeNode(2,new TreeNode(1),new TreeNode(3) ),new TreeNode(7) ),5 ),new TreeNode(4,new TreeNode(2,new TreeNode(1),new TreeNode(3) ),new TreeNode(7,new TreeNode(5),null ) )));
        }

        [TestMethod]
        public void DeleteNodeTest()
        {
            var result = _binarySearchTree.DeleteNode(
                new TreeNode(5, new TreeNode(3, new TreeNode(2), new TreeNode(4)),
                    new TreeNode(6, null, new TreeNode(7))), 3);
            Assert.IsTrue(TreeNode.IsSame(result, new TreeNode(5,new TreeNode(4,new TreeNode(2),null ), new TreeNode(6,null,new TreeNode(7))))|| TreeNode.IsSame(result, new TreeNode(5, new TreeNode(2, null, new TreeNode(4)), new TreeNode(6, null, new TreeNode(7)))));
        }

        [TestMethod]
        public void IsBalancedTest()
        {
            Assert.IsTrue(_binarySearchTree.IsBalanced(new TreeNode(3,new TreeNode(9),new TreeNode(20,new TreeNode(15),new TreeNode(7) ) )));
            Assert.IsFalse(_binarySearchTree.IsBalanced(new TreeNode(1,new TreeNode(2,new TreeNode(3,new TreeNode(4,new TreeNode(4),new TreeNode(3) ),new TreeNode(4) ),new TreeNode(3) ),new TreeNode(2) )));
        }
    }
}