public partial class Solution {
    
    List<List<int>> CSres = new List<List<int>>();

    public void CSbacktrack(int i, List<int> cur, int total, int[] nums, int target) {
        if(total == target) {
            CSres.Add(cur.ToList());
            return;
        }
        
        if(total > target || i >= nums.Length) return;
        
        cur.Add(nums[i]);
        CSbacktrack(i, cur, total + nums[i], nums, target);
        cur.Remove(cur.Last());

        CSbacktrack(i + 1, cur, total, nums, target);
        
    }
    public List<List<int>> CombinationSum(int[] nums, int target) {
        CSbacktrack(0, new List<int>(), 0, nums, target);
        return CSres;
    }
}

/*
Each node in the tree represents a recursive call, showing:

i: Current index in nums
cur: Current combination
total: Sum of numbers in cur
The tree grows recursively as we:

Include nums[i] (add nums[i] to cur and increase total).
Skip nums[i] (move to the next index, i + 1, without adding nums[i]).

Output:

backtrack(0, [], 0)
├── backtrack(0, [2], 2)
│   ├── backtrack(0, [2, 2], 4)
│   │   ├── backtrack(0, [2, 2, 2], 6)
│   │   │   ├── backtrack(0, [2, 2, 2, 2], 8)
│   │   │   │   ├── backtrack(0, [2, 2, 2, 2, 2], 10) -> Prune (total > target)
│   │   │   │   └── backtrack(1, [2, 2, 2, 2], 8)
│   │   │   │       ├── backtrack(1, [2, 2, 2, 2, 5], 13) -> Prune (total > target)
│   │   │   │       └── backtrack(2, [2, 2, 2, 2], 8)
│   │   │   │           ├── backtrack(2, [2, 2, 2, 2, 6], 14) -> Prune (total > target)
│   │   │   │           └── backtrack(3, [2, 2, 2, 2], 8)
│   │   │   │               ├── backtrack(3, [2, 2, 2, 2, 9], 17) -> Prune (total > target)
│   │   │   │               └── backtrack(4, [2, 2, 2, 2], 8) -> Prune (i >= nums.Length)
│   │   │   └── backtrack(1, [2, 2, 2], 6)
│   │   │       ├── backtrack(1, [2, 2, 2, 5], 11) -> Prune (total > target)
│   │   │       └── backtrack(2, [2, 2, 2], 6)
│   │   │           ├── backtrack(2, [2, 2, 2, 6], 12) -> Prune (total > target)
│   │   │           └── backtrack(3, [2, 2, 2], 6)
│   │   │               ├── backtrack(3, [2, 2, 2, 9], 15) -> Prune (total > target)
│   │   │               └── backtrack(4, [2, 2, 2], 6) -> Prune (i >= nums.Length)
│   │   └── backtrack(1, [2, 2], 4)
│   │       ├── backtrack(1, [2, 2, 5], 9) -> Add [2, 2, 5]
│   │       └── backtrack(2, [2, 2], 4)
│   │           ├── backtrack(2, [2, 2, 6], 10) -> Prune (total > target)
│   │           └── backtrack(3, [2, 2], 4)
│   │               ├── backtrack(3, [2, 2, 9], 13) -> Prune (total > target)
│   │               └── backtrack(4, [2, 2], 4) -> Prune (i >= nums.Length)
│   └── backtrack(1, [2], 2)
│       ├── backtrack(1, [2, 5], 7)
│       │   ├── backtrack(1, [2, 5, 5], 12) -> Prune (total > target)
│       │   └── backtrack(2, [2, 5], 7)
│       │       ├── backtrack(2, [2, 5, 6], 13) -> Prune (total > target)
│       │       └── backtrack(3, [2, 5], 7)
│       │           ├── backtrack(3, [2, 5, 9], 16) -> Prune (total > target)
│       │           └── backtrack(4, [2, 5], 7) -> Prune (i >= nums.Length)
│       └── backtrack(2, [2], 2)
│           ├── backtrack(2, [2, 6], 8)
│           │   ├── backtrack(2, [2, 6, 6], 14) -> Prune (total > target)
│           │   └── backtrack(3, [2, 6], 8)
│           │       ├── backtrack(3, [2, 6, 9], 17) -> Prune (total > target)
│           │       └── backtrack(4, [2, 6], 8) -> Add all recursion which isn valid ignore

In the parameter list i (the first parameter) is closely tied to the number that gets added
to cur at the end, such that when we've tried adding all the numbers from the original list
to cur, i will equal 4 (after adding 9) and i >= nums.Lenght and we´ll return.

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