public partial class Solution {
    private List<List<int>> SIIBIIres = new List<List<int>>();
    public List<List<int>> SubsetsWithDupBTII(int[] nums) {
        Array.Sort(nums);
        SIIBIIBacktrack(0, new List<int>(), nums);
        return SIIBIIres;
    }

    // In the context of the algorithm, i represents the starting index 
    // for the subset being constructed at any particular recursive call.
    // It ensures that elements are added to the subset in a sequential 
    // order and prevents revisiting the same elements from previous 
    // recursive calls.
    private void SIIBIIBacktrack(int i, List<int> subset, int[] nums) {
        SIIBIIres.Add(new List<int>(subset));
        for (int j = i; j < nums.Length; j++) {
            // The if clause ensures duplicate subsets are not generated.
            // This is necessary because the input array may contain 
            // duplicate elements (e.g., [1, 2, 2]), and without this 
            // check, the algorithm would explore redundant branches, 
            // leading to repeated subsets in the result.
            if (j > i && nums[j] == nums[j - 1]) {
                continue;
            }
            subset.Add(nums[j]);
            SIIBIIBacktrack(j + 1, subset, nums);
            subset.RemoveAt(subset.Count - 1);
        }
    }
}

/*
Backtrack(nums = [1, 2, 2], i = 0, subset = [])
├── Add [] to res
├── Loop: j = 0 → Include nums[0] = 1 → subset = [1]
│   ├── Add [1] to res
│   ├── Loop: j = 1 → Include nums[1] = 2 → subset = [1, 2]
│   │   ├── Add [1, 2] to res
│   │   ├── Loop: j = 2 → Include nums[2] = 2 → subset = [1, 2, 2]
│   │   │   ├── Add [1, 2, 2] to res
│   │   │   ├── Backtrack to subset = [1, 2]
│   │   ├── Backtrack to subset = [1]
│   ├── Backtrack to subset = []
├── Loop: j = 1 → Include nums[1] = 2 → subset = [2]
│   ├── Add [2] to res
│   ├── Loop: j = 2 → Include nums[2] = 2 → subset = [2, 2]
│   │   ├── Add [2, 2] to res
│   │   ├── Backtrack to subset = [2]
│   ├── Backtrack to subset = []
├── Loop: j = 2 → **Skip nums[2] = 2** because `j > i` and `nums[j] == nums[j-1]`.
*/

/*
Subsets II

You are given an array nums of integers, which may contain duplicates. 
Return all possible subsets.

The solution must not contain duplicate subsets. You may return the 
solution in any order.

Example 1:
Input: nums = [1,2,1]
Output: [[],[1],[1,2],[1,1],[1,2,1],[2]]

Example 2:
Input: nums = [7,7]
Output: [[],[7], [7,7]]

Constraints:
1 <= nums.length <= 11
-20 <= nums[i] <= 20
*/