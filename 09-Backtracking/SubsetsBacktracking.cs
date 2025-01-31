
public partial class Solution
{

    public List<List<int>> Subsets(int[] nums)
    {
        var res = new List<List<int>>();
        var subset = new List<int>();
        SubBDfs(nums, 0, subset, res);
        return res;
    }

    private void SubBDfs(int[] nums, int i, List<int> subset, List<List<int>> res)
    {
        if (i >= nums.Length)
        {
            res.Add(new List<int>(subset));
            return;
        }
        subset.Add(nums[i]);
        SubBDfs(nums, i + 1, subset, res);
        subset.RemoveAt(subset.Count - 1);
        SubBDfs(nums, i + 1, subset, res);
    }
}

/* Visualization of calls for input = [1,2,3]

Dfs(nums, 0, [])
├── Include 1 → Dfs(nums, 1, [1])
│    ├── Include 2 → Dfs(nums, 2, [1, 2])
│    │    ├── Include 3 → Dfs(nums, 3, [1, 2, 3]) → Add [1, 2, 3]
│    │    └── Exclude 3 → Dfs(nums, 3, [1, 2]) → Add [1, 2]
│    └── Exclude 2 → Dfs(nums, 2, [1])
│         ├── Include 3 → Dfs(nums, 3, [1, 3]) → Add [1, 3]
│         └── Exclude 3 → Dfs(nums, 3, [1]) → Add [1]
└── Exclude 1 → Dfs(nums, 1, [])
     ├── Include 2 → Dfs(nums, 2, [2])
     │    ├── Include 3 → Dfs(nums, 3, [2, 3]) → Add [2, 3]
     │    └── Exclude 3 → Dfs(nums, 3, [2]) → Add [2]
     └── Exclude 2 → Dfs(nums, 2, [])
          ├── Include 3 → Dfs(nums, 3, [3]) → Add [3]
          └── Exclude 3 → Dfs(nums, 3, []) → Add []

Result [[1, 2, 3], [1, 2], [1, 3], [1], [2, 3], [2], [3], [] ]

/*

Subsets

Given an array nums of unique integers, return all possible subsets of nums.

The solution set must not contain duplicate subsets. You may return the solution
in any order.

Example 1:

Input: nums = [1, 2, 3]

Output:[[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

Example 2:
Input: nums = [7]

Output:[[],[7]]
Constraints:

1 <= nums.length <= 10
- 10 <= nums[i] <= 10

*/