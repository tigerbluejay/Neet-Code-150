public partial class Solution {
    // HashSet is utilized to avoid duplicate answers
    HashSet<string> SIIBFres = new HashSet<string>();

    public List<List<int>> SubsetsWithDup(int[] nums) {
        
        Array.Sort(nums);
        Backtrack(nums, 0, new List<int>());
        
        List<List<int>> result = new List<List<int>>();
        result.Add(new List<int>());
        SIIBFres.Remove("");
        
        foreach (string str in SIIBFres) {
            List<int> subset = new List<int>();
            string[] arr = str.Split(',');
            foreach (string num in arr) {
                subset.Add(int.Parse(num));
            }
            result.Add(subset);
        }
        return result;
    }

    private void Backtrack(int[] nums, int i, List<int> subset) {
        
        if (i == nums.Length) {
            SIIBFres.Add(string.Join(",", subset));
            return;
        }

        subset.Add(nums[i]);
        Backtrack(nums, i + 1, subset);
        subset.RemoveAt(subset.Count - 1);
        Backtrack(nums, i + 1, subset);
    }
}

/*
Backtrack(nums = [1, 1, 2], i = 0, subset = [])
├── Backtrack(i = 1, subset = [1])
│   ├── Backtrack(i = 2, subset = [1, 1])
│   │   ├── Backtrack(i = 3, subset = [1, 1, 2])
│   │   │   └── Add to HashSet: "1,1,2"
│   │   ├── Backtrack(i = 3, subset = [1, 1])
│   │   │   └── Add to HashSet: "1,1"
│   ├── Backtrack(i = 2, subset = [1])
│   │   ├── Backtrack(i = 3, subset = [1, 2])
│   │   │   └── Add to HashSet: "1,2"
│   │   ├── Backtrack(i = 3, subset = [1])
│   │   │   └── Add to HashSet: "1"
├── Backtrack(i = 1, subset = [])
│   ├── Backtrack(i = 2, subset = [1])
│   │   ├── Backtrack(i = 3, subset = [1, 2])
│   │   │   └── Add to HashSet: "1,2"
│   │   ├── Backtrack(i = 3, subset = [1])
│   │   │   └── Add to HashSet: "1"
│   ├── Backtrack(i = 2, subset = [])
│   │   ├── Backtrack(i = 3, subset = [2])
│   │   │   └── Add to HashSet: "2"
│   │   ├── Backtrack(i = 3, subset = [])
│   │   │   └── Add to HashSet: ""
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