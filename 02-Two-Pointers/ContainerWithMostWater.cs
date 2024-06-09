public partial class Solution {
    public int MaxArea(int[] height) {
        int res = 0, area = 0, left = 0, right = height.Length-1;
        
        while (left < right){
           
            area = (Math.Min(height[left], height[right])) * (right - left);
            res = Math.Max(area, res);
            
            if(height[left] < height[right]){
                left++;
            }else{
                right--;
            }
            
        }
        return res;
    }
}

/*
You are given an integer array heights where heights[i] represents the height of the 
𝑖𝑡ℎ ith bar.
You may choose any two bars to form a container. Return the maximum amount of water a container can store.
https://neetcode.io/problems/max-water-container

Example 1:
Input: height = [1,7,2,5,4,7,3,6]

Output: 36

Example 2:
Input: height = [2,2,2]
Output: 4

Constraints:

2 <= height.length <= 1000
0 <= height[i] <= 1000

*/