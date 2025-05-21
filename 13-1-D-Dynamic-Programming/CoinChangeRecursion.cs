public partial class Solution {

    // Recursive helper function to find the minimum coins needed
    public int CCRDfs(int[] coins, int amount) {
        // Base case: if the remaining amount is 0, we need 0 coins
        if (amount == 0) return 0;

        // Initialize result to a large number to represent "infinity"
        int res = (int)1e9;

        // Try every coin that doesn't exceed the current amount
        foreach (var coin in coins) {
            if (amount - coin >= 0) {
                // Recursively call with reduced amount and add 1 coin
                res = Math.Min(res, 1 + CCRDfs(coins, amount - coin));
            }
        }

        // Return the minimum number of coins found
        return res;
    }

    // Main function to call the recursive helper
    public int RCoinChange(int[] coins, int amount) {
        int minCoins = CCRDfs(coins, amount);
        // If result is still infinity, no combination was found
        return (minCoins >= 1e9) ? -1 : minCoins;
    }
}
/*
✅ 2. Tree Output for Input: coins = [1, 3, 4, 5], amount = 7
This is a recursive tree of function calls. 
Each level indents one level deeper, and each node represents a call like 
CCRDfs(amount = x).

CCRDfs(7)
├─ Try coin 1 → CCRDfs(6)
│  ├─ Try coin 1 → CCRDfs(5)
│  │  ├─ Try coin 1 → CCRDfs(4)
│  │  │  ├─ Try coin 1 → CCRDfs(3)
│  │  │  │  ├─ Try coin 1 → CCRDfs(2)
│  │  │  │  │  ├─ Try coin 1 → CCRDfs(1)
│  │  │  │  │  │  ├─ Try coin 1 → CCRDfs(0) ↩ return 0 (success path ends)
│  │  │  │  │  │  ├─ Try coin 3 → CCRDfs(-2) ⛔ skipped
│  │  │  │  │  │  ├─ Try coin 4 → CCRDfs(-3) ⛔ skipped
│  │  │  │  │  │  └─ Try coin 5 → CCRDfs(-4) ⛔ skipped
│  │  │  │  │  ├─ Try coin 3 → CCRDfs(-1) ⛔ skipped
│  │  │  │  │  ├─ Try coin 4 → CCRDfs(-2) ⛔ skipped
│  │  │  │  │  └─ Try coin 5 → CCRDfs(-3) ⛔ skipped
│  │  │  │  ├─ Try coin 3 → CCRDfs(0) ↩ return 0
│  │  │  │  ├─ Try coin 4 → CCRDfs(-1) ⛔ skipped
│  │  │  │  └─ Try coin 5 → CCRDfs(-2) ⛔ skipped
│  │  │  ├─ Try coin 3 → CCRDfs(1)
│  │  │  │  ├─ Try coin 1 → CCRDfs(0) ↩ return 0
│  │  │  │  └─ Rest skipped
│  │  │  ├─ Try coin 4 → CCRDfs(0) ↩ return 0
│  │  │  └─ Try coin 5 → CCRDfs(-1) ⛔ skipped
│  │  ├─ Try coin 3 → CCRDfs(2)
│  │  │  ├─ Try coin 1 → CCRDfs(1)
│  │  │  │  ├─ Try coin 1 → CCRDfs(0) ↩ return 0
│  │  │  └─ Rest skipped
│  │  └─ Try coin 4 → CCRDfs(1) → already visited above
│  ├─ Try coin 3 → CCRDfs(3)
│  │  ├─ Try coin 1 → CCRDfs(2)
│  │  ├─ Try coin 3 → CCRDfs(0) ↩ return 0
│  │  └─ Try coin 4/5 → skipped
│  └─ Try coin 4 → CCRDfs(2)
├─ Try coin 3 → CCRDfs(4) → similar to subtree above
├─ Try coin 4 → CCRDfs(3)
├─ Try coin 5 → CCRDfs(2)

*/
/*

🔁 Note: This algorithm recomputes the same subproblems repeatedly. 
That’s why DFS without memoization is inefficient (exponential time). 
You can see CCRDfs(3), CCRDfs(2), etc. appear multiple times.
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