public partial class Solution {
    int[] MCCSDPTDmemo; // Memoization array to store previously computed results
    
    public int DPTDMinCostClimbingStairs(int[] cost) {
        // Initialize memoization array with -1 (indicating uncomputed values)
        MCCSDPTDmemo = new int[cost.Length];
        Array.Fill(MCCSDPTDmemo, -1);
        
        // Compute the minimum cost starting from either step 0 or step 1
        return Math.Min(MCCSDPTDDfs(cost, 0), MCCSDPTDDfs(cost, 1));
    }
    
    private int MCCSDPTDDfs(int[] cost, int i) {
        // Base case: if we go beyond the last step, no cost is incurred
        if (i >= cost.Length) {
            return 0;
        }
        
        // If we have already computed the result for this step, return it
        if (MCCSDPTDmemo[i] != -1) {
            return MCCSDPTDmemo[i];
        }
        
        // Compute and store the minimum cost for this step
        MCCSDPTDmemo[i] = cost[i] + Math.Min(MCCSDPTDDfs(cost, i + 1), MCCSDPTDDfs(cost, i + 2));
        
        return MCCSDPTDmemo[i];
    }
}
/*
Execution Tree for cost = [1,2,1,2,1,1,1]
This tree visually represents the recursive calls with memoization. 
When a value is computed once, it is reused instead of recalculating it.

MinCostClimbingStairs(cost)  
├── Dfs(0) -> cost[0] + min(Dfs(1), Dfs(2))
│   ├── Dfs(1) -> cost[1] + min(Dfs(2), Dfs(3))
│   │   ├── Dfs(2) -> cost[2] + min(Dfs(3), Dfs(4))
│   │   │   ├── Dfs(3) -> cost[3] + min(Dfs(4), Dfs(5))
│   │   │   │   ├── Dfs(4) -> cost[4] + min(Dfs(5), Dfs(6))
│   │   │   │   │   ├── Dfs(5) -> cost[5] + min(Dfs(6), Dfs(7))
│   │   │   │   │   │   ├── Dfs(6) -> cost[6] + min(Dfs(7), Dfs(8))
│   │   │   │   │   │   │   ├── Dfs(7) -> 0 (Base Case)
│   │   │   │   │   │   │   ├── Dfs(8) -> 0 (Base Case)
│   │   │   │   │   │   │   └── Dfs(6) = 1 + min(0,0) = 1 (Stored in memo[6])
│   │   │   │   │   │   ├── Dfs(7) -> 0 (Base Case)
│   │   │   │   │   │   └── Dfs(5) = 1 + min(1,0) = 1 (Stored in memo[5])
│   │   │   │   │   ├── Dfs(6) -> 1 (Memoized)
│   │   │   │   │   └── Dfs(4) = 1 + min(1,1) = 2 (Stored in memo[4])
│   │   │   │   ├── Dfs(5) -> 1 (Memoized)
│   │   │   │   └── Dfs(3) = 2 + min(2,1) = 3 (Stored in memo[3])
│   │   │   ├── Dfs(4) -> 2 (Memoized)
│   │   │   └── Dfs(2) = 1 + min(3,2) = 3 (Stored in memo[2])
│   │   ├── Dfs(3) -> 3 (Memoized)
│   │   └── Dfs(1) = 2 + min(3,3) = 5 (Stored in memo[1])
│   ├── Dfs(2) -> 3 (Memoized)
│   └── Dfs(0) = 1 + min(5,3) = 4 (Stored in memo[0])
├── Dfs(1) -> 5 (Memoized)
└── Final result = min(4,5) = **4**
*/
/*
Min Cost Climbing Stairs

Note: Although the wording of the problem doesn't specify it, the top is not the
last item in the array, but the first element that is out of bounds.

You are given an array of integers cost where cost[i] is the cost of taking a step 
from the ith floor of a staircase. After paying the cost, you can step to either 
the (i + 1)th floor or the (i + 2)th floor.

You may choose to start at the index 0 or the index 1 floor.

Return the minimum cost to reach the top of the staircase, i.e. just past the 
last index in cost.

Example 1:
Input: cost = [1,2,3]
Output: 2
Explanation: We can start at index = 1 and pay the cost of cost[1] = 2 and take two 
steps to reach the top. The total cost is 2.

Example 2:
Input: cost = [1,2,1,2,1,1,1]
Output: 4
Explanation: Start at index = 0.
Pay the cost of cost[0] = 1 and take two steps to reach index = 2.
Pay the cost of cost[2] = 1 and take two steps to reach index = 4.
Pay the cost of cost[4] = 1 and take two steps to reach index = 6.
Pay the cost of cost[6] = 1 and take one step to reach the top.
The total cost is 4.

Constraints:
2 <= cost.length <= 100
0 <= cost[i] <= 100
*/