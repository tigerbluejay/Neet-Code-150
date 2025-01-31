
public partial class Solution
{
    public List<List<int>> SubsetsI(int[] nums)
    {
        List<List<int>> res = new List<List<int>>();
        res.Add(new List<int>());

        foreach (int num in nums)
        {
            int size = res.Count; // count the number of items in res up until now
            for (int i = 0; i < size; i++) // loop that many times
            {
                List<int> subset = new List<int>(res[i]); // adding one item per iteration
                subset.Add(num); // to the subset (that is to the inner list) -
                // remember subset is a list itself
                res.Add(subset); // which is then added to res which is a List of Lists
            }
        }

        return res;
    }
}
/*

Visualization of Iterative Steps

Here’s a step-by-step visualization of how subsets are added at each iteration:

Initial State:

res = [[]]

After Adding 1: // outer loop foreach
Existing subsets: [[]].
Add 1 to each subset to create: [[1]].

Update res:
res = [[], [1]]

After Adding 2:
Existing subsets: [[], [1]].
Add 2 to each subset to create: [[2], [1, 2]]. // the inner for loop executes twice

Update res: // res is updated first with [2] then with [1,2] on the iteration
res = [[], [1], [2], [1, 2]]

After Adding 3:
Existing subsets: [[], [1], [2], [1, 2]].
Add 3 to each subset to create: [[3], [1, 3], [2, 3], [1, 2, 3]].

Update res:
res = [[], [1], [2], [1, 2], [3], [1, 3], [2, 3], [1, 2, 3]]

 */
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