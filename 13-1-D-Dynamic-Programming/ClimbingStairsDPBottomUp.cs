public partial class Solution {
    // Iterative bottom-up DP approach to count ways to climb stairs
    public int DPBUClimbStairs(int n) {
        // Base case: If n is 1 or 2, return n (1 step → 1 way, 2 steps → 2 ways)
        if (n <= 2) {
            return n;
        }

        // Create an array to store results for each step up to n
        int[] dp = new int[n + 1];

        // Initialize base cases
        dp[1] = 1; // 1 way to reach step 1
        dp[2] = 2; // 2 ways to reach step 2

        // Iterate from step 3 to n, filling up the dp array
        for (int i = 3; i <= n; i++) {
            dp[i] = dp[i - 1] + dp[i - 2]; // Ways to reach step i = sum of ways from (i-1) and (i-2)
        }

        // Return the total ways to reach the nth step
        return dp[n];
    }
}

/*
Tree Representation for n = 5 (Bottom-Up DP)

Step Calculation Process:
1. dp[1] = 1  → (1 way: [1])
2. dp[2] = 2  → (2 ways: [1,1], [2])
3. dp[3] = dp[2] + dp[1] = 2 + 1 = 3
   ├── [1,1,1]
   ├── [1,2]
   ├── [2,1]
4. dp[4] = dp[3] + dp[2] = 3 + 2 = 5
   ├── [1,1,1,1]
   ├── [1,1,2]
   ├── [1,2,1]
   ├── [2,1,1]
   ├── [2,2]
5. dp[5] = dp[4] + dp[3] = 5 + 3 = 8
   ├── [1,1,1,1,1]
   ├── [1,1,1,2]
   ├── [1,1,2,1]
   ├── [1,2,1,1]
   ├── [2,1,1,1]
   ├── [2,2,1]
   ├── [2,1,2]
   ├── [1,2,2]
*/

/*
What do the arrays below the computation represent?
Each row represents a different way to reach step 5:

[1,1,1,1,1] → Taking five 1-steps

1 → 2 → 3 → 4 → 5
[1,1,1,2] → First three 1-steps, then a 2-step
*/

/*
Climbing Stairs

You are given an integer n representing the number of steps to reach the top of a staircase. 
You can climb with either 1 or 2 steps at a time.

Return the number of distinct ways to climb to the top of the staircase.

Example 1:
Input: n = 2
Output: 2

Explanation:
1 + 1 = 2
2 = 2

Example 2:
Input: n = 3
Output: 3

Explanation:
1 + 1 + 1 = 3
1 + 2 = 3
2 + 1 = 3

Constraints:
1 <= n <= 30
*/