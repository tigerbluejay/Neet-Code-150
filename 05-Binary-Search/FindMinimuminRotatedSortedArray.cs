
public partial class Solution {
    public int FindMin(int[] nums) {
        
        int left = 0, right = nums.Length - 1;
        
        while (left <= right) {
            
            // if the value at the left pointer is less than the value at the right
            // ex: 1,2
            // then we return the number at the left pointer
            if (nums[left] <= nums[right]) {
                return nums[left];
            }
            
            int mid = (left + right) / 2;
            
            // if the value at the middle is greater than the value at the very left
            // ex: 3,4,5,1,2
            // we should search in the right portion of the array (1,2)
            // and we do this by setting the left pointer to the mid value + 1
            if (nums[mid] >= nums[left]) {
                left = mid + 1;
            }
            // if the value at the middle is less than the value at the very left
            // ex: 5,1,2,3,4
            // we should search in the left portion of the array (5,1,2)
            // and we should do this by setting the right pointer to the mid value
            else {
                right = mid;
            }
        }
        return 0;
    }
}

// int[] arrayToRotate = [3,4,5,6,1,2];
    
/*
Find Minimum in Rotated Sorted Array

You are given an array of length n which was originally sorted in ascending order. 
It has now been rotated between 1 and n times. For example, the array nums = [1,2,3,4,5,6] might become:

[3,4,5,6,1,2] if it was rotated 4 times.
[1,2,3,4,5,6] if it was rotated 6 times.

Notice that rotating the array 4 times moves the last four elements of the array to the beginning. 
Rotating the array 6 times produces the original array.

Assuming all elements in the rotated sorted array nums are unique, return the minimum element of this array.

A solution that runs in O(n) time is trivial, can you write an algorithm that runs in O(log n) time?

Example 1:
Input: nums = [3,4,5,6,1,2]
Output: 1

Example 2:
Input: nums = [4,5,0,1,2,3]
Output: 0

Example 3:
Input: nums = [4,5,6,7]
Output: 4

Constraints:

1 <= nums.length <= 1000
-1000 <= nums[i] <= 1000
*/