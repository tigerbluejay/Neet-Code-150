//Input: nums = [2,3,1,5,4], k = 2

public partial class Solution {
    public int FindKthLargestQS(int[] nums, int k) {
        // k is 3 because the second largest is the 3rd element from smallest to largest
        // 0,1,2,3, there 3 is the 2nd smallest in the array.
        k = nums.Length - k;
        return QuickSelect(nums, 0, nums.Length - 1, k);
    }
    private int QuickSelect(int[] nums, int left, int right, int k) {
        int pivot = nums[right];
        int p = left;

        for (int i = left; i < right; i++) {
            if (nums[i] <= pivot) {
                int temp = nums[p];
                nums[p] = nums[i];
                nums[i] = temp;
                p++;
            }
        }
        // After the partitioning process, all elements less than or equal to the pivot are on the 
        // left side of p, and all elements greater than the pivot are on the right side. 
        // However, the pivot itself is still at index right. To ensure the correct partitioning 
        // and subsequent recursive calls, we need to move the pivot to its final position, 
        // which is at index p.
        int tmp = nums[p];
        nums[p] = nums[right];
        nums[right] = tmp;

        if (p > k) {
            return QuickSelect(nums, left, p - 1, k);
        } else if (p < k) {
            return QuickSelect(nums, p + 1, right, k);
        } else {
            return nums[p];
        }
    }
}

/*

Step-by-step breakdown of QuickSelect calls:
Call 1: QuickSelect(nums, left = 0, right = 4, k = 3)
Pivot: nums[4] = 4
Partition:
Elements <= pivot 4: [2, 3, 1]
Elements > pivot: [5]
After partition, the array becomes: [2, 3, 1, 4, 5] (pivot 4 moves to index 3).
Partition Index (p): 3
Since p == k, we have found the element at index 3: 4. Return 4.
Partition Explanation:
The array nums is partitioned such that:

All elements less than or equal to the pivot are on the left side of the partition index.
All elements greater than the pivot are on the right side.
The pivot is placed in its correct position.
For the given input, the process stops after the first call because the partition index p matches k. However, for completeness, let’s consider how additional recursive calls would look in cases where further partitioning is necessary.


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