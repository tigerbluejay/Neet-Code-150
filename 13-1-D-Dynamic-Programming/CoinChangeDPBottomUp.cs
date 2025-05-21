public partial class Solution {
    public int DPBUCoinChange(int[] coins, int amount) {
        // Initialize dp array with amount+1 (impossible max)
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1); // signifies "unreachable" initially
        dp[0] = 0; // base case: 0 coins needed for amount 0

        // Build the solution bottom-up from 1 to amount
        for (int i = 1; i <= amount; i++) {
            foreach (int coin in coins) {
                if (coin <= i) {
                    // If we can use this coin, check if using it improves our solution
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
        }

        // If dp[amount] was never updated, return -1 (no solution)
        return dp[amount] > amount ? -1 : dp[amount];
    }
}

/*
🌳 2. Notepad-Friendly Tree-like Table for coins = [1, 3, 4, 5], amount = 7
✨ Bottom-Up Table Building (dp[i] is the minimum coins to get amount i)
We build dp[] from 0 to 7. Start with dp[0] = 0, everything else is 
initialized to 8 (i.e., amount + 1 = 7 + 1).

Initial: dp = [0, 8, 8, 8, 8, 8, 8, 8]

i = 1:
- try coin 1 → dp[1] = min(8, dp[0]+1 = 1) → dp[1] = 1
→ dp = [0, 1, 8, 8, 8, 8, 8, 8]

i = 2:
- try coin 1 → dp[2] = min(8, dp[1]+1 = 2) → dp[2] = 2
→ dp = [0, 1, 2, 8, 8, 8, 8, 8]

i = 3:
- try coin 1 → dp[3] = min(8, dp[2]+1 = 3)
- try coin 3 → dp[3] = min(3, dp[0]+1 = 1) ✅
→ dp = [0, 1, 2, 1, 8, 8, 8, 8]

i = 4:
- try coin 1 → dp[4] = min(8, dp[3]+1 = 2)
- try coin 4 → dp[4] = min(2, dp[0]+1 = 1) ✅
→ dp = [0, 1, 2, 1, 1, 8, 8, 8]

i = 5:
- try coin 1 → dp[5] = min(8, dp[4]+1 = 2)
- try coin 3 → dp[5] = min(2, dp[2]+1 = 3)
- try coin 4 → dp[5] = min(2, dp[1]+1 = 2)
- try coin 5 → dp[5] = min(2, dp[0]+1 = 1) ✅
→ dp = [0, 1, 2, 1, 1, 1, 8, 8]

i = 6:
- try coin 1 → dp[6] = min(8, dp[5]+1 = 2)
- try coin 3 → dp[6] = min(2, dp[3]+1 = 2)
- try coin 4 → dp[6] = min(2, dp[2]+1 = 3)
- try coin 5 → dp[6] = min(2, dp[1]+1 = 2)
→ dp = [0, 1, 2, 1, 1, 1, 2, 8]

i = 7:
- try coin 1 → dp[7] = min(8, dp[6]+1 = 3)
- try coin 3 → dp[7] = min(3, dp[4]+1 = 2) ✅
- try coin 4 → dp[7] = min(2, dp[3]+1 = 2)
- try coin 5 → dp[7] = min(2, dp[2]+1 = 3)
→ dp = [0, 1, 2, 1, 1, 1, 2, 2]

*/
/*
Coin Change

You are given an integer array coins representing coins of different 
denominations (e.g. 1 dollar, 5 dollars, etc) and an integer amount 
representing a target amount of money.

Return the fewest number of coins that you need to make up the exact target 
amount. If it is impossible to make up the amount, return -1.

You may assume that you have an unlimited number of each coin.

Example 1:
Input: coins = [1,5,10], amount = 12
Output: 3
Explanation: 12 = 10 + 1 + 1. Note that we do not have to use every kind 
coin available.

Example 2:
Input: coins = [2], amount = 3
Output: -1
Explanation: The amount of 3 cannot be made up with coins of 2.

Example 3:
Input: coins = [1], amount = 0
Output: 0
Explanation: Choosing 0 coins is a valid way to make up 0.

Constraints:
1 <= coins.length <= 10
1 <= coins[i] <= 2^31 - 1
0 <= amount <= 10000
*/