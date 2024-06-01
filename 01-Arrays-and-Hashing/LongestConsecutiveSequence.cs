public partial class Solution {
    public int LongestConsecutive(int[] nums) {
        if (nums.Length < 2) return nums.Length;
        
        var set = new HashSet<int>(nums);
        var longest = 0;
        foreach (var n in set)
        {
            // if set does not contain n-1, then it is the starting point of a potential sequence
            if (!set.Contains(n-1))
            {
                var length = 0;
                while (set.Contains(n+length))
                {
                    length++;
                    longest = Math.Max(longest, length);
                }
            }
        }
        
        return longest;
    }
}

/*
Given an array of integers nums, return the length of the longest consecutive sequence of elements.
A consecutive sequence is a sequence of elements in which each element is exactly 1 greater than the previous element.
You must write an algorithm that runs in O(n) time.

Example 1:
Input: nums = [2,20,4,10,3,4,5]
Output: 4

Explanation: The longest consecutive sequence is [2, 3, 4, 5].

Example 2:
Input: nums = [0,3,2,5,4,6,1,1]
Output: 7
Explanation: The longest consecutive sequence is [0, 1, 2, 3, 4, 5, 6]

Constraints:
0 <= nums.length <= 1000
-10^9 <= nums[i] <= 10^9
*/