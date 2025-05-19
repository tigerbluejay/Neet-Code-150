public partial class Solution
{
    public bool DPBUCanPartition(int[] nums)
    {
        int sum = 0;
        foreach (var num in nums)
        {
            sum += num;
        }

        // If sum is odd, we can't divide it into two equal subsets
        if (sum % 2 != 0)
        {
            return false;
        }

        int target = sum / 2;
        int n = nums.Length;

        // dp[i, j] means: can we form sum j using the first i elements?
        bool[,] dp = new bool[n + 1, target + 1];

        // Base case: sum 0 can always be formed using 0 elements (empty set)
        for (int i = 0; i <= n; i++)
        {
            dp[i, 0] = true;
        }

        // Fill the table bottom-up
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                if (nums[i - 1] <= j)
                {
                    // Either we skip the current num or we use it
                    dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
                }
                else
                {
                    // Current num too big, skip it
                    dp[i, j] = dp[i - 1, j];
                }
            }
        }

        // Final answer: can we form 'target' sum using all n numbers?
        return dp[n, target];
    }
}

/*
This algorithm builds a 2D DP table where dp[i, j] indicates whether it's possible to 
form a subset with sum j using the first i numbers from the array nums.

The goal is to determine if there's a subset of nums that sums to sum / 2.

The table has (n+1) rows (for 0 to n elements) and (target+1) columns 
(for sum 0 to target).

Initially, every dp[i, 0] = true, because a subset sum of 0 is always achievable 
(the empty set).

The table is filled row by row:

At each cell dp[i, j], we check whether we can either:

Achieve sum j without including the current number: dp[i - 1, j]
Or achieve sum j by including the current number nums[i - 1]: dp[i - 1, j - nums[i - 1]] 
(only if nums[i - 1] <= j)

The final result is in dp[n, target]: it tells us whether it's possible to build a 
subset summing to half the total.
*/

/*
DP Table (rows: i = 0 to 4, cols: j = 0 to 5)
Each cell dp[i][j] = T (true) or F (false)

      0   1   2   3   4   5
    -----------------------
0 |  T   F   F   F   F   F
1 |  T   T   F   F   F   F
2 |  T   T   T   T   F   F
3 |  T   T   T   T   T   T
4 |  T   T   T   T   T   T

Legend:
i = number of elements considered (from 0 to 4)
j = target subset sum (from 0 to 5)
T = true (sum j is achievable using first i elements)
F = false (sum j is not achievable with first i elements)
*/

/*

Here are four illustrated cells from the DP table of the bottom-up approach 
for nums = [1, 2, 3, 4] and target = 5. We’ll walk through how each dp[i][j] 
value is derived:

🟩 dp[1][1] = true
We're considering the first element: [1]
Can we form sum 1 with this subset?
Yes! The number 1 equals the target.
So, dp[1][1] = true

✅ Reasoning:
Since nums[0] = 1 and 1 <= 1, we check
→ dp[0][1] (exclude 1) → false
→ dp[0][0] (include 1 → 1-1 = 0) → true
Thus, dp[1][1] = false || true = true

🟥 dp[2][4] = false
Subset: [1, 2]
Can we form sum 4?
No. 1 + 2 = 3 which is less than 4, and we have no combination to make 4 here.

🚫 Reasoning:
nums[1] = 2, 2 <= 4, so:
→ dp[1][4] (exclude 2) → false
→ dp[1][2] (include 2 → 4 - 2 = 2) → false
Thus, dp[2][4] = false || false = false

🟩 dp[3][5] = true
Subset: [1, 2, 3]
Can we form sum 5?
Yes: 2 + 3 = 5

✅ Reasoning:
nums[2] = 3, 3 <= 5, so:
→ dp[2][5] (exclude 3) → false
→ dp[2][2] (include 3 → 5 - 3 = 2) → true
Thus, dp[3][5] = false || true = true

🟩 dp[4][5] = true
Subset: [1, 2, 3, 4]
Can we form sum 5?
Yes: both 1 + 4 and 2 + 3 work.

✅ Reasoning:
nums[3] = 4, 4 <= 5, so:
→ dp[3][5] (exclude 4) → true
→ dp[3][1] (include 4 → 5 - 4 = 1) → true
Thus, dp[4][5] = true || true = true
*/

/*
The final return line:

return dp[n, target];
corresponds to:

✅ dp[4][5] in the table

Why?
n = nums.Length = 4 (for [1, 2, 3, 4])

target = sum / 2 = (1 + 2 + 3 + 4) / 2 = 10 / 2 = 5

So the algorithm is checking:

Can we form the sum 5 using all 4 numbers?

This final cell dp[4][5] holds the answer to the problem, and in our case it's:

dp[4][5] = true
✅ Meaning: Yes, we can partition the array into two subsets with equal sum.
*/

/*
✅ Concrete Case: nums = [1, 2, 3, 4]

Goal: Reach sum 5 using some subset of the 4 elements.
When we reach dp[4][5], we’re asking:
"Can I form sum 5 using any combination of [1, 2, 3, 4]?"

This entry is filled in based on whether:
We could already reach 5 with [1,2,3] → dp[3][5]
Or we can reach 5 by adding 4 to some earlier sum → dp[3][1] because 5 - 4 = 1
If either is true, then dp[4][5] = true.

And both are true here!
*/

/*
Partition Equal Subset Sum

You are given an array of positive integers nums.
Return true if you can partition the array into two subsets, 
subset1 and subset2 where sum(subset1) == sum(subset2). Otherwise, return false.

Example 1:
Input: nums = [1,2,3,4]
Output: true
Explanation: The array can be partitioned as [1, 4] and [2, 3].

Example 2:
Input: nums = [1,2,3,4,5]
Output: false

Constraints:
1 <= nums.length <= 100
1 <= nums[i] <= 50
*/