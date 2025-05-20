public partial class Solution {
    public bool DPHSCanPartition(int[] nums) {
        // If the total sum is odd, it cannot be split into two equal subsets
        if (nums.Sum() % 2 != 0) {
            return false;
        }

        // Set to track all possible subset sums we can form so far
        HashSet<int> dp = new HashSet<int>();
        dp.Add(0); // We can always make sum 0 with an empty subset

        int target = nums.Sum() / 2; // We aim to find a subset that sums to half the total

        // Iterate backwards through the input array
        for (int i = nums.Length - 1; i >= 0; i--) {
            HashSet<int> nextDP = new HashSet<int>();

            // For each achievable sum 't' so far
            foreach (int t in dp) {
                // If adding current number hits the target, early return true
                if (t + nums[i] == target) {
                    return true;
                }

                // Add both possibilities: including or excluding nums[i]
                nextDP.Add(t + nums[i]);
                nextDP.Add(t);
            }

            // Move to the next state
            dp = nextDP;
        }

        // If we never hit the target, return false
        return false;
    }
}

/*
🧠 Prose Explanation

This algorithm checks whether a given array of positive integers can be partitioned into 
two subsets with equal sums.

If the total sum is odd, it's impossible to divide it evenly—early return false.

It uses a dynamic programming technique with a HashSet to represent all possible subset 
sums that can be formed at each step.

Starting from 0 (the sum of an empty subset), it iteratively updates this set by either 
including or excluding each number in the array.

At every iteration, we create a new set nextDP by traversing the current set dp and 
adding two choices for each value t: either take the number (t + nums[i]) or don't (t).
This branching represents the two-way decision at every step: take or skip the current 
number.

This choice structure — take or skip — mirrors the classic DP decision tree, where each 
state is built from previous states. We don't cache overlapping subproblems using an 
index and sum tuple like in recursive memoization, but the HashSet effectively tracks 
reachable states across iterations, capturing the same essence of overlapping subproblem 
reuse.

If at any point t + nums[i] == target, we know we've found a valid subset that sums to 
half the total — we return true. If we finish iterating without hitting that value, we 
return false.

By iteratively building nextDP from dp through two explicit choices, the algorithm forms 
an implicit decision tree — a hallmark of DP — where each node in the tree represents a 
subset sum formed so far. The HashSet compresses this tree by storing only reachable 
subset sums, pruning redundant paths and optimizing time and space.
*/

/*
DP Decision Tree for nums = [1, 2, 3, 4]

Start: 0
├── +4 → 4
│   ├── +3 → 7
│   │   ├── +2 → 9
│   │   │   ├── +1 → 10
│   │   │   └──  +0 → 9
│   │   └──  +0 → 7
│   │       ├── +1 → 8
│   │       └──  +0 → 7
│   └──  +0 → 4
│       ├── +2 → 6
│       │   ├── +1 → 7
│       │   └──  +0 → 6
│       └──  +0 → 4
│           ├── +1 → 5 ✅ TARGET FOUND
│           └──  +0 → 4
└──  +0 → 0
    ├── +3 → 3
    │   ├── +2 → 5 ✅ TARGET FOUND
    │   └──  +0 → 3
    │       ├── +1 → 4
    │       └──  +0 → 3
    └──  +0 → 0
        ├── +2 → 2
        │   ├── +1 → 3
        │   └──  +0 → 2
        └──  +0 → 0
            ├── +1 → 1
            └──  +0 → 0
*/


/*

Input: nums = [1, 2, 3, 4]
Sorted in reverse for the iteration: [4, 3, 2, 1]
Total sum: 10, so target = 5
Initial dp = {0}

🧾 DP HashSet State Evolution
pgsql
Copy
Edit
i = 3, nums[i] = 4
Start dp: {0}
  t = 0: add 0 + 4 = 4, add 0
Next dp: {0, 4}

i = 2, nums[i] = 3
Start dp: {0, 4}
  t = 0: add 0 + 3 = 3, add 0
  t = 4: add 4 + 3 = 7, add 4
Next dp: {0, 3, 4, 7}

i = 1, nums[i] = 2
Start dp: {0, 3, 4, 7}
  t = 0: add 0 + 2 = 2, add 0
  t = 3: add 3 + 2 = 5 → ✅ target found → return true

  */



/*
Partition Equal Subset Sum

You are given an array of positive integers nums.
Return true if you can partition the array into two subsets, 
subset1 and subset2 where sum(subset1) == sum(subset2). Otherwise, return false.

Example 1:
Input: nums = [1,2,3,4]
Output: true
Explanation: The array can be partitioned as [1, 4] and [2, 3].

Example 2:
Input: nums = [1,2,3,4,5]
Output: false

Constraints:
1 <= nums.length <= 100
1 <= nums[i] <= 50
*/