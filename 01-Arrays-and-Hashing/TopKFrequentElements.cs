public partial class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        int[] arr = new int[k];
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                dict[nums[i]]++;
            }
            else
            {
                dict.Add(nums[i], 1);    
            }
        }
        
        var pq = new PriorityQueue<int, int>();
        foreach (var key in dict.Keys)
        {
            pq.Enqueue(key, dict[key]);
            if (pq.Count > k) pq.Dequeue();
        }
        int i2 = k;
        while (pq.Count > 0) {
            arr[--i2] = pq.Dequeue();
        }
        return arr;
    }
}

/*
Given an integer array nums and an integer k, return the k most frequent elements within the array.
The test cases are generated such that the answer is always unique.
You may return the output in any order.

Example 1:
Input: nums = [1,2,2,3,3,3], k = 2
Output: [2,3]

Example 2:
Input: nums = [7,7], k = 1
Output: [7]

Constraints:
1 <= nums.length <= 10^4.
-1000 <= nums[i] <= 1000
1 <= k <= number of distinct elements in nums.
*/