public partial class Solution {
    // Entry point: starts recursive DFS from index 0 with no previous element 
    // included (-1)
    public int RLengthOfLIS(int[] nums) {
        return LISRDfs(nums, 0, -1);
    }

    // Recursive function to compute LIS
    // i: current index in nums we are considering
    // j: index of the previously included element in the subsequence, or -1 if 
    // none has been included
    private int LISRDfs(int[] nums, int i, int j) {
        // Base case: reached the end of the array
        if (i == nums.Length) {
            return 0;
        }

        // Option 1: skip current element at index i
        int LIS = LISRDfs(nums, i + 1, j);

        // Option 2: include current element only if it's larger than the previous one 
        // (to maintain increasing order)
        if (j == -1 || nums[j] < nums[i]) {
            // If included, add 1 to the LIS and move to the next element with 
            // current i as the new "previous" (j)
            LIS = Math.Max(LIS, 1 + LISRDfs(nums, i + 1, i));
        }

        return LIS; // return the best of including or excluding the current element
    }
}

/*
Example 1:
Input: nums = [9,1,4,2,3,3,7]
Output: 4


LIS(0, -1)
├── skip 9 -> LIS(1, -1)
│   ├── skip 1 -> LIS(2, -1)
│   │   ├── skip 4 -> LIS(3, -1)
│   │   │   ├── skip 2 -> LIS(4, -1)
│   │   │   │   ├── skip 3 -> LIS(5, -1)
│   │   │   │   │   ├── skip 3 -> LIS(6, -1)
│   │   │   │   │   │   ├── skip 7 -> LIS(7, -1) = 0
│   │   │   │   │   │   └── include 7 -> LIS(7, 6) = 0 → return 1
│   │   │   │   │   └── best of skip/include 7 = 1
│   │   │   │   └── include 3 -> LIS(6, 4) → check if nums[4]=3 < nums[6]=7 → true
│   │   │   │       → LIS(7, 6) = 0 → return 1 → total = 1 + 1 = 2
│   │   │   │   └── best of skip/include 3 = 2
│   │   │   └── include 2 (nums[3]) → nums[-1] < 2 → always true
│   │   │       └── LIS(4, 3)
│   │   │           └── same subtree as above → max = 3
│   │   │   └── best = 3
│   │   └── include 4 → nums[-1] < 4 → true
│   │       └── LIS(3, 2)
│   │           └── skip 2 → LIS(4, 2)
│   │               └── skip 3 → LIS(5, 2)
│   │                   └── skip 3 → LIS(6, 2)
│   │                       └── skip/include 7
│   │           └── include 2 → if 4 < 2 → false → skip
│   │       └── best = 3
│   └── include 1 → LIS(2, 1)
│       └── skip 4 → LIS(3, 1)
│           └── include 2 → 1 < 2 → true
│               └── LIS(4, 3)
│                   └── etc.
*/

/*
The recursive function explores every possible way to build an increasing subsequence 
from left to right. At each position in the array, it makes a decision: either skip the 
current number or include it in the subsequence if it keeps the sequence increasing. 
It does this by comparing the current number with the last number included (or allowing 
any number if nothing has been included yet).

So, for each element, the function spawns two paths: one where the element is ignored and 
the function moves to the next index without changing the "previous" index, and another 
where the element is included, which increases the length of the current subsequence by 1, 
and the function moves to the next index with this element marked as the new "previous."

This branching continues until the end of the array is reached (base case), at which point 
the function returns 0 — meaning no more elements can be added. Each recursive call returns 
the best possible length from that point on, and as the recursion unwinds, it bubbles up 
the maximum length found between all the possible combinations of skips and includes. 
In this way, the algorithm explores all valid subsequences and finds the longest increasing 
one.
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