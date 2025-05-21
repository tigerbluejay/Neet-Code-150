public partial class Solution {
    public int MPSSWMaxProduct(int[] nums) {
        List<List<int>> A = new List<List<int>>();
        List<int> cur = new List<int>();
        int res = int.MinValue;

        foreach (int num in nums) {
            res = Math.Max(res, num);
            if (num == 0) {
                if (cur.Count > 0) {
                    A.Add(new List<int>(cur));
                }
                cur.Clear();
            } else cur.Add(num);
        }
        if (cur.Count > 0) A.Add(new List<int>(cur));

        foreach (var sub in A) {
            int negs = 0;
            foreach (var i in sub) {
                if (i < 0) negs++;
            }

            int prod = 1;
            int need = (negs % 2 == 0) ? negs : (negs - 1);
            negs = 0;
            for (int i = 0, j = 0; i < sub.Count; i++) {
                // Multiply the current number into the running product
                prod *= sub[i];

                // If the current number is negative, increment the count
                if (sub[i] < 0) {
                    negs++;

                    // If we've exceeded the allowed number of negatives (we want an even count),
                    // shrink the window from the left until the negative count matches the desired "need"
                    while (negs > need) {
                        prod /= sub[j]; // remove sub[j] from the product

                        // If the removed number was negative, update the count
                        if (sub[j] < 0) negs--;

                        j++; // move the left edge of the window forward
                    }
                }

                // Only evaluate and update the max product if the window is valid (j hasn't passed i)
                if (j <= i) {
                    res = Math.Max(res, prod);
                }
            }
        }
        return res;
    }
}

/*
Initial: prod = 1, negs = 0, j = 0

i = 0 → sub[i] = 1 → prod = 1
        → res = max(4, 1) = 4

i = 1 → sub[i] = 2 → prod = 1 * 2 = 2
        → res = max(4, 2) = 4

i = 2 → sub[i] = -3 → prod = 2 * -3 = -6
        → negs = 1 > need = 0 ⇒ slide window
            → divide prod by sub[0] = 1 ⇒ prod = -6 / 1 = -6
            → j = 1
            → divide prod by sub[1] = 2 ⇒ prod = -6 / 2 = -3
            → j = 2
            → divide prod by sub[2] = -3 ⇒ prod = -3 / -3 = 1
            → negs = 0
            → j = 3

i = 3 → sub[i] = 4 → prod = 1 * 4 = 4
        → res = max(4, 4) = 4 ✅
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