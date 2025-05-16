public partial class Solution
{
    public int DPBUIILengthOfLIS(int[] nums)
    {
        int[] LIS = new int[nums.Length];
        for (int i = 0; i < LIS.Length; i++) LIS[i] = 1;

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] < nums[j])
                {
                    LIS[i] = Math.Max(LIS[i], 1 + LIS[j]);
                }
            }
        }
        return LIS.Max();
    }
}

/*

nums = [9, 1, 4, 2, 3, 3, 7]

Initial LIS:
LIS = [1, 1, 1, 1, 1, 1, 1]

Iteration tree:
i = 6 → nums[6] = 7
  No j > i → LIS[6] = 1

LIS: [1, 1, 1, 1, 1, 1, 1]

----------------------------

i = 5 → nums[5] = 3
  j = 6 → nums[6] = 7 → 3 < 7 → LIS[5] = max(1, 1 + LIS[6]) = 2

LIS: [1, 1, 1, 1, 1, 2, 1]

----------------------------

i = 4 → nums[4] = 3
  j = 5 → nums[5] = 3 → skip
  j = 6 → nums[6] = 7 → 3 < 7 → LIS[4] = max(1, 1 + LIS[6]) = 2

LIS: [1, 1, 1, 1, 2, 2, 1]

----------------------------

i = 3 → nums[3] = 2
  j = 4 → nums[4] = 3 → 2 < 3 → LIS[3] = max(1, 1 + LIS[4]) = 3
  j = 5 → nums[5] = 3 → 2 < 3 → LIS[3] = max(3, 1 + LIS[5]) = 3
  j = 6 → nums[6] = 7 → 2 < 7 → LIS[3] = max(3, 1 + LIS[6]) = 3

LIS: [1, 1, 1, 3, 2, 2, 1]

----------------------------

i = 2 → nums[2] = 4
  j = 3 → nums[3] = 2 → skip
  j = 4 → nums[4] = 3 → skip
  j = 5 → nums[5] = 3 → skip
  j = 6 → nums[6] = 7 → 4 < 7 → LIS[2] = max(1, 1 + LIS[6]) = 2

LIS: [1, 1, 2, 3, 2, 2, 1]

----------------------------

i = 1 → nums[1] = 1
  j = 2 → nums[2] = 4 → 1 < 4 → LIS[1] = max(1, 1 + LIS[2]) = 3
  j = 3 → nums[3] = 2 → 1 < 2 → LIS[1] = max(3, 1 + LIS[3]) = 4
  j = 4 → nums[4] = 3 → 1 < 3 → LIS[1] = max(4, 1 + LIS[4]) = 4
  j = 5 → nums[5] = 3 → 1 < 3 → LIS[1] = max(4, 1 + LIS[5]) = 4
  j = 6 → nums[6] = 7 → 1 < 7 → LIS[1] = max(4, 1 + LIS[6]) = 4

LIS: [1, 4, 2, 3, 2, 2, 1]

----------------------------

i = 0 → nums[0] = 9
  All nums[j] > nums[0] → false → LIS[0] remains 1

LIS: [1, 4, 2, 3, 2, 2, 1]

Final LIS array:
[1, 4, 2, 3, 2, 2, 1]

Output (Maximum of LIS):
4

*/


/*
Longest Increasing Subsequence

Given an integer array nums, return the length of the longest strictly increasing 
subsequence.

A subsequence is a sequence that can be derived from the given sequence by deleting 
some or no elements without changing the relative order of the remaining characters.

For example, "cat" is a subsequence of "crabt".

Example 1:
Input: nums = [9,1,4,2,3,3,7]
Output: 4
Explanation: The longest increasing subsequence is [1,2,3,7], which has a length of 4.

Example 2:
Input: nums = [0,3,1,3,2,3]
Output: 4

Constraints:
1 <= nums.length <= 1000
-1000 <= nums[i] <= 1000
*/