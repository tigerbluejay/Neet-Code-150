public partial class Solution {
    public int MPSPSMaxProduct(int[] nums) {
        int n = nums.Length;
        
        // Initialize result with the first element in case all elements are negative or zeros
        int res = nums[0];

        // Prefix and suffix products, reset to 1 on encountering a zero
        int prefix = 0, suffix = 0;

        for (int i = 0; i < n; i++) {
            // Build prefix product going left to right
            // If prefix is zero, restart product with current number
            prefix = nums[i] * (prefix == 0 ? 1 : prefix);

            // Build suffix product going right to left
            // Same logic: reset on zero
            suffix = nums[n - 1 - i] * (suffix == 0 ? 1 : suffix);

            // Update result with the best of prefix, suffix, or current result
            res = Math.Max(res, Math.Max(prefix, suffix));
        }

        return res;
    }
}
/*
🌳 Tree-like Execution for Input nums = [1, 2, -3, 4]

We process the array from left to right with prefix
And right to left with suffix in the same loop.

Start:
  res = nums[0] = 1
  prefix = 0
  suffix = 0

Loop i = 0 to 3:
────────────────────────────

i = 0:
  prefix = nums[0] * (prefix == 0 ? 1 : prefix) = 1 * 1 = 1
  suffix = nums[3] * (suffix == 0 ? 1 : suffix) = 4 * 1 = 4
  res    = max(1, max(1, 4)) = 4

i = 1:
  prefix = 2 * 1 = 2
  suffix = -3 * 4 = -12
  res    = max(4, max(2, -12)) = 4

i = 2:
  prefix = -3 * 2 = -6
  suffix = 2 * -12 = -24
  res    = max(4, max(-6, -24)) = 4

i = 3:
  prefix = 4 * -6 = -24
  suffix = 1 * -24 = -24
  res    = max(4, max(-24, -24)) = 4

────────────────────────────

✅ Final Output:
  res = 4
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