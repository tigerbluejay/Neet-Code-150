public partial class Solution {
    
    // Dictionary to store already computed results for specific amounts
    private Dictionary<int, int> CCDPTDmemo = new Dictionary<int, int>();

    // Recursive DFS function with memoization
    private int CCDPTDDfs(int amount, int[] coins) {
        // Base case: 0 coins needed to make amount 0
        if (amount == 0) return 0;

        // If we've already computed the result for this amount, return it
        if (CCDPTDmemo.ContainsKey(amount)) 
            return CCDPTDmemo[amount];

        int res = int.MaxValue;

        // Try every coin
        foreach (int coin in coins) {
            if (amount - coin >= 0) {
                // Recurse on the remaining amount
                int result = CCDPTDDfs(amount - coin, coins);

                // Only update result if a valid combination is found
                if (result != int.MaxValue) {
                    res = Math.Min(res, 1 + result);
                }
            }
        }

        // Memoize the computed result
        CCDPTDmemo[amount] = res;

        return res;
    }

    // Entry point for the caller
    public int DPTDCoinChange(int[] coins, int amount) {
        int minCoins = CCDPTDDfs(amount, coins);
        return minCoins == int.MaxValue ? -1 : minCoins;
    }
}

/*
🌳 2. Notepad-Friendly Tree with Variable Explanations

Using input: coins = [1, 3, 4, 5], amount = 7

We’ll now display a memoized tree of recursive calls, labeling:

amount: current value being solved
used coin: which coin is being tried
memo hit: where we reuse a previous result

We'll only show new branches and reuse notes, 
since memoization avoids duplicate work.

🧠 Recursive Trace with Memo Use

DPTDCoinChange([1,3,4,5], 7)
→ CCDPTDDfs(7)
├─ Try coin 1 → CCDPTDDfs(6)
│  ├─ Try coin 1 → CCDPTDDfs(5)
│  │  ├─ Try coin 1 → CCDPTDDfs(4)
│  │  │  ├─ Try coin 1 → CCDPTDDfs(3)
│  │  │  │  ├─ Try coin 1 → CCDPTDDfs(2)
│  │  │  │  │  ├─ Try coin 1 → CCDPTDDfs(1)
│  │  │  │  │  │  ├─ Try coin 1 → CCDPTDDfs(0) → return 0
│  │  │  │  │  │  ↳ Memo[1] = 1
│  │  │  │  │  ↳ Memo[2] = 2
│  │  │  │  ├─ Try coin 3 → CCDPTDDfs(0) → return 0
│  │  │  │  ↳ Memo[3] = 1 (min of 2 and 1)
│  │  │  ├─ Try coin 3 → CCDPTDDfs(1) → use Memo[1] = 1
│  │  │  ├─ Try coin 4 → CCDPTDDfs(0) → return 0
│  │  │  ↳ Memo[4] = 1
│  │  ├─ Try coin 3 → CCDPTDDfs(2) → use Memo[2] = 2
│  │  ├─ Try coin 4 → CCDPTDDfs(1) → use Memo[1] = 1
│  │  ├─ Try coin 5 → CCDPTDDfs(0) → return 0
│  │  ↳ Memo[5] = 1
│  ├─ Try coin 3 → CCDPTDDfs(3) → use Memo[3] = 1
│  ├─ Try coin 4 → CCDPTDDfs(2) → use Memo[2] = 2
│  ├─ Try coin 5 → CCDPTDDfs(1) → use Memo[1] = 1
│  ↳ Memo[6] = 2
├─ Try coin 3 → CCDPTDDfs(4) → use Memo[4] = 1
├─ Try coin 4 → CCDPTDDfs(3) → use Memo[3] = 1
├─ Try coin 5 → CCDPTDDfs(2) → use Memo[2] = 2
↳ Memo[7] = 2
✅ Final Result:
DPTDCoinChange([1,3,4,5], 7) → 2 coins
// One optimal combo: 3 + 4 = 7
*/
// Note in this line we are saying try coin 3,
// and then call Dfs on the remainder 7-3 is 4
// so we use Memo[4] which we already computed.
// ├─ Try coin 3 → CCDPTDDfs(4) → use Memo[4] = 1
// so coin 3 (1 coin) + Memo[4] (1 coin) = 2 coins
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