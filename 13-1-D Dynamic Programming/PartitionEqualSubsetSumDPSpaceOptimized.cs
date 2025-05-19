public partial class Solution {
    public bool DPSOCanPartition(int[] nums) {
        // Step 1: Check if total sum is even
        if (PESSDPSOSum(nums) % 2 != 0) {
            return false;
        }

        int target = PESSDPSOSum(nums) / 2;

        // Step 2: Initialize two 1D arrays to simulate DP rows
        bool[] dp = new bool[target + 1];
        bool[] nextDp = new bool[target + 1];

        // Base case: sum 0 is always achievable with empty set
        dp[0] = true;

        // Step 3: Iterate through each number in the array
        for (int i = 0; i < nums.Length; i++) {
            // Try forming every possible sum up to target
            for (int j = 1; j <= target; j++) {
                if (j >= nums[i]) {
                    // Can either skip the current number (dp[j]) 
                    // or include it (dp[j - nums[i]])
                    nextDp[j] = dp[j] || dp[j - nums[i]];
                } else {
                    // Cannot include the current number if it's larger than sum j
                    nextDp[j] = dp[j];
                }
            }

            // Move to the next state (simulate the row swap)
            bool[] temp = dp;
            dp = nextDp;
            nextDp = temp;
        }

        // Step 4: Final result—can we reach the target sum?
        return dp[target];
    }

    // Utility method to calculate sum
    private int PESSDPSOSum(int[] nums) {
        int total = 0;
        foreach (var num in nums) {
            total += num;
        }
        return total;
    }
}

/*
🧠 Explanation in Prose

This 1D bottom-up DP algorithm simulates the same logic as the 2D version but uses 
less memory. Instead of maintaining a full 2D table dp[i][j], it keeps just two 1D 
arrays (dp and nextDp) representing the previous and current states.

We start with dp[0] = true (base case: zero sum is always possible).
For each number in nums, we try to "build up" to the target sum.
nextDp[j] = true if we can reach sum j:
Either by not including the current number (dp[j])
Or by including the current number (dp[j - nums[i]])

At each step, we update nextDp, and then swap it into dp for the next iteration. 
After processing all numbers, dp[target] tells us whether the target sum is achievable.

🌳 Copy-Paste-Friendly Recursive-Call-Like Trace Tree
🟡 This algorithm is iterative, but we’ll mimic the idea of what each stage 
"looks like" when building up to target = 5 for:

nums = [1, 2, 3, 4]

Start:
dp = [T, F, F, F, F, F]

Processing 1:
nextDp = [T, T, F, F, F, F]

Processing 2:
nextDp = [T, T, T, T, F, F]

Processing 3:
nextDp = [T, T, T, T, T, T]

Processing 4:
nextDp = [T, T, T, T, T, T]  (unchanged since all reachable sums were already set)

✅ Final dp[5] = true → return true


🧮 Example Reasoning for a Few Key Entries
Target j	Explanation at some step
dp[0]	Always true — base case
dp[1]	1 is in the array → can form 1
dp[3]	1+2=3 or 3 directly
dp[5]	2+3=5 or 1+4=5 → reachable

You can think of it as a growing set of reachable sums.

*/

/*
Initial dp (before processing any number):
i=0 (no nums processed)
dp: [T, F, F, F, F, F]

After processing nums[0] = 1:
i=1
j=0 dp[0] = T       // base case sum=0
j=1 dp[1] = T       // 1 included, sum=1 reachable
j=2 dp[2] = F
j=3 dp[3] = F
j=4 dp[4] = F
j=5 dp[5] = F

After processing nums[1] = 2:
i=2
j=0 dp[0] = T       // sum=0 always reachable
j=1 dp[1] = T       // carried from previous dp
j=2 dp[2] = T       // 2 included, sum=2 reachable
j=3 dp[3] = T       // 1+2=3 reachable
j=4 dp[4] = F
j=5 dp[5] = F

After processing nums[2] = 3:
i=3
j=0 dp[0] = T
j=1 dp[1] = T
j=2 dp[2] = T
j=3 dp[3] = T       // 3 included
j=4 dp[4] = T       // 1+3=4 reachable
j=5 dp[5] = T       // 2+3=5 reachable

After processing nums[3] = 4:
i=4
j=0 dp[0] = T
j=1 dp[1] = T
j=2 dp[2] = T
j=3 dp[3] = T
j=4 dp[4] = T       // 4 included or 1+3
j=5 dp[5] = T       // 1+4 or 2+3 reachable

Summary in Tree Format
i=0 (no nums)
dp: [T, F, F, F, F, F]

|-- i=1 (num=1)
    dp: [T, T, F, F, F, F]

    |-- i=2 (num=2)
        dp: [T, T, T, T, F, F]

        |-- i=3 (num=3)
            dp: [T, T, T, T, T, T]

            |-- i=4 (num=4)
                dp: [T, T, T, T, T, T]
*/

/*
The algorithm only cares if dp[target] is true at the end, not all entries in dp.
If dp[target] is false, the answer is false.
The other dp[j] entries just track which sums are possible at intermediate steps.
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