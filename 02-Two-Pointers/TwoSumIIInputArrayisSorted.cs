public partial class Solution {
    public int[] TwoSumII(int[] numbers, int target) {
        // Using 2 pointers. Since sorted, if l+r > target, decrease r.
        // Else if l+r < target, increase l. Else, result is found.
        int left = 0, right = numbers.Length - 1;

        while (left < right) {
            int sum = numbers[left] + numbers[right];
            if (sum > target) {
                right--;
            } else if (sum < target) {
                left++;
            } else {
                return new int[] {left + 1, right + 1};
            }
        }
        return new int[0];
    }
}

/*
Given an array of integers numbers that is sorted in non-decreasing order.
Return the indices (1-indexed) of two numbers, [index1, index2], such that they add up 
to a given target number target and index1 < index2. Note that index1 and index2 cannot 
be equal, therefore you may not use the same element twice.
There will always be exactly one valid solution.

Your solution must use 
𝑂(1)
O(1) additional space.

Example 1:
Input: numbers = [1,2,3,4], target = 3
Output: [1,2]
Explanation:
The sum of 1 and 2 is 3. Since we are assuming a 1-indexed array, index1 = 1, index2 = 2. We return [1, 2].

Constraints:
2 <= numbers.length <= 1000
-1000 <= numbers[i] <= 1000
-1000 <= target <= 1000
*/