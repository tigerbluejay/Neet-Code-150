// still have trouble visualizing the interaction between recursion and the for loop
// particularly as it relates to what values j takes on each step
// might need to debug to see it further, debug while visualizing the treeß
public partial class Solution {
    List<List<int>> CSOres;
    public List<List<int>> CombinationSumO(int[] nums, int target) {
        CSOres = new List<List<int>>();
        Array.Sort(nums);
        CSOdfs(0, new List<int>(), 0, nums, target);
        return CSOres;
    }

    private void CSOdfs(int i, List<int> cur, int total, int[] nums, int target) {
        if (total == target) {
            CSOres.Add(new List<int>(cur));
            return;
        }
        
        for (int j = i; j < nums.Length; j++) {
            if (total + nums[j] > target) {
                return;
            }
            cur.Add(nums[j]);
            CSOdfs(j, cur, total + nums[j], nums, target);
            cur.RemoveAt(cur.Count - 1);
        }
    }
}
/*
dfs(0, [], 0) [j = 0]  // Loop over j = [0, 1, 2, 3]
├── dfs(0, [2], 2) [j = 0]  // Loop over j = [0, 1, 2, 3]
│   ├── dfs(0, [2, 2], 4) [j = 0]  // Loop over j = [0, 1, 2, 3]
│   │   ├── dfs(0, [2, 2, 2], 6) [j = 0]  // Loop over j = [0, 1, 2, 3]
│   │   │   ├── dfs(0, [2, 2, 2, 2], 8) [j = 0]  // Loop over j = [0, 1, 2, 3]
│   │   │   │   └── dfs(0, [2, 2, 2, 2, 2], 10) [j = 0] -> Prune (total > target)
│   │   │   └── Exit (loop exhausted, j = 0)
│   │   └── dfs(1, [2, 2, 2], 6) [j = 1]  // Loop over j = [1, 2, 3]
│   │       ├── dfs(1, [2, 2, 2, 5], 11) [j = 1] -> Prune (total > target)
│   │       └── Exit (loop exhausted, j = 1)
│   └── dfs(1, [2, 2], 4) [j = 1]  // Loop over j = [1, 2, 3]
│       ├── dfs(1, [2, 2, 5], 9) [j = 1] -> Add [2, 2, 5]
│       └── dfs(2, [2, 2], 4) [j = 2]  // Loop over j = [2, 3]
│           ├── dfs(2, [2, 2, 6], 10) [j = 2] -> Prune (total > target)
│           └── dfs(3, [2, 2], 4) [j = 3]  // Loop over j = [3]
│               ├── dfs(3, [2, 2, 9], 13) [j = 3] -> Prune (total > target)
│               └── Exit (loop exhausted, j = 3)
├── dfs(1, [5], 5) [j = 1]  // Loop over j = [1, 2, 3]
│   ├── dfs(1, [5, 5], 10) [j = 1] -> Prune (total > target)
│   └── dfs(2, [5], 5) [j = 2]  // Loop over j = [2, 3]
│       ├── dfs(2, [5, 6], 11) [j = 2] -> Prune (total > target)
│       └── dfs(3, [5], 5) [j = 3]  // Loop over j = [3]
│           ├── dfs(3, [5, 9], 14) [j = 3] -> Prune (total > target)
│           └── Exit (loop exhausted, j = 3)
├── dfs(2, [6], 6) [j = 2]  // Loop over j = [2, 3]
│   ├── dfs(2, [6, 6], 12) [j = 2] -> Prune (total > target)
│   └── dfs(3, [6], 6) [j = 3]  // Loop over j = [3]
│       ├── dfs(3, [6, 9], 15) [j = 3] -> Prune (total > target)
│       └── Exit (loop exhausted, j = 3)
└── dfs(3, [9], 9) [j = 3] -> Add [9]
    └── Exit (loop exhausted, j = 3)

The for loop eliminates repeated recursive calls for the same index, 
unlike the previous backtrack implementation.
Each recursive path explores adding a specific nums[j] to cur while pruning branches 
when total + nums[j] > target.
The sorted nums array ensures that once total + nums[j] > target for a specific j, 
further iterations of the loop are unnecessary.

"Loop exhausted" happens when there are no more indices to iterate over in the for 
loop for the current recursive call.
It’s not obvious from the parameters in the tree because the tree reflects recursive calls,
not the j loop progress inside each call.
To better visualize this, think of each recursive call as handling a slice of nums starting 
from i, and the loop simply runs through that slice.

j = 0:
Adds nums[0] = 2 → dfs(0, [2, 2], 4).
j = 1:
Adds nums[1] = 5 → dfs(1, [2, 5], 9) → Adds [2, 5].
j = 2:
Adds nums[2] = 6 → dfs(2, [2, 6], 8).
j = 3:
Adds nums[3] = 9 → dfs(3, [2, 9], 11) → Prune.


*/
/*

Combination Sum

You are given an array of distinct integers nums and a target integer target. 
Your task is to return a list of all unique combinations of nums where the chosen 
numbers sum to target.

The same number may be chosen from nums an unlimited number of times. 
Two combinations are the same if the frequency of each of the chosen numbers 
is the same, otherwise they are different.

You may return the combinations in any order and the order of the numbers in 
each combination can be in any order.

Example 1:
Input: 
nums = [2,5,6,9] 
target = 9
Output: [[2,2,5],[9]]
Explanation:
2 + 2 + 5 = 9. We use 2 twice, and 5 once.
9 = 9. We use 9 once.

Example 2:
Input: 
nums = [3,4,5]
target = 16
Output: [[3,3,3,3,4],[3,3,5,5],[4,4,4,4],[3,4,4,5]]

Example 3:
Input: 
nums = [3]
target = 5
Output: []

Constraints:
All elements of nums are distinct.
1 <= nums.length <= 20
2 <= nums[i] <= 30
2 <= target <= 30
*/