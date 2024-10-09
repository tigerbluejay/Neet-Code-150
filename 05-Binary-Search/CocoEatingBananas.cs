public partial class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        // left is minimum possible eating speed
        // right is maximum possible eating speed
        int left = 1, right = piles.Max();
        var result = right;

        // This loop performs a binary search to efficiently find the optimal eating speed.
        // The left <= right condition in the while loop will continue to hold as long as there 
        // is a potential range of values for the optimal eating speed.
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            long hours = 0;

            // Calculates the total number of hours required to finish all bananas with the current mid eating speed.
            foreach (var pile in piles)
            {
                // Math.Ceiling(pile / (double)mid) calculates the number of hours needed to finish the current pile.
                hours += (int)Math.Ceiling(pile / (double)mid);
            }

            // if the hours are less than the allowed maximum hours, adjust the right mid value
            // If hours is less than or equal to h:
                // Updates result with the minimum of the current result and mid.
                // Decrements right to search for a lower eating speed.
            // If hours is greater than h:
                // Increments left to search for a higher eating speed.
            if (hours <= h)
            {
                result = Math.Min(result, mid);
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return result;
    }
}
/*
Eating Bananas

You are given an integer array piles where piles[i] 
is the number of bananas in the ith pile. 
You are also given an integer h, which represents the number of hours you have to eat all the bananas.

You may decide your bananas-per-hour eating rate of k. Each hour, you may choose a pile of bananas and eats 
k bananas from that pile. If the pile has less than k bananas, you may finish eating the pile but you can 
not eat from another pile in the same hour.

Return the minimum integer k such that you can eat all the bananas within h hours.

Example 1:

Input: piles = [1,4,3,2], h = 9
Output: 2

Explanation: With an eating rate of 2, you can eat the bananas in 6 hours. 
With an eating rate of 1, you would need 10 hours to eat all the bananas (which exceeds h=9), 
thus the minimum eating rate is 2.
To solve this, you need to find the smallest k that allows you to eat all 10 bananas in 9 hours.
While you could eat at 3k and you would finish in 5 hours, the problem is not asking to maximize the hours, but k.
if i ate at 1 k, it would take me 10 hours which exceeds 9.
if i ate at 2 k, it would take me 6 hours, which is less than 9, so that's the best answer

Example 2:

Input: piles = [25,10,23,4], h = 4

Output: 25
Constraints:

1 <= piles.length <= 1,000
piles.length <= h <= 1,000,000
1 <= piles[i] <= 1,000,000,000
*/