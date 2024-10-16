public partial class Solution {
      public double FindMedianSortedArrays(int[] nums1, int[] nums2)
      { 
         if (nums1.Length <= 0 && nums2.Length == 1)
            {
                return nums2[0];
            }
            if (nums2.Length <= 0 && nums1.Length == 1)
            {
                return nums1[0];
            }
          
            var m = nums1.Length;
            var n = nums2.Length;
            if (m > n)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }
            var total = m + n;
            var half = (total + 1) / 2;
            var left = 0;
            var right = m;
            var result = 0.0;
            while (left <= right)
            {
                // This line calculates the middle index i of the first array (nums1) 
                // within the current search boundaries defined by left and right.
                var i = left + (right - left) / 2;
                // Here, j is calculated as the index in the second array (nums2) 
                // that complements the partition in nums1.
                var j = half - i; 
                
                // This variable holds the largest value in the left partition of nums1
                var left1 = (i > 0) ? nums1[i - 1] : int.MinValue;
                // This variable holds the smallest value in the right partition of nums1.
                var right1 = (i < m) ? nums1[i] : int.MaxValue;

                // Similar to left1, this holds the largest value in the left partition of nums2.
                var left2 = (j > 0) ? nums2[j - 1] : int.MinValue;
                // This holds the smallest value in the right partition of nums2.
                var right2 = (j < n) ? nums2[j] : int.MaxValue;
               

                /* The core condition checks if the partition is valid: left1 <= right2 and left2 <= right1.
                    If valid:
                    For an even total length, 
                    the median is the average of the maximum of the left partition and the minimum of the right partition.
                   
                    For an odd total length, the median is simply the maximum of the left partition.
                    
                    If the partition is valid, it breaks the loop. - the partition has been done correctly
                */
                if (left1 <= right2 && left2 <= right1)
                { 
                    if (total % 2 == 0)
                    {
                        result = (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
                    }
                    else
                    {
                        result = Math.Max(left1, left2);
                    }
                    break;
                }
                
                // if the largest value of the left partition of nums1 > 
                // than the smallest value of the right partition of nums2
                // the partition has not been done correctly and we need to adjust right
                else if (left1 > right2)
                {
                    right = i - 1;
                }
                // or adjust left
                else
                {
                    left = i + 1;
                }
            }
            return result;
      }
}




/* 

Median of Two Sorted Arrays

You are given two integer arrays nums1 and nums2 of size m and n respectively, 
where each is sorted in ascending order. Return the median value among all elements of the two arrays.

Your solution must run in 
O(log(m+n)) time.

Example 1:
Input: nums1 = [1,2], nums2 = [3]
Output: 2.0

Explanation: Among [1, 2, 3] the median is 2.

Example 2:
Input: nums1 = [1,3], nums2 = [2,4]
Output: 2.5

Explanation: Among [1, 2, 3, 4] the median is (2 + 3) / 2 = 2.5.

Constraints:
nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
-10^6 <= nums1[i], nums2[i] <= 10^6

*/