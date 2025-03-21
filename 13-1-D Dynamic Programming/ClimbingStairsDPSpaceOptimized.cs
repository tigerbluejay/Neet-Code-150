public partial class Solution {
    // Space-optimized bottom-up DP approach to count ways to climb stairs
    public int DPSOClimbStairs(int n) {
        // Instead of storing all steps in an array, we track only the last two results
        int one = 1, two = 1; // Represents dp[1] and dp[2] (Base cases)

        // Iteratively update values using two variables
        for (int i = 0; i < n - 1; i++) {
            int temp = one;    // Store previous 'one' value
            one = one + two;   // Compute new step count (dp[i] = dp[i-1] + dp[i-2])
            two = temp;        // Move 'two' to previous 'one' (shifting values)
        }

        // The final 'one' value represents dp[n], the number of ways to reach step n
        return one;
    }
}

/*
Tree Representation for n = 5 (Space-Optimized DP)
This algorithm does not explicitly generate a tree but logically follows the same 
number of paths as the bottom-up DP approach. It just avoids storing the entire dp 
array and instead keeps track of only the last two results.

Step Calculation Process:
1. Step 1: one = 1, two = 1  → (Base cases)
2. Step 2: one = 2, two = 1  → (Ways: [1,1], [2])
3. Step 3: one = 3, two = 2  → (Ways: [1,1,1], [1,2], [2,1])
4. Step 4: one = 5, two = 3  → (Ways: [1,1,1,1], [1,1,2], [1,2,1], [2,1,1], [2,2])
5. Step 5: one = 8, two = 5  → (Ways: [1,1,1,1,1], [1,1,1,2], [1,1,2,1], [1,2,1,1], [2,1,1,1], [2,2,1], [2,1,2], [1,2,2])

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