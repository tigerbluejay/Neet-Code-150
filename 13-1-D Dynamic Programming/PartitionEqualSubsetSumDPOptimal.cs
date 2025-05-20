public partial class Solution {
    public bool DPOCanPartition(int[] nums) {
        // If the sum is odd, we can't split it evenly into two subsets
        if (PESSDPOSum(nums) % 2 != 0) {
            return false;
        }

        int target = PESSDPOSum(nums) / 2;

        // dp[i] will be true if a subset sums to 'i'
        bool[] dp = new bool[target + 1];

        // Base case: zero sum is always achievable (empty subset)
        dp[0] = true;

        // Process each number in the input array
        for (int i = 0; i < nums.Length; i++) {
            // Traverse from target down to nums[i]
            // We go backwards to avoid using the same number multiple times in this 
            // iteration
            for (int j = target; j >= nums[i]; j--) {
                // If j - nums[i] is reachable, then so is j
                dp[j] = dp[j] || dp[j - nums[i]];
            }
        }

        // If target sum is reachable, return true
        return dp[target];
    }

    private int PESSDPOSum(int[] nums) {
        int total = 0;
        foreach (var num in nums) {
            total += num;
        }
        return total;
    }
}

/*

🧠 2. Prose Explanation

This algorithm solves the partition problem using classic bottom-up dynamic programming. 
The key idea is to determine which subset sums are possible as we process each number in 
the array. We begin by checking if the total sum is even; if not, we can immediately 
return false, because we can't divide it into two equal subsets.

Next, we define a boolean array dp of size target + 1, where target is half the total sum. 
Each dp[j] represents whether a subset sum of j can be formed using the numbers processed 
so far. Initially, we set dp[0] = true since a sum of zero is always possible using the 
empty subset.

We then iterate through the array. For each number, we traverse the dp array backward from 
target to nums[i], updating dp[j] to true if dp[j - nums[i]] is already true. 
This means if we can reach a sum of j - nums[i], then by adding nums[i] we can reach a 
sum of j. Backward traversal is crucial here to ensure we don’t use the same number 
multiple times in one iteration.

In the end, if dp[target] is true, we know a valid partition exists that sums to exactly 
half of the total — and we return true.
*/

/*
🧾 DP Traversal for nums = [1, 2, 3, 4]
Total sum = 10 → target = 5

Initial dp: [true, false, false, false, false, false]

We'll log changes after each number:

After processing 1:
  Traverse j = 5 to 1:
    j = 1: dp[1] = dp[1] || dp[0] → true
  dp = [T, T, F, F, F, F]

After processing 2:
  Traverse j = 5 to 2:
    j = 3: dp[3] = dp[3] || dp[1] → true
    j = 2: dp[2] = dp[2] || dp[0] → true
  dp = [T, T, T, T, F, F]

After processing 3:
  Traverse j = 5 to 3:
    j = 5: dp[5] = dp[5] || dp[2] → true ✅ TARGET REACHED
    j = 4: dp[4] = dp[4] || dp[1] → true
    j = 3: dp[3] = dp[3] || dp[0] → already true
  dp = [T, T, T, T, T, T]

✅ As soon as dp[5] becomes true, we can return true — a valid subset exists.
*/

/*
📝 Copy-Paste Friendly Traversal Output

Initial dp: [T, F, F, F, F, F]

After 1:
  dp: [T, T, F, F, F, F]

After 2:
  dp: [T, T, T, T, F, F]

After 3:
  dp: [T, T, T, T, T, T] → dp[5] = true → return true

*/

/*
nums = [1, 2, 3, 4]

Total sum = 10, so our target is 5.

Now let’s walk through what each dp[i] means in this specific context, 
by showing which subset(s) of [1, 2, 3, 4] can achieve each sum i:

Index (i)	dp[i] Represents	Example Subset(s)
dp[0]	A subset sum of 0 is possible	[] (empty subset)
dp[1]	A subset sum of 1 is possible	[1]
dp[2]	A subset sum of 2 is possible	[2]
dp[3]	A subset sum of 3 is possible	[1, 2], or [3]
dp[4]	A subset sum of 4 is possible	[1, 3], or [4]
dp[5]	A subset sum of 5 is possible ← 🎯 target!	[2, 3], or [1, 4]

So:

dp[0] is always true.

After processing all the numbers, dp[5] == true means we can split 
[1, 2, 3, 4] into [1, 4] and [2, 3] — both sum to 5.
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