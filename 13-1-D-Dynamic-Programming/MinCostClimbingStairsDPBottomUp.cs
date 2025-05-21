public partial class Solution {
    public int DPBUMinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        int[] dp = new int[n + 1]; // DP array to store the minimum cost to reach each step

        // Iterate from step 2 to n, computing the minimum cost dynamically
        for (int i = 2; i <= n; i++) {
            dp[i] = Math.Min(dp[i - 1] + cost[i - 1],  // Taking one step
                             dp[i - 2] + cost[i - 2]); // Taking two steps
        }

        return dp[n]; // The minimum cost to reach the top
    }
}

/*
Execution Steps for cost = [1,2,1,2,1,1,1]
This table represents the dp array updates during execution.

Step 
𝑖
i	dp[i-2]	cost[i-2]	dp[i-1]	cost[i-1]	dp[i] = min(dp[i-1] + cost[i-1], dp[i-2] + cost[i-2])
i=2	dp[0]=0	cost[0]=1	dp[1]=0	cost[1]=2	dp[2] = min(0+2, 0+1) = 1
i=3	dp[1]=0	cost[1]=2	dp[2]=1	cost[2]=1	dp[3] = min(1+1, 0+2) = 2
i=4	dp[2]=1	cost[2]=1	dp[3]=2	cost[3]=2	dp[4] = min(2+2, 1+1) = 2
i=5	dp[3]=2	cost[3]=2	dp[4]=2	cost[4]=1	dp[5] = min(2+1, 2+2) = 3
i=6	dp[4]=2	cost[4]=1	dp[5]=3	cost[5]=1	dp[6] = min(3+1, 2+1) = 3
i=7	dp[5]=3	cost[5]=1	dp[6]=3	cost[6]=1	dp[7] = min(3+1, 3+1) = 4
Final dp array:
dp = [0, 0, 1, 2, 2, 3, 3, 4]

Final output:
Output: 4

Execution Tree Representation (Notepad-Friendly)
MinCostClimbingStairs(cost)
├── dp[2] = min(dp[1] + cost[1], dp[0] + cost[0]) = 1
│   ├── dp[1] = 0
│   ├── dp[0] = 0
│   └── cost[1] = 2, cost[0] = 1
├── dp[3] = min(dp[2] + cost[2], dp[1] + cost[1]) = 2
│   ├── dp[2] = 1, cost[2] = 1
│   ├── dp[1] = 0, cost[1] = 2
├── dp[4] = min(dp[3] + cost[3], dp[2] + cost[2]) = 2
│   ├── dp[3] = 2, cost[3] = 2
│   ├── dp[2] = 1, cost[2] = 1
├── dp[5] = min(dp[4] + cost[4], dp[3] + cost[3]) = 3
│   ├── dp[4] = 2, cost[4] = 1
│   ├── dp[3] = 2, cost[3] = 2
├── dp[6] = min(dp[5] + cost[5], dp[4] + cost[4]) = 3
│   ├── dp[5] = 3, cost[5] = 1
│   ├── dp[4] = 2, cost[4] = 1
├── dp[7] = min(dp[6] + cost[6], dp[5] + cost[5]) = 4
│   ├── dp[6] = 3, cost[6] = 1
│   ├── dp[5] = 3, cost[5] = 1
└── Final result = dp[7] = **4**
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