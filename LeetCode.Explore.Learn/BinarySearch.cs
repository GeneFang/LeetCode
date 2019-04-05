using System;
using System.Collections.Generic;

namespace LeetCode.Explore.Learn
{
    public class BinarySearch
    {
        private readonly IService _service;
        
        public BinarySearch(IService service)
        {
            _service = service;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/binary-search/138/background/1038/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }

            int min = 0, max = arr.Length - 1;
            while (min<=max)
            {
                var mid = min + (max - min) / 2;

                if (arr[mid]<target)
                {
                    min = mid + 1;
                }
                else if(arr[mid]>target)
                {
                    max = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/binary-search/125/template-i/950/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            if (x == 0 || x==1)
            {
                return x;
            }

            int start = 1, end = x / 2;
            while (start+1<end)
            {
                var mid = start + (end - start) / 2;
                if (mid<=x/mid)
                {
                    start = mid;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return end <= x / end ? end : start;
        }


        /// <summary>
        /// https://leetcode.com/explore/learn/card/binary-search/125/template-i/952/
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchRotatedSortedArray(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1;
            }
            
            var splitIndexList = new List<int>();
            for (var i = 0; i < arr.Length-1; i++)
            {
                if (arr[i]>arr[i+1])
                {
                    splitIndexList.Add(i);
                }
            }

            splitIndexList.Add(arr.Length - 1);
            
            for (var i = 0; i < splitIndexList.Count; i++)
            {
                int min = i == 0 ? 0 : splitIndexList[i - 1] + 1, max = splitIndexList[i];
                while (min<=max)
                {
                    var mid = min + (max - min) / 2;
                    if (arr[mid]<target)
                    {
                        min = mid + 1;
                    }
                    else if (arr[mid]>target)
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        return mid;
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/binary-search/126/template-ii/947/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GetFirstBadVersion(int n)
        {
            int start = 1, end = n;
            while (start<end)
            {
                var mid = start + (end - start) / 2;
                if (!_service.IsBadVersion(mid))
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }

            return start;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/binary-search/126/template-ii/948/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindPeakElement(int[] arr)
        {
            if (arr == null || arr.Length==0)
            {
                return -1;
            }

            int start = 0, end = arr.Length - 1;
            while (start<end)
            {
                var mid1 = start + (end-start) / 2;
                var mid2 = mid1 + 1;
                if (arr[mid1]<arr[mid2])
                {
                    start = mid2;
                }
                else
                {
                    end = mid1;
                }
            }

            return start;
        }

        /// <summary>
        /// https://leetcode.com/explore/learn/card/binary-search/126/template-ii/949/
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindMinInRotatedSortedArray(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            int start = 0, end = arr.Length - 1;
            while (start<end)
            {
                var mid = start + (end - start) / 2;
                if (arr[mid]>arr[end])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }

            return arr[start];
        }
    }
}
