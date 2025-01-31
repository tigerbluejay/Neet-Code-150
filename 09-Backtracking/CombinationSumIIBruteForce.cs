public partial class Solution {
    private HashSet<string> CS2BFres;
    public List<List<int>> CombinationSum2BF(int[] candidates, int target) {
        CS2BFres = new HashSet<string>();
        Array.Sort(candidates);
        GenerateSubsets(candidates, target, 0, new List<int>(), 0);
        return CS2BFres.Select(s => s.Split(',').Select(int.Parse).ToList()).ToList();
    }

    private void GenerateSubsets(int[] candidates, int target, int i, List<int> cur, int total) {
        if (total == target) {
            CS2BFres.Add(string.Join(",", cur));
            return;
        }
        if (total > target || i == candidates.Length) {
            return;
        }

        cur.Add(candidates[i]);
        GenerateSubsets(candidates, target, i + 1, cur, total + candidates[i]);
        cur.RemoveAt(cur.Count - 1);

        GenerateSubsets(candidates, target, i + 1, cur, total);
    }
}
/*
Tree Representation
Each node is written as (i, cur, total) where:

i: Current index in candidates.
cur: Current subset being formed.
total: Current sum of elements in cur.
css
Copy code
(0, [], 0)
├── (1, [1], 1) - Include 1
│   ├── (2, [1,2], 3) - Include 2
│   │   ├── (3, [1,2,2], 5) - Include 2
│   │   │   ├── (4, [1,2,2,4], 9) - Total > target, backtrack
│   │   │   └── (4, [1,2,2], 5) - Skip 4
│   │   │       ├── (5, [1,2,2,5], 10) - Total > target, backtrack
│   │   │       └── (5, [1,2,2], 5) - Skip 5
│   │   ├── (3, [1,2], 3) - Skip 2
│   │   │   ├── (4, [1,2,4], 7) - Include 4
│   │   │   │   ├── (5, [1,2,4,5], 12) - Total > target, backtrack
│   │   │   │   └── (5, [1,2,4], 7) - Skip 5
│   │   │   │       ├── (6, [1,2,4,6], 13) - Total > target, backtrack
│   │   │   │       └── (6, [1,2,4], 7) - Skip 6
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