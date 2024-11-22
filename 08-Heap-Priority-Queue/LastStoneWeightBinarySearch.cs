public partial class Solution {
    public int LastStoneWeightBS(int[] stones) {
        Array.Sort(stones);
        int n = stones.Length;

        while (n > 1) {
            int cur = stones[n - 1] - stones[n - 2];
            n -= 2; // we will use this as part of the array resizing process, here we remove the two stones positions
            // The binary search is performed in order to find
            // the correct position in the stones array at which to insert
            // cur (the result of crushing the stones)
            if (cur > 0) {
                int l = 0, r = n;
                while (l < r) {
                    int mid = (l + r) / 2;
                    if (stones[mid] < cur) {
                        l = mid + 1;
                    } else {
                        r = mid;
                    }
                }
                int pos = l;
                // the array is resized in order to accomodate the new stone
                Array.Resize(ref stones, n + 1); // // we will use this as part of the array resizing process, here we add a spot for the new stone resulting from crushing two stones
                // elements of the array stones are then shifted one position to the right
                for (int i = n; i > pos; i--) {
                    stones[i] = stones[i - 1];
                }
                // the result of crushing the stones is inserted into its proper position
                stones[pos] = cur;
                n++;
            }
        }
        return n > 0 ? stones[0] : 0;
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