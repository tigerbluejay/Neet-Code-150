public partial class Solution {
    // Main function to find the minimum cost to climb stairs starting from step 0 or step 1
    public int RMinCostClimbingStairs(int[] cost) {
        // Choose the minimum cost starting from either index 0 or index 1
        return Math.Min(MCCSRDfs(cost, 0), MCCSRDfs(cost, 1));
    }
    
    // Recursive function using DFS to find the minimum cost from index `i`
    private int MCCSRDfs(int[] cost, int i) {
        // Base case: if index is out of bounds, return 0 (no cost)
        if (i >= cost.Length) {
            return 0;
        }
        
        // Cost at current step + minimum of the next two possible steps
        return cost[i] + Math.Min(MCCSRDfs(cost, i + 1),
                                  MCCSRDfs(cost, i + 2));
    }
}

/*

Execution Tree for cost = [1,2,1,2,1,1,1]
This tree visually represents the recursive calls made for MCCSRDfs(cost, 0) and 
MCCSRDfs(cost, 1). You can copy-paste this into Notepad for easy reference.

RMinCostClimbingStairs(cost)  
├── MCCSRDfs(0) -> cost[0] + min(MCCSRDfs(1), MCCSRDfs(2))
│   ├── MCCSRDfs(1) -> cost[1] + min(MCCSRDfs(2), MCCSRDfs(3))
│   │   ├── MCCSRDfs(2) -> cost[2] + min(MCCSRDfs(3), MCCSRDfs(4))
│   │   │   ├── MCCSRDfs(3) -> cost[3] + min(MCCSRDfs(4), MCCSRDfs(5))
│   │   │   │   ├── MCCSRDfs(4) -> cost[4] + min(MCCSRDfs(5), MCCSRDfs(6))
│   │   │   │   │   ├── MCCSRDfs(5) -> cost[5] + min(MCCSRDfs(6), MCCSRDfs(7))
│   │   │   │   │   │   ├── MCCSRDfs(6) -> cost[6] + min(MCCSRDfs(7), MCCSRDfs(8))
│   │   │   │   │   │   │   ├── MCCSRDfs(7) -> 0 (Base Case)
│   │   │   │   │   │   │   ├── MCCSRDfs(8) -> 0 (Base Case)
│   │   │   │   │   │   │   └── MCCSRDfs(6) = 1 + min(0,0) = 1
│   │   │   │   │   │   ├── MCCSRDfs(7) -> 0 (Base Case)
│   │   │   │   │   │   └── MCCSRDfs(5) = 1 + min(1,0) = 1
│   │   │   │   │   ├── MCCSRDfs(6) -> 1 (Cached)
│   │   │   │   │   └── MCCSRDfs(4) = 1 + min(1,1) = 2
│   │   │   │   ├── MCCSRDfs(5) -> 1 (Cached)
│   │   │   │   └── MCCSRDfs(3) = 2 + min(2,1) = 3
│   │   │   ├── MCCSRDfs(4) -> 2 (Cached)
│   │   │   └── MCCSRDfs(2) = 1 + min(3,2) = 3
│   │   ├── MCCSRDfs(3) -> 3 (Cached)
│   │   └── MCCSRDfs(1) = 2 + min(3,3) = 5
│   ├── MCCSRDfs(2) -> 3 (Cached)
│   └── MCCSRDfs(0) = 1 + min(5,3) = 4
├── MCCSRDfs(1) -> 5 (Cached)
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