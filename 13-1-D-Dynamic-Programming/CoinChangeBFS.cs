public partial class Solution {
    public int BFSCoinChange(int[] coins, int amount) {
        if (amount == 0) return 0; // base case: 0 coins to make 0

        Queue<int> q = new Queue<int>(); // BFS queue
        q.Enqueue(0); // start from amount 0
        bool[] seen = new bool[amount + 1]; // track visited amounts
        seen[0] = true;
        int res = 0; // res = number of coins used so far (levels in BFS)

        // Start BFS traversal
        while (q.Count > 0) {
            res++; // go to next level (1 more coin)
            int size = q.Count;

            for (int i = 0; i < size; i++) {
                int cur = q.Dequeue(); // current amount

                // Try all coin additions from current amount
                foreach (int coin in coins) {
                    int nxt = cur + coin;

                    if (nxt == amount) return res; // Found the exact amount
                    if (nxt > amount || seen[nxt]) continue; // Skip if invalid or seen

                    seen[nxt] = true; // Mark amount as seen
                    q.Enqueue(nxt);   // Add new state to queue
                }
            }
        }

        return -1; // Not possible to make the amount
    }
}
/*
🌳 2. Notepad-Friendly BFS Tree for coins = [1, 3, 4, 5], amount = 7
We'll simulate the levels of BFS as layers. Each level represents adding 1 
more coin.

Level 0 (0 coins used):
    [0]

Level 1 (1 coin used):
    0 + 1 = 1
    0 + 3 = 3
    0 + 4 = 4
    0 + 5 = 5
    → [1, 3, 4, 5]

Level 2 (2 coins used):
    1 + 1 = 2
    1 + 3 = 4 (already seen)
    1 + 4 = 5 (already seen)
    1 + 5 = 6

    3 + 1 = 4 (already seen)
    3 + 3 = 6 (already seen)
    3 + 4 = 7 ✅ Found!
    → return 2
✅ Final Output:
BFSCoinChange([1, 3, 4, 5], 7) → 2
// Path example: 0 → 3 → 4 = 7
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