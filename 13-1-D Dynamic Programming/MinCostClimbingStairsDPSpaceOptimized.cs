public partial class Solution {
    public int DPSOMinCostClimbingStairs(int[] cost) {
        // Start iterating from the third-to-last step down to the first step
        for (int i = cost.Length - 3; i >= 0; i--) {
            // Update cost[i] to store the minimum cost to reach the top from step i
            cost[i] += Math.Min(cost[i + 1], cost[i + 2]);
        }
        // The answer is the minimum cost of starting from either step 0 or step 1
        return Math.Min(cost[0], cost[1]);
    }
}
/*
Execution Steps for cost = [1,2,1,2,1,1,1]
This approach modifies the original cost array in-place.

Step 
𝑖
i	    cost[i] Before	cost[i+1]	cost[i+2]	cost[i] After (cost[i] += min(cost[i+1], cost[i+2]))
i=4	            1	        1	        1	        1 + min(1,1) = 2
i=3	            2	        2	        1	        2 + min(2,1) = 3
i=2	            1	        3	        2	        1 + min(3,2) = 3
i=1	            2	        3	        3	        2 + min(3,3) = 5
i=0	            1	        5	        3	        1 + min(5,3) = 4

Final modified cost array:
[4, 5, 3, 3, 2, 1, 1]

Final result:
Output: 4

Execution Tree Representation (Notepad-Friendly)
MinCostClimbingStairs(cost)
├── Updating cost[4] = cost[4] + min(cost[5], cost[6]) = 1 + min(1,1) = 2
├── Updating cost[3] = cost[3] + min(cost[4], cost[5]) = 2 + min(2,1) = 3
├── Updating cost[2] = cost[2] + min(cost[3], cost[4]) = 1 + min(3,2) = 3
├── Updating cost[1] = cost[1] + min(cost[2], cost[3]) = 2 + min(3,3) = 5
├── Updating cost[0] = cost[0] + min(cost[1], cost[2]) = 1 + min(5,3) = 4
└── Final result = min(cost[0], cost[1]) = **4**
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