using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCode.Explore.Learn;
using Moq;


namespace LeetCode.Explore.Test
{
    [TestClass]
    public class BinarySearchTest
    {
        public BinarySearchTest()
        {
            var service = new Mock<IService>();
            service.Setup(x => x.IsBadVersion(It.Is<int>(v=>v>=4))).Returns(true);
            service.Setup(x => x.IsBadVersion(It.Is<int>(v => v < 4))).Returns(false);
            _target = new BinarySearch(service.Object);
        }


        private readonly BinarySearch _target ;

        [TestMethod]
        public void SearchRotatedSortedArrayTest()
        {
            var input1 = new int[] {4, 5, 6, 7, 0, 1, 2};
            Assert.IsTrue(_target.SearchRotatedSortedArray(input1,0)==4);
            var input2 = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            Assert.IsTrue(_target.SearchRotatedSortedArray(input2, 3) == -1);
        }


        [TestMethod]
        public void FindPeakElementTest()
        {
            var input1 = new int[] {1, 2, 3, 1};

            Assert.IsTrue(_target.FindPeakElement(input1)==2);

            var input2 = new int[] {1, 2, 1, 3, 5, 6, 4};
            var output2 = _target.FindPeakElement(input2);
            Assert.IsTrue(output2 == 1|| output2 == 5);

        }
    }
}
