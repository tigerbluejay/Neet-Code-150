public partial class Solution {
    private List<List<int>> CS2Bres;

    public List<List<int>> CombinationSum2BT(int[] candidates, int target) {
        CS2Bres = new List<List<int>>();
        Array.Sort(candidates);
        CS2BDfs(candidates, target, 0, new List<int>(), 0);
        return CS2Bres;
    }

    private void CS2BDfs(int[] candidates, int target, int i, List<int> cur, int total) {
        if (total == target) {
            CS2Bres.Add(new List<int>(cur));
            return;
        }
        if (total > target || i == candidates.Length) {
            return;
        }

        cur.Add(candidates[i]);
        // the first call to Dfs includes duplicates
        CS2BDfs(candidates, target, i + 1, cur, total + candidates[i]);
        cur.RemoveAt(cur.Count - 1);

        // because of the while loop, the second recursive call to Dfs
        // does not include duplicates, while skips over all subsequent 
        // candidates that are identical to candidates[i].
        while (i + 1 < candidates.Length && candidates[i] == candidates[i + 1]) {
            i++;
        }
        CS2BDfs(candidates, target, i + 1, cur, total);
    }
}

/*
The tree representation for the CombinationSum2BT algorithm will be similar 
to the CombinationSum2BF algorithm, with one key difference:

The backtracking optimization prevents duplicate branches. If a candidate is 
the same as the next one (candidates[i] == candidates[i + 1]), it skips the 
duplicate by incrementing i in the loop.
*/
/*

Tree Representation
Each node is written as (i, cur, total) where:

i: Current index in candidates.
cur: Current subset being formed.
total: Current sum of elements in cur.

(0, [], 0)
├── (1, [1], 1) - Include 1
│   ├── (2, [1,2], 3) - Include 2
│   │   ├── (3, [1,2,2], 5) - Include 2
│   │   │   ├── (4, [1,2,2,4], 9) - Total > target, backtrack
│   │   │   └── (4, [1,2,2], 5) - Skip 4
│   │   ├── (3, [1,2], 3) - Skip 2 (duplicates skipped here)
│   │   │   ├── (4, [1,2,4], 7) - Include 4
│   │   │   │   ├── (5, [1,2,4,5], 12) - Total > target, backtrack
│   │   │   │   └── (5, [1,2,4], 7) - Skip 5
│   │   │   └── (4, [1,2], 3) - Skip 4
│   │   │       ├── (5, [1,2,5], 8) - **Found a combination**
│   │   │       └── (5, [1,2], 3) - Skip 5
│   │   │           ├── (6, [1,2,6], 9) - Total > target, backtrack
│   │   │           └── (6, [1,2], 3) - Skip 6
│   ├── (2, [1], 1) - Skip 2
│   │   ├── ...
│   │   └── ...
├── (1, [], 0) - Skip 1
│   ├── (2, [2], 2) - Include 2
│   │   ├── ...
│   │   └── ...
│   └── ...

Key Differences in Backtracking (BT) vs Brute Force (BF)
Duplicate Skipping:

The while (i + 1 < candidates.Length && candidates[i] == candidates[i + 1]) 
ensures that duplicate subsets are pruned.
For example, after exploring the branch [1, 2, 2], 
it skips the second occurrence of 2 in the sorted array and avoids 
redundant exploration.

Pruned Tree:
The recursion tree is smaller because duplicate subsets are skipped at every level.
*/
/*
Combination Sum II

You are given an array of integers candidates, which may contain duplicates, 
and a target integer target. Your task is to return a list of all unique 
combinations of candidates where the chosen numbers sum to target.

Each element from candidates may be chosen at most once within a combination. 
The solution set must not contain duplicate combinations.

You may return the combinations in any order and the order of the numbers 
in each combination can be in any order.

Example 1:
Input: candidates = [9,2,2,4,6,1,5], target = 8
Output: [
  [1,2,5],
  [2,2,4],
  [2,6]
]

Example 2:
Input: candidates = [1,2,3,4,5], target = 7
Output: [
  [1,2,4],
  [2,5],
  [3,4]
]

Constraints:
1 <= candidates.length <= 100
1 <= candidates[i] <= 50
1 <= target <= 30

*/