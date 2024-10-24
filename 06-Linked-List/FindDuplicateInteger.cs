public partial class Solution {
    public int FindDuplicate(int[] nums) {
        // return floydAlgorithm(nums);
        return arrayAsHashMapIterative(nums);
    }
    
    // floyds Algorithm definition:
    // The algorithm leverages the fact that in a cycle, 
    // the fast pointer will eventually overtake the slow pointer, leading to their intersection.
    private int floydAlgorithm(int[] nums) {
        int slow = 0, fast = 0;
        
        while(true) {
            slow = nums[slow];
            fast = nums[nums[fast]];
            if (slow == fast)
                break;
        }
        // here we get at the point where they intersect
        // and floyd's algorithm states that the distance between the initial pointer in this list
        // slow2 = 0, so the first or 0th element to the start of the cycle 
        // and the distance between the previously found intersection point to the start of the cycle
        // will be the same
        // with that in mind

        var slow2 = 0;
        
        while(true) {
            slow = nums[slow];
            slow2 = nums[slow2];
            // two slow pointers at the same speed will intersect at the start of the cycle
            // if we set slow2 to the 0th element, and slow to the intersection point of the previous loop.
            if (slow == slow2)
                return slow;
        }
        
        return 0;
    }
    
    // alternatively we could use a hash map with the array nums = [1,2,3,2,2]
    private int arrayAsHashMapIterative(int[] nums) {
        while(nums[0] != nums[nums[0]]) {
            int nxt = nums[nums[0]];
            nums[nums[0]] = nums[0];
            nums[0] = nxt;
        }

        // Iteration 1:
        // Before: nums = [1, 2, 3, 2, 2]
        // while (nums[0] = 1, nums[nums[0]] = nums[1] = 2)
        // Swap: nums[1] = 1, nums[0] = 2
        // After: nums = [2, 1, 3, 2, 2]
        
        // Iteration 2:
        // Before: nums = [2, 1, 3, 2, 2]
        // while(nums[0] = 2, nums[nums[0]] = nums[2] = 3)
        // Swap: nums[2] = 2, nums[0] = 3
        // After: nums = [3, 1, 2, 2, 2]
        
        // Iteration 3:
        // Before: nums = [3, 1, 2, 2, 2]
        // while(nums[0] = 3, nums[nums[0]] = nums[3] = 2)
        // Swap: nums[3] = 3, nums[0] = 2
        // After: nums = [2, 1, 2, 3, 2]

        // Iteration 4:
        // while(nums[0] = 2, nums[nums[0]] = nums[2] = 2) return 2
        
        return nums[0];
    }
}


/*
Find Duplicate Integer

You are given an array of integers nums containing n + 1 integers. 
Each integer in nums is in the range [1, n] inclusive.

Every integer appears exactly once, except for one integer which appears two or more times. 
Return the integer that appears more than once.

Example 1:
Input: nums = [1,2,3,2,2]
Output: 2

Example 2:
Input: nums = [1,2,3,4,4]

Output: 4

Follow-up: Can you solve the problem without modifying the array nums and using 
O(1) extra space?

Constraints:
1 <= n <= 10000
nums.length == n + 1
1 <= nums[i] <= n

*/