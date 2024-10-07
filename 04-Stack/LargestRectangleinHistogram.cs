

public partial class Solution {
    public int LargestRectangleArea(int[] heights) {
     // n is the number of bars
     int n = heights.Length, max = 0;
     // the stack saves indexes
        var stack = new Stack<int>();
  
        for(int i = 0; i <= n; i++)
        {
            // height is the height we have reached from the left
            var height = i < n ? heights[i] : 0;
            // the height we have reached ("height") must be smaller than the next height
            // The loop continues as long as both conditions are true. 
            // In other words, it will pop elements from the stack until either:
            // a) The stack becomes empty.
            // b) The height of the bar at the top of the stack is less than or 
            // equal to the current height. 
// When we encounter a bar whose height is less than the height of the bar at the top of the stack, 
// we pop elements from the stack until we find a bar whose height is less than or equal to the current height. 
            while(stack.Count != 0 && heights[stack.Peek()] > height)
            {
    	    // heights[stack.Peek()] effectively gets the height of the bar 
            // whose index is at the top of the stack. This height is then 
            // compared to the current height being processed in the loop 
            // to determine if the element should be popped from the stack.

                // we pop the stack index and save the current height
                var currHeight = heights[stack.Pop()];
                // we determine the previous index
                var prevIndex = stack.Count == 0 ? -1 : stack.Peek();
                // determine the max area
                // comparing the historical max "max" with the area of
                // the current max rectangle
                max = Math.Max(max, currHeight * (i - 1 - prevIndex));
            }
            stack.Push(i);
        }
        
        return max;
    }
}


/*
Largest Rectangle In Histogram
You are given an array of integers heights where heights[i] represents the height of a bar. The width of each bar is 1.

Return the area of the largest rectangle that can be formed among the bars.

Note: This chart is known as a histogram.

Example 1:

Input: heights = [7,1,7,2,2,4]

Output: 8

(formed by the rectangle starting at index 2 and extending to the end of the array with height 2)

Example 2:

Input: heights = [1,3,7]

Output: 7

Constraints:

1 <= heights.length <= 1000.
0 <= heights[i] <= 1000
*/