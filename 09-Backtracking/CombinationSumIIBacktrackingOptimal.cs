public partial class Solution {
    private static List<List<int>> CS2BOres = new List<List<int>>();

    public List<List<int>> CombinationSum2BTO(int[] candidates, int target) {
        CS2BOres.Clear();
        Array.Sort(candidates);

        CS2BOdfs(0, new List<int>(), 0, candidates, target);
        return CS2BOres;
    }

    private void CS2BOdfs(int idx, List<int> path, int cur, int[] candidates, int target) {
        if (cur == target) {
            CS2BOres.Add(new List<int>(path));
            return;
        }
        for (int i = idx; i < candidates.Length; i++) {
            if (i > idx && candidates[i] == candidates[i - 1]) {
                continue;
            }
            if (cur + candidates[i] > target) {
                break;
            }

            path.Add(candidates[i]);
            CS2BOdfs(i + 1, path, cur + candidates[i], candidates, target);
            path.RemoveAt(path.Count - 1);
        }
    }
}
/*
Tree Representation
Input
candidates = [9, 2, 2, 4, 6, 1, 5]
target = 8.

Sorted Array
candidates = [1, 2, 2, 4, 5, 6, 9].

Each node in the tree is represented as (idx, path, cur, remaining), where:

idx: Index in candidates for the current recursion level.
path: Current subset being formed.
cur: Current sum of the subset.
remaining: Remaining target (target - cur).
Tree
css
Copy code
(0, [], 0, 8)
├── (1, [1], 1, 7) - Include 1
│   ├── (2, [1,2], 3, 5) - Include 2
│   │   ├── (3, [1,2,2], 5, 3) - Include 2
│   │   │   ├── (4, [1,2,2,4], 9, -1) - Exceeds target, backtrack
│   │   │   └── (4, [1,2,2], 5, 3) - Skip 4
│   │   ├── (4, [1,2,4], 7, 1) - Include 4
│   │   │   ├── (5, [1,2,4,5], 12, -4) - Exceeds target, backtrack
│   │   │   └── ...
│   │   └── (5, [1,2,5], 8, 0) - **Found a combination**
│   ├── (3, [1,4], 5, 3) - Skip second 2, include 4
│   │   └── ...
│   └── ...
├── (1, [2], 2, 6) - Skip 1, include 2
│   ├── (2, [2,2], 4, 4) - Include 2
│   │   ├── (3, [2,2,4], 8, 0) - **Found a combination**
│   │   └── ...
│   ├── (3, [2,4], 6, 2) - Skip second 2, include 4
│   │   ├── (4, [2,4,5], 11, -3) - Exceeds target, backtrack
│   │   └── ...
│   └── (4, [2,6], 8, 0) - **Found a combination**
├── (2, [4], 4, 4) - Skip all 2's, include 4
│   ├── (3, [4,5], 9, -1) - Exceeds target, backtrack
│   └── ...
└── (3, [5], 5, 3) - Skip 4, include 5
    └── (4, [5,6], 11, -3) - Exceeds target, backtrack

1. Duplicate Handling
CombinationSum2BTO uses a sorted array and a continue statement inside the loop 
to skip duplicate elements. If candidates[i] == candidates[i - 1] and i > idx, 
the duplicate is skipped.

2. Recursive Call Structure
CombinationSum2BTO uses a loop inside the recursive function (dfs) to iterate 
through the candidates starting from idx. 

3. Early Termination
CombinationSum2BTO terminates early when cur + candidates[i] > target 
by using a break statement. This relies on the sorted array to ensure 
that all subsequent candidates would also exceed the target.

4. Efficiency
CombinationSum2BTO is slightly more efficient due to the use of:
    Early termination with break.
    Duplicate skipping with continue.

5. State Representation
In CombinationSum2BTO, the state of the recursion is maintained using the 
sorted array candidates, a path list, and the current sum (cur).
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