public partial class Solution {
    public int MPSMaxProduct(int[] nums) {
        // Initialize result as the first element
        int res = nums[0];

        // Outer loop: start index of subarray
        for (int i = 0; i < nums.Length; i++) {
            int cur = nums[i]; // Start current product with nums[i]
            res = Math.Max(res, cur); // Compare single element with result

            // Inner loop: end index of subarray
            for (int j = i + 1; j < nums.Length; j++) {
                cur *= nums[j]; // Extend subarray and multiply
                res = Math.Max(res, cur); // Update result if current product is larger
            }
        }

        return res; // Return the maximum product found
    }
}
/*

🌲 Execution Tree (Input: nums = [1, 2, -3, 4])
We'll simulate the nested loops and show each subarray product.
We'll also update res when we find a new maximum.

Initial res = 1 (nums[0])

i = 0
  cur = nums[0] = 1
  res = max(1, 1) = 1

  j = 1 → cur = 1 * 2 = 2
        → res = max(1, 2) = 2 ✅

  j = 2 → cur = 2 * -3 = -6
        → res = max(2, -6) = 2

  j = 3 → cur = -6 * 4 = -24
        → res = max(2, -24) = 2

i = 1
  cur = nums[1] = 2
  res = max(2, 2) = 2

  j = 2 → cur = 2 * -3 = -6
        → res = max(2, -6) = 2

  j = 3 → cur = -6 * 4 = -24
        → res = max(2, -24) = 2

i = 2
  cur = nums[2] = -3
  res = max(2, -3) = 2

  j = 3 → cur = -3 * 4 = -12
        → res = max(2, -12) = 2

i = 3
  cur = nums[3] = 4
  res = max(2, 4) = 4 ✅

Final result: 4
*/
/*
Maximum Product Subarray

Given an integer array nums, find a subarray that has the largest product
within the array and return it.

A subarray is a contiguous non-empty sequence of elements within an array.

You can assume the output will fit into a 32-bit integer.

Example 1:
Input: nums = [1,2,-3,4]
Output: 4

Example 2:
Input: nums = [-2,-1]
Output: 2

Constraints:
1 <= nums.length <= 1000
-10 <= nums[i] <= 10
*/