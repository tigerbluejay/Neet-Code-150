public partial class Solution {
    List<List<int>> SIIBres = new List<List<int>>();

    public List<List<int>> SubsetsWithDupBT(int[] nums) {
        Array.Sort(nums);
        SIIBBacktrack(0, new List<int>(), nums);
        return SIIBres;
    }

    private void SIIBBacktrack(int i, List<int> subset, int[] nums) {
        if (i == nums.Length) {
            SIIBres.Add(new List<int>(subset));
            return;
        }

        subset.Add(nums[i]);
        SIIBBacktrack(i + 1, subset, nums);
        subset.RemoveAt(subset.Count - 1);

        // Instead of relying on a HashSet to remove duplicates, 
        // this algorithm directly avoids generating duplicate subsets 
        // by skipping consecutive duplicate elements during recursion.
        while (i + 1 < nums.Length 
        && nums[i] == nums[i + 1]) {
            i++;
        }
        SIIBBacktrack(i + 1, subset, nums);
    }
}

/*
Backtrack(nums = [1, 2, 2], i = 0, subset = [])
├── Include nums[0] = 1 → subset = [1]
│   ├── Include nums[1] = 2 → subset = [1, 2]
│   │   ├── Include nums[2] = 2 → subset = [1, 2, 2]
│   │   │   └── Add to res: [1, 2, 2]
│   │   ├── Exclude nums[2] = 2 → subset = [1, 2]
│   │   │   └── Add to res: [1, 2]
│   ├── **While loop skips nums[2] = 2 (duplicate)**  
│   ├── Exclude nums[1] = 2 → subset = [1]
│   │   └── Add to res: [1]
├── Exclude nums[0] = 1 → subset = []
│   ├── Include nums[1] = 2 → subset = [2]
│   │   ├── Include nums[2] = 2 → subset = [2, 2]
│   │   │   └── Add to res: [2, 2]
│   │   ├── Exclude nums[2] = 2 → subset = [2]
│   │   │   └── Add to res: [2]
│   ├── **While loop skips nums[2] = 2 (duplicate)**  
│   ├── Exclude nums[1] = 2 → subset = []
│   │   └── Add to res: []
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