public partial class Solution {
    public int LastStoneWeight(int[] stones) {
        List<int> stoneList = new List<int>(stones);
        while (stoneList.Count > 1) {
            stoneList.Sort();
            int cur = stoneList[stoneList.Count - 1] - stoneList[stoneList.Count - 2];
            stoneList.RemoveAt(stoneList.Count - 1); 
            stoneList.RemoveAt(stoneList.Count - 1); 
            if (cur != 0) {
                stoneList.Add(cur); 
            }
        }

        return stoneList.Count == 0 ? 0 : stoneList[0];
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