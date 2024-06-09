public partial class Solution
{
    public int Trap(int[] height)
    {

        if (height is null || height.Length == 0) return 0;

        int left = 0, right = height.Length - 1;
        int leftMax = height[left], rightMax = height[right];
        var result = 0;

        while (left < right)
        {
            if (leftMax < rightMax)
            {
                left++;
                leftMax = Math.Max(leftMax, height[left]);
                result += leftMax - height[left];
            }
            else
            {
                right--;
                rightMax = Math.Max(rightMax, height[right]);
                result += rightMax - height[right];
            }
        }

        return result;
    }
}

/*
You are given an array non-negative integers heights which represent an elevation map. 
Each value heights[i] represents the height of a bar, which has a width of 1.

https://neetcode.io/problems/trapping-rain-water

Return the maximum area of water that can be trapped between the bars.

Example 1:

Input: height = [0,2,0,3,1,0,1,3,2,1]

Output: 9
Constraints:

1 <= height.length <= 1000
0 <= height[i] <= 1000
*/