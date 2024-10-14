public partial class Solution {
    public int SearchTarget(int[] nums, int target) {
        int low = 0;
        int high = nums.Length - 1;
        
        while(low <= high) {
            var mid = (low + high) / 2;
            
            // if middle value is the target value return it
            if(nums[mid] == target) {
                return mid;
            } else if(nums[low] <= nums[mid]) {
                if(target > nums[mid] ||  target < nums[low]) 
                    low = mid + 1;
                else high = mid - 1; 
            } else {
                if(target < nums[mid] || target > nums[high]) 
                    high = mid - 1;
                else low = mid + 1;
            }
        }
        return -1;
    }
}
// int[] rotatedArray2 = [3,4,5,6,1,2]; int targetofRotatedArray = 6;
// iteration 1
// 3(L) < 5(M) => 6(5) > 5(M) => search the right portion of the array (6,1,2)
// iteration 2
// 6(L) < 1(M) NO => 6 < 1 or 6 > 2 YES => search the left portion of the array (6)
// iteration 3
// return 6


/* 
Find Target in Rotated Sorted Array

You are given an array of length n which was originally sorted in ascending order. 
It has now been rotated between 1 and n times. 
For example, the array nums = [1,2,3,4,5,6] might become:

[3,4,5,6,1,2] if it was rotated 4 times.
[1,2,3,4,5,6] if it was rotated 6 times.

Given the rotated sorted array nums and an integer target, 
return the index of target within nums, or -1 if it is not present.

You may assume all elements in the sorted rotated array nums are unique,

A solution that runs in O(n) time is trivial, can you write an algorithm that runs in O(log n) time?

Example 1:
Input: nums = [3,4,5,6,1,2], target = 1
Output: 4

Example 2:
Input: nums = [3,5,6,0,1,2], target = 4
Output: -1

Constraints:

1 <= nums.length <= 1000
-1000 <= nums[i] <= 1000
-1000 <= target <= 1000

*/