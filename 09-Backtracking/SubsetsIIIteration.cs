public partial class Solution {
    public List<List<int>> SubsetsWithDupIteration(int[] nums) {
        Array.Sort(nums); // Sorts the input array to handle duplicates
        var res = new List<List<int>> { new List<int>() }; 
        // res holds all the subsets, starting with the empty subset
        int prevIdx = 0; 
        // prevIdx will track the count of subsets generated in 
        // the previous iteration
        int idx = 0; // / idx is used to track where to start adding 
        // new subsets in case of duplicates
        for (int i = 0; i < nums.Length; i++) {
            idx = (i >= 1 && nums[i] == nums[i - 1]) ? prevIdx : 0;
            prevIdx = res.Count;
            for (int j = idx; j < prevIdx; j++) { 
            // j iterates over previously generated subsets, 
            // starting at idx
                var tmp = new List<int>(res[j]);
                tmp.Add(nums[i]);
                res.Add(tmp);
            }
        }
        return res;
    }
}
/*
Start: res = [[]]

Step 1: nums[0] = 1
  Add 1 to all subsets:
    [[]] → [1]
  Result: res = [[], [1]]

Step 2: nums[1] = 2
  Add 2 to all subsets:
    [[]] → [2]
    [[1]] → [1, 2]
  Result: res = [[], [1], [2], [1, 2]]

Step 3: nums[2] = 2 (Duplicate)
  Add 2 to subsets created in the previous step (starting from idx = 2):
    [[2]] → [2, 2]
    [[1, 2]] → [1, 2, 2]
  Result: res = [[], [1], [2], [1, 2], [2, 2], [1, 2, 2]]
*/
/*
For duplicate elements (nums[i] == nums[i-1]), the algorithm starts 
adding subsets only to those created in the last step (idx = prevIdx).
This ensures subsets like [2, 2] and [1, 2, 2] are added only once.
*/
/*
Outer Loop: Decides what element (nums[i]) to process.
Moves sequentially through the input array nums.

Inner Loop: Decides where to add the current element (nums[i]).
Focuses on generating new subsets by combining nums[i] with the 
relevant subsets (all subsets or only the ones from the last step, 
depending on whether it's a duplicate).
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