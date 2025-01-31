public partial class Solution {
    public List<List<int>> CS2BHMres = new List<List<int>>();
    public Dictionary<int, int> count = new Dictionary<int, int>();
    public List<List<int>> CombinationSum2BTHM(int[] nums, int target) {
        List<int> cur = new List<int>();
        List<int> A = new List<int>();
        
        foreach (int num in nums) {
            if (!count.ContainsKey(num)) {
                A.Add(num);
            }
            if (count.ContainsKey(num)) {
                count[num]++;
            } else {
                count[num] = 1;
            }
        }
        CS2BHMBacktrack(A, target, cur, 0);
        return CS2BHMres;
    }

    // note the the nums on the argument list, refers to A that is being passed
    // to the Backtrack method, so inside Backtrack, nums refers to A and not the
    // original nums used in the code above.
    private void CS2BHMBacktrack(List<int> nums, int target, List<int> cur, int i) {
        if (target == 0) {
            CS2BHMres.Add(new List<int>(cur));
            return;
        }
        if (target < 0 || i >= nums.Count) {
            return;
        }

        if (count[nums[i]] > 0) {
            cur.Add(nums[i]);
            count[nums[i]]--;
            CS2BHMBacktrack(nums, target - nums[i], cur, i);
            count[nums[i]]++;
            cur.RemoveAt(cur.Count - 1);
        }

        CS2BHMBacktrack(nums, target, cur, i + 1);
    }
}
/*

Tree Representation
Input:
nums = [9, 2, 2, 4, 6, 1, 5],
target = 8.

After sorting nums and constructing the hashmap count, the unique candidates are:
A = [1, 2, 4, 5, 6, 9],
with count = {1: 1, 2: 2, 4: 1, 5: 1, 6: 1, 9: 1}.

Each node in the tree is represented as (i, cur, target, count), where:

i: Current index in the unique candidates A.
cur: Current subset being formed.
target: Remaining target value to reach.
count: Updated frequency map showing how many times each candidate can still be used.

Tree

(0, [], 8, {1:1, 2:2, 4:1, 5:1, 6:1, 9:1})
├── (0, [1], 7, {1:0, 2:2, 4:1, 5:1, 6:1, 9:1}) - Include 1
│   └── (1, [1,2], 5, {1:0, 2:1, 4:1, 5:1, 6:1, 9:1}) - Include 2
│       ├── (1, [1,2,2], 3, {1:0, 2:0, 4:1, 5:1, 6:1, 9:1}) - Include 2
│       │   └── (2, [1,2,2,4], -1, ...) - Total < 0, backtrack
│       ├── (2, [1,2,2], 3, ...) - Skip 4
│       │   └── (3, [1,2,2,5], -2, ...) - Total < 0, backtrack
│       └── ...
├── (1, [2], 6, {1:1, 2:1, 4:1, 5:1, 6:1, 9:1}) - Include 2
│   ├── (1, [2,2], 4, {1:1, 2:0, 4:1, 5:1, 6:1, 9:1}) - Include 2
│   │   ├── (2, [2,2,4], 0, {1:1, 2:0, 4:0, 5:1, 6:1, 9:1}) - **Found a combination**
│   │   └── (3, [2,2,5], -1, ...) - Total < 0, backtrack
│   └── (2, [2], 4, ...) - Skip 4
│       ├── (3, [2,5], -1, ...) - Total < 0, backtrack
│       └── (4, [2,6], 0, {1:1, 2:1, 4:1, 5:1, 6:0, 9:1}) - **Found a combination**
├── (2, [4], 4, {1:1, 2:2, 4:0, 5:1, 6:1, 9:1}) - Include 4
│   └── (3, [4,5], -1, ...) - Total < 0, backtrack
├── (3, [5], 3, ...) - Skip 5
│   └── (4, [6], 2, ...) - Include 6
│       └── ...

In CombinationSum2BTHM, duplicates are reduced to a single entry in the unique 
list (A), and their usage is controlled by the count dictionary.

The recursion tree for CombinationSum2BTHM is more compact because duplicates 
are handled via count. Each unique candidate is processed independently, and 
the algorithm stops further recursion when its count is exhausted.
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