public partial class Solution {
    public int FindKthLargestMH(int[] nums, int k) {
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        foreach (int num in nums) {
            // By passing the same num value for both priority and element, 
            // you're essentially treating the num itself as both the priority and the data. 
            // This means that smaller numbers will have higher priority, 
            // and the min-heap will always keep the smallest number at the top.
            minHeap.Enqueue(num, num);
            if (minHeap.Count > k) {
                // the smallest elements exceeding k will be removed from the queue.
                minHeap.Dequeue();
            }
        }
        return minHeap.Peek();
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