public partial class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        // output stores the max values for each sliding window
        var output = new List<int>();
        // queue stores indices of elements in the current window
        LinkedList<int> queue = new();
        // boundaries of sliding window
        int left = 0, right = 0;

        while (right < nums.Length)
        {
            // pop smaller values from queue
            // remove last element from the queue while there are elements in the queue
            // and the current element (nums[right]) is greater than the element
            // corresponding to the index at the last of the queue
            while (queue.Count > 0 && nums[queue.Last.Value] < nums[right])
                queue.RemoveLast();
            // add the current index to the queue
            queue.AddLast(right);

            // remove left val from the window
            // remove the first element from the queue if it is out of the bounds of the current window
            if (left > queue.First.Value)
                queue.RemoveFirst(); // remove the val from the current window
                // so we don't later add to output older elements (elements that
                // shouldn't be in the window)

            // if the current window has reached the required size
            if (right + 1 >= k)
            {
                // add the maximum value in the queue (front of the queue) to the output
                output.Add(nums[queue.First.Value]);
                // move the left boundary of the window one step to the right
                left++;
            }

            // move the right boundary of the window one step to the right
            right++;
        }

        return output.ToArray();
    }
}

/*
You are given an array of integers nums and an integer k. 
There is a sliding window of size k that starts at the left edge of the array. 
The window slides one position to the right until it reaches the right edge of the array.

Return a list that contains the maximum element in the window at each step.

Example 1:

Input: nums = [1,2,1,0,4,2,6], k = 3

Output: [2,2,4,4,6]

Explanation: 
Window position            Max
---------------           -----
[1  2  1] 0  4  2  6        2
 1 [2  1  0] 4  2  6        2
 1  2 [1  0  4] 2  6        4
 1  2  1 [0  4  2] 6        4
 1  2  1  0 [4  2  6]       6
Constraints:

1 <= nums.length <= 1000
-1000 <= nums[i] <= 1000
1 <= k <= nums.length
*/