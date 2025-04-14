public partial class Solution {
    public int MPSKAMaxProduct(int[] nums) {
        // Initialize result with the first element — this will be updated as we go
        int res = nums[0];

        // Initialize current max and min products so far
        // We use both because a negative number can flip min to max and vice versa
        int curMin = 1, curMax = 1;

        foreach (int num in nums) {
            // Store current max multiplied by num temporarily (we'll reuse it to update curMin)
            int tmp = curMax * num;

            // Update curMax:
            //   - num * curMax: extend current max product
            //   - num * curMin: flip a large negative to positive
            //   - num: start new subarray
            curMax = Math.Max(Math.Max(num * curMax, num * curMin), num);

            // Update curMin (must use tmp because curMax was just updated)
            curMin = Math.Min(Math.Min(tmp, num * curMin), num);

            // Update result if current max is the largest seen so far
            res = Math.Max(res, curMax);
        }

        return res;
    }
}

/*
🧠 Why This Works

This solution takes advantage of the fact that multiplying two negative numbers 
yields a positive — so it always tracks both:

curMax = the maximum product ending at current index

curMin = the minimum product (i.e. most negative, which could become the next 
max if multiplied by a negative number)

At each step, we evaluate:

Whether to continue the subarray by multiplying the current number with the 
previous max or min,

Or to start fresh with the current number.
*/

/*
Start:
  res = nums[0] = 1
  curMax = 1
  curMin = 1

Loop over nums:
────────────────────────────

1️⃣ num = 1
  tmp        = curMax * num = 1 * 1 = 1
  curMax     = max(1*1, 1*1, 1) = max(1, 1, 1) = 1
  curMin     = min(tmp, 1*curMin, 1) = min(1, 1, 1) = 1
  res        = max(res, curMax) = max(1, 1) = 1

2️⃣ num = 2
  tmp        = curMax * num = 1 * 2 = 2
  curMax     = max(2, 2, 2) = 2
  curMin     = min(2, 2, 2) = 2
  res        = max(1, 2) = 2

3️⃣ num = -3
  tmp        = curMax * num = 2 * -3 = -6
  curMax     = max(-6, -6, -3) = -3
  curMin     = min(-6, 2 * -3 = -6, -3) = min(-6, -6, -3) = -6
  res        = max(2, -3) = 2

4️⃣ num = 4
  tmp        = curMax * num = -3 * 4 = -12
  curMax     = max(-12, -6*4 = -24, 4) = max(-12, -24, 4) = 4
  curMin     = min(-12, -24, 4) = -24
  res        = max(2, 4) = 4

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