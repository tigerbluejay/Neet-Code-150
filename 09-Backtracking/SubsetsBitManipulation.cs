
public partial class Solution
{
    public List<List<int>> SubsetsBM(int[] nums)
    {
        int n = nums.Length;
        List<List<int>> res = new List<List<int>>();

        for (int i = 0; i < (1 << n); i++)
        {
            List<int> subset = new List<int>();

            for (int j = 0; j < n; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    subset.Add(nums[j]);
                }
            }
            res.Add(subset);
        }
        return res;
    }
}

/*

This solution uses bit manipulation to generate all subsets of the array nums.
Here's a detailed breakdown of how it works, even if you're not familiar with
bit manipulation:

High-Level Explanation
The key idea is that a subset can be represented as a binary number of length n
(where n is the size of the array nums), where:

Each bit corresponds to whether an element is included in the subset
(1 = included, 0 = not included).
For example, if nums = [1, 2, 3]:

Binary 000 (decimal 0) → Subset: [] (no elements included).
Binary 101 (decimal 5) → Subset: [1, 3] (include 1st and 3rd elements).

The algorithm iterates over all numbers from 0 to 2^n - 1
(the total number of subsets for an array of size n),
treating each number as a binary mask that represents a subset.


Example Walkthrough

Let’s go through this step by step for nums = [1, 2, 3].

Outer Loop: Iterating over i (bitmask)
The outer loop runs for i = 0 to i = 7 (total: 2^3 = 8 iterations).
Iteration 1: i = 0 (binary: 000)
Subset starts as [].
Inner loop:
j = 0: (0 & (1 << 0)) = (0 & 0001) = 0 → Skip.
j = 1: (0 & (1 << 1)) = (0 & 0010) = 0 → Skip.
j = 2: (0 & (1 << 2)) = (0 & 0100) = 0 → Skip.
Subset remains [].
Add [] to res.

Iteration 2: i = 1 (binary: 001)
Subset starts as [].
Inner loop:
j = 0: (1 & (1 << 0)) = (1 & 0001) = 1 → Include nums[0] = 1.
j = 1: (1 & (1 << 1)) = (1 & 0010) = 0 → Skip.
j = 2: (1 & (1 << 2)) = (1 & 0100) = 0 → Skip.
Subset becomes [1].
Add [1] to res.

Iteration 3: i = 2 (binary: 010)
Subset starts as [].
Inner loop:
j = 0: (2 & (1 << 0)) = (2 & 0001) = 0 → Skip.
j = 1: (2 & (1 << 1)) = (2 & 0010) = 2 → Include nums[1] = 2.
j = 2: (2 & (1 << 2)) = (2 & 0100) = 0 → Skip.
Subset becomes [2].
Add [2] to res.

Iteration 4: i = 3 (binary: 011)
Subset starts as [].
Inner loop:
j = 0: (3 & (1 << 0)) = (3 & 0001) = 1 → Include nums[0] = 1.
j = 1: (3 & (1 << 1)) = (3 & 0010) = 2 → Include nums[1] = 2.
j = 2: (3 & (1 << 2)) = (3 & 0100) = 0 → Skip.
Subset becomes [1, 2].
Add [1, 2] to res.

Continue for i = 4 to 7
By following the same logic, the algorithm generates all subsets:

i = 4 (binary: 100) → [3].
i = 5 (binary: 101) → [1, 3].
i = 6 (binary: 110) → [2, 3].
i = 7 (binary: 111) → [1, 2, 3].

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