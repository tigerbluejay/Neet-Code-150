public partial class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int prefix = 1, postfix = 1;
        int[] res = new int[nums.Length];        
        
        // in this first pass we obtain an array with numbers that are the result of
        // everything to the left of the current position multiplied
        for(int i = 0; i < nums.Length; i++){
            res[i] = prefix;
            prefix *= nums[i];             
        }
        
        // in this second pass we obtain an array with numbers that are the result of
        // everything to the right of the current position mulitiplied and in the same
        // step we incorporate it into the previous array to obtain the final result:
        // which is everything except the current position, multiplied.
        for(int i = nums.Length-1; i>=0; i--){
            res[i] *= postfix;
            postfix *= nums[i];          
        }
        return res;
    }
}
/*
Given an integer array nums, return an array output where output[i] 
is the product of all the elements of nums except nums[i].
Each product is guaranteed to fit in a 32-bit integer.
Follow-up: Could you solve it in 
𝑂(𝑛)
O(n) time without using the division operation?

Example 1:
Input: nums = [1,2,4,6]
Output: [48,24,12,8]

Example 2:
Input: nums = [-1,0,1,2,3]
Output: [0,-6,0,0,0]

Constraints:
2 <= nums.length <= 1000
-20 <= nums[i] <= 20
*/