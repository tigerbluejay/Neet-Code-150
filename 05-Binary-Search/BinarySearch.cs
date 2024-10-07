public partial class Solution {
    public int Search(int[] nums, int target) {
        int left = 0, right = nums.Length - 1;

        while (left <= right) {
            int mid = left + ((right - left) / 2); // (left + right) / 2 can lead to overflow
            if (nums[mid] > target) {
                right = mid - 1;
            } else if (nums[mid] < target) {
                left = mid + 1;
            } else { // Found the value
                return mid;
            }
        }
        return -1;
    }
}

/*
Binary Search

You are given an array of distinct integers nums, sorted in ascending order, and an integer target.

Implement a function to search for target within nums. If it exists, then return its index, otherwise, return -1.

Your solution must run in O(log n) 
O(log n) time.

Example 1:

Input: nums = [-1,0,2,4,6,8], target = 4

Output: 3

Example 2:

Input: nums = [-1,0,2,4,6,8], target = 3

Output: -1

Constraints:

1 <= nums.length <= 10000.
-10000 < nums[i], target < 10000
*/