// Overly complex implementation - do not consider

public partial class Solution {

/*The Partition method is a helper function that:
    Rearranges elements around a pivot such that:
        Elements greater than the pivot are on the left.
        Elements smaller than the pivot are on the right.
    The pivot is strategically chosen and swapped into position.
*/

    private int Partition(int[] nums, int left, int right) {
        int mid = (left + right) >> 1;
        (nums[mid], nums[left + 1]) = (nums[left + 1], nums[mid]);
        
        if (nums[left] < nums[right])
            (nums[left], nums[right]) = (nums[right], nums[left]);
        if (nums[left + 1] < nums[right])
            (nums[left + 1], nums[right]) = (nums[right], nums[left + 1]);
        if (nums[left] < nums[left + 1])
            (nums[left], nums[left + 1]) = (nums[left + 1], nums[left]);
        
        /* 
        Two pointers i and j are used to iterate and swap elements such that 
        elements larger than the pivot are on the left and smaller elements are on the right.
        When the pointers meet, the pivot is swapped into its correct position.
        */

        int pivot = nums[left + 1];
        int i = left + 1;
        int j = right;
        
        while (true) {
            while (nums[++i] > pivot);
            while (nums[--j] < pivot);
            if (i > j) break;
            (nums[i], nums[j]) = (nums[j], nums[i]);
        }
        
        nums[left + 1] = nums[j];
        nums[j] = pivot;
        return j;
    }
    
    /* 
    The QuickSelect method repeatedly partitions the array, narrowing the search range:
        left and right define the current range of the array being considered.
    If the range has only one or two elements, it directly swaps them if necessary and returns 
    the kth largest element.
    Otherwise, it calls the Partition method to find the pivot index j:
        If j >= k, the kth largest element is in the left subarray.
        If j <= k, the kth largest element is in the right subarray.
    The process continues until the pivot index j matches the desired index k
    */
    
    private int QuickSelect(int[] nums, int k) {
        int left = 0;
        int right = nums.Length - 1;
        
        while (true) {
            if (right <= left + 1) {
                if (right == left + 1 && nums[right] > nums[left])
                    (nums[left], nums[right]) = (nums[right], nums[left]);
                return nums[k];
            }
            
            int j = Partition(nums, left, right);
            
            if (j >= k) right = j - 1;
            if (j <= k) left = j + 1;
        }
    }
    
    public int FindKthLargest(int[] nums, int k) {
        return QuickSelect(nums, k - 1);
    }
}

/*
Kth Largest Element in an Array

Given an unsorted array of integers nums and an integer k, 
return the kth largest element in the array.

By kth largest element, we mean the kth largest element in 
the sorted order, not the kth distinct element.

Follow-up: Can you solve it without sorting?

Example 1:
Input: nums = [2,3,1,5,4], k = 2
Output: 4

Example 2:
Input: nums = [2,3,1,1,5,5,4], k = 3

Output: 4
Constraints:
1 <= k <= nums.length <= 10000
-1000 <= nums[i] <= 1000
*/