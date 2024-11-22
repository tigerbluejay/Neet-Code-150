public partial class Solution {
    public int LastStoneWeightBucketSort(int[] stones) {
        int maxStone = 0;
        foreach (int stone in stones) {
            maxStone = Math.Max(maxStone, stone);
        }

        // create the buckets
        int[] bucket = new int[maxStone + 1];
        foreach (int stone in stones) {
            bucket[stone]++;
        }

        int first = maxStone, second = maxStone;
        while (first > 0) {
            if (bucket[first] % 2 == 0) {
                first--; // crush stones of equal weight
                continue;
            }

            // Finding the Second-Largest Stone Weight:
            // int j = Math.Min(first - 1, second);: 
            // This line calculates the potential second-largest stone weight. 
            // It takes the minimum of first - 1 (the weight just below the current largest) 
            // and second (the previously found second-largest).
            // while (j > 0 && bucket[j] == 0) { j--; }: This loop iterates backward from the 
            // potential second-largest weight, skipping any weights that have a frequency of 0. 
            // This ensures that we find the actual second-largest weight with a non-zero frequency.

            int j = Math.Min(first - 1, second);
            while (j > 0 && bucket[j] == 0) {
                j--;
            }

            if (j == 0) {
                return first;
            }

            // Performing the Smashing Operation:

            // second = j;: The second variable is assigned the actual second-largest stone weight.
            // bucket[first]--; bucket[second]--; bucket[first - second]++;: 
            // The frequencies of the two largest stones are decremented, and the frequency of the new stone 
            // (resulting from the smashing) is incremented.
            // first = Math.Max(first - second, second);: 
            // The first variable is updated to the weight of the larger stone after the smashing operation.
            second = j;
            bucket[first]--;
            bucket[second]--;
            bucket[first - second]++;
            first = Math.Max(first - second, second);
        }

        return first;
    }
}

/*
Last Stone Weight

You are given an array of integers stones where stones[i] represents the weight of the ith stone.

We want to run a simulation on the stones as follows:

At each step we choose the two heaviest stones, with weight x and y and smash them togethers
If x == y, both stones are destroyed
If x < y, the stone of weight x is destroyed, and the stone of weight y has new weight y - x.
Continue the simulation until there is no more than one stone remaining.

Return the weight of the last remaining stone or return 0 if none remain.

Example 1:
Input: stones = [2,3,6,2,4]
Output: 1

Explanation:
We smash 6 and 4 and are left with a 2, so the array becomes [2,3,2,2].
We smash 3 and 2 and are left with a 1, so the array becomes [1,2,2].
We smash 2 and 2, so the array becomes [1].

Example 2:
Input: stones = [1,2]
Output: 1

Constraints:
1 <= stones.length <= 20
1 <= stones[i] <= 100
*/