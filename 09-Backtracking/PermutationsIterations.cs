public partial class Solution {
    public List<List<int>> PermuteIteration(int[] nums) {
        var perms = new List<List<int>>() { new List<int>() };
        foreach (int num in nums) {
            var new_perms = new List<List<int>>();
            // Initially, perms = [[]]. This means perms is not empty, 
            // it contains one element: an empty list ([]).
            foreach (var p in perms) {
                // Initially, for an empty list, p.Count is 0, and the loop runs 
                // exactly once because there is one valid insertion 
                // point (at index 0).
                for (int i = 0; i <= p.Count; i++) {
                    var p_copy = new List<int>(p);
                    p_copy.Insert(i, num);
                    new_perms.Add(p_copy);
                }
            }
            perms = new_perms;
        }
        return perms;
    }
}
/*

Initial perms: [[]]  // perms = [[]]
├── Processing num = 1
│   ├── Current p = [] (from perms) 
│   │   ├── Insert 1 @ 0 in p → p_copy = [1]
│   │   └── Add p_copy to new_perms → new_perms = [[1]]
│   └── Update perms to new_perms → perms = [[1]]

├── Processing num = 2
│   ├── Current p = [1] (from perms)
│   │   ├── Insert 2 @ 0 in p → p_copy = [2, 1]
│   │   ├── Add p_copy to new_perms → new_perms = [[2, 1]]
│   │   ├── Insert 2 @ 1 in p → p_copy = [1, 2]
│   │   └── Add p_copy to new_perms → new_perms = [[2, 1], [1, 2]]
│   └── Update perms to new_perms → perms = [[2, 1], [1, 2]]

├── Processing num = 3
│   ├── Current p = [2, 1] (from perms)
│   │   ├── Insert 3 @ 0 in p → p_copy = [3, 2, 1]
│   │   ├── Add p_copy to new_perms → new_perms = [[3, 2, 1]]
│   │   ├── Insert 3 @ 1 in p → p_copy = [2, 3, 1]
│   │   ├── Add p_copy to new_perms → new_perms = [[3, 2, 1], [2, 3, 1]]
│   │   ├── Insert 3 @ 2 in p → p_copy = [2, 1, 3]
│   │   └── Add p_copy to new_perms → new_perms = [[3, 2, 1], [2, 3, 1], [2, 1, 3]]
│   ├── Current p = [1, 2] (from perms)
│   │   ├── Insert 3 @ 0 in p → p_copy = [3, 1, 2]
│   │   ├── Add p_copy to new_perms → new_perms = [[3, 2, 1], [2, 3, 1], [2, 1, 3], [3, 1, 2]]
│   │   ├── Insert 3 @ 1 in p → p_copy = [1, 3, 2]
│   │   ├── Add p_copy to new_perms → new_perms = [[3, 2, 1], [2, 3, 1], [2, 1, 3], [3, 1, 2], [1, 3, 2]]
│   │   ├── Insert 3 @ 2 in p → p_copy = [1, 2, 3]
│   │   └── Add p_copy to new_perms → new_perms = [[3, 2, 1], [2, 3, 1], [2, 1, 3], [3, 1, 2], [1, 3, 2], [1, 2, 3]]
│   └── Update perms to new_perms → perms = [[3, 2, 1], [2, 3, 1], [2, 1, 3], [3, 1, 2], [1, 3, 2], [1, 2, 3]]
*/

/*
Permutations

Given an array nums of unique integers, return all the possible 
permutations. You may return the answer in any order.

Example 1:
Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

Example 2:
Input: nums = [7]
Output: [[7]]

Constraints:
1 <= nums.length <= 6
-10 <= nums[i] <= 10

*/
