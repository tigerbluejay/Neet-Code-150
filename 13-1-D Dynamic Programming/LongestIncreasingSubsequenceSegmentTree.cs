public class SegmentTreeLIS {
    private int n;
    private int[] tree;

    public SegmentTreeLIS(int N) {
        n = N;
        tree = new int[2 * n]; // Segment tree stored in a 1-based array [n..2n-1] are 
        // leaves
        Array.Fill(tree, 0);
    }

    // Updates value at position i (compressed index), and propagates changes up
    public void Update(int i, int val) {
        tree[n + i] = val;           // Place val at the leaf
        int j = (n + i) >> 1;
        while (j >= 1) {
            tree[j] = Math.Max(tree[2 * j], tree[2 * j + 1]); // Keep tree correct upwards
            j >>= 1;
        }
    }

    // Query max in the range [l, r] (inclusive), assumes 0-based compressed indices
    public int Query(int l, int r) {
        if (l > r) return 0;

        int res = int.MinValue;
        l += n;
        r += n + 1; // Make r exclusive
        while (l < r) {
            if ((l & 1) == 1) res = Math.Max(res, tree[l++]); // if l is a right child
            if ((r & 1) == 1) res = Math.Max(res, tree[--r]); // if r is a right boundary
            l >>= 1;
            r >>= 1;
        }
        return res;
    }
}

public partial class Solution
{
    public int STLengthOfLIS(int[] nums)
    {
        // Step 1: Coordinate Compression
        // We want to map each number to a unique index in a sorted order.
        // This makes it possible to use the segment tree for index-based range queries.
        var sortedArr = nums.Distinct().OrderBy(x => x).ToArray(); // Sort and deduplicate
        var map = new Dictionary<int, int>(); // Map from original value → compressed index

        for (int i = 0; i < sortedArr.Length; i++)
        {
            map[sortedArr[i]] = i;
        }

        // Step 2: Initialize Segment Tree
        // The segment tree will store the LIS value ending at each compressed index
        int n = sortedArr.Length; // Total number of distinct elements
        var segTree = new SegmentTreeLIS(n);

        int LIS = 0; // This will hold the global maximum LIS length

        // Step 3: Main Loop - Compute LIS using segment tree
        foreach (var num in nums)
        {
            // Get the compressed index of the current number
            int compressedIndex = map[num];

            // Query the segment tree for the max LIS length among all smaller numbers
            // i.e., for all indices less than compressedIndex
            int curLIS = segTree.Query(0, compressedIndex - 1) + 1;

            // Update the segment tree at compressedIndex with the new LIS value
            // This ensures that future elements that are greater than `num`
            // can query this value as a candidate
            segTree.Update(compressedIndex, curLIS);

            // Update global max LIS if needed
            LIS = Math.Max(LIS, curLIS);
        }

        // Step 4: Return the global LIS
        return LIS;
    }
}

/*
nums[0] = 9 → compressedIndex = 5
  Query(0, 4) → max LIS so far among nums < 9 → 0
  Update(5, 1)
  LIS = 1

Segment Tree (compressed index → value):
[1]=0  [2]=0  [3]=0  [4]=0  [5]=0  [6]=1  [7]=0  [8]=0  [9]=1  [10]=0  [11]=0  [12]=0

----------------------------------

nums[1] = 1 → compressedIndex = 0
  Query(0, -1) → empty range → 0
  Update(0, 1)
  LIS = 1

Tree update: compressedIndex 0 set to 1

[1]=1  [2]=0  [3]=0  [4]=0  [5]=0  [6]=1  [7]=0  [8]=0  [9]=1  [10]=0  [11]=0  [12]=0

----------------------------------

nums[2] = 4 → compressedIndex = 3
  Query(0, 2) → check LIS for nums < 4 → max([1, 0, 0]) = 1
  Update(3, 2)
  LIS = 2

----------------------------------

nums[3] = 2 → compressedIndex = 1
  Query(0, 0) → max([1]) = 1
  Update(1, 2)
  LIS = 2

----------------------------------

nums[4] = 3 → compressedIndex = 2
  Query(0, 1) → max([1, 2]) = 2
  Update(2, 3)
  LIS = 3

----------------------------------

nums[5] = 3 → compressedIndex = 2
  Query(0, 1) → max([1, 2]) = 2
  Update(2, 3) → already 3, no change
  LIS = 3

----------------------------------

nums[6] = 7 → compressedIndex = 4
  Query(0, 3) → max([1, 2, 3, 2]) = 3
  Update(4, 4)
  LIS = 4

----------------------------------

🧮 Final Result: **LIS = 4**

*/

/*

Initial: [0, 0, 0, 0, 0, 0]

num = 9 → idx = 5 → Query(0,4)=0 → Update(5,1) → Tree: [0, 0, 0, 0, 0, 1]
num = 1 → idx = 0 → Query(0,-1)=0 → Update(0,1) → Tree: [1, 0, 0, 0, 0, 1]
num = 4 → idx = 3 → Query(0,2)=1 → Update(3,2) → Tree: [1, 2, 3, 2, 0, 1]
num = 2 → idx = 1 → Query(0,0)=1 → Update(1,2) → Tree: [1, 2, 3, 2, 0, 1]
num = 3 → idx = 2 → Query(0,1)=2 → Update(2,3) → Tree: [1, 2, 3, 2, 0, 1]
num = 3 → idx = 2 → Query(0,1)=2 → Update(2,3) → Tree: [1, 2, 3, 2, 0, 1]
num = 7 → idx = 4 → Query(0,3)=3 → Update(4,4) → Tree: [1, 2, 3, 2, 4, 1]

*/

/*
The segment tree stores, at index i, the maximum length of any increasing subsequence 
ending with the value corresponding to compressed index i.

The Query(0, compressedIndex - 1) finds the longest LIS length ending at any number 
less than the current num.

The Update(compressedIndex, curLIS) ensures that future numbers greater than num can 
build upon it.
*/

/*
🌱 Gentle Introduction to Segment Trees
1. ❓ What's the Problem Segment Trees Solve?
Imagine you have an array of numbers, and you want to:

Quickly answer questions like:
👉 “What is the maximum value between index l and r?”

And also quickly update a value in the array.

Doing this with brute force is:

O(n) time for each query or update — too slow for big data!

2. 💡 Segment Tree to the Rescue
A segment tree is a clever way to:

Divide an array into segments (like halves, quarters, etc.)

Store precomputed results (like max/min/sum) in a tree structure

Allow fast queries and updates — O(log n) time!

Think of it like:

                   [0, 7]
                /         \
           [0, 3]         [4, 7]
          /     \         /     \
      [0,1]   [2,3]   [4,5]   [6,7]
     /   \     / \     / \     / \
   [0] [1]  [2] [3]  [4] [5]  [6] [7]
Each node holds info about a range (like max in that range). 
The root covers the whole array, the leaves are the individual elements.

3. 🛠️ How It Works
🔍 Query(l, r):
Ask for the max/min/sum between two indices.
The tree skips over irrelevant parts and combines only necessary nodes — 
that's the magic behind logarithmic time.

✏️ Update(i, val):
If an element changes, we update its node and bubble up the changes through its parents, 
ensuring the tree stays accurate.

4. 🚀 Segment Tree for Longest Increasing Subsequence (LIS)
Now, let’s connect the dots to the LIS problem.

Problem:
You're looping over nums, building the longest increasing subsequence up to each point.

To do that efficiently, you need to ask:
👉 "What's the best LIS ending in a smaller number than num?"

How the Segment Tree Helps:
After coordinate compression, each unique number maps to an index.

The tree keeps track of the LIS length ending at each number (via its index).

For each num:

You query the max LIS length for smaller numbers (i.e., Query(0, compressedIndex - 1)).

You update the value at compressedIndex with this new LIS length.

🔁 TL;DR Recap
Concept	What it Means
Segment Tree	A binary tree to store info about array ranges
Query(l, r)	Ask about a range in O(log n)
Update(i, val)	Change an element and update related ranges fast
In LIS context	Track LIS lengths ending at each number
*/

/*
Longest Increasing Subsequence

Given an integer array nums, return the length of the longest strictly increasing 
subsequence.

A subsequence is a sequence that can be derived from the given sequence by deleting 
some or no elements without changing the relative order of the remaining characters.

For example, "cat" is a subsequence of "crabt".

Example 1:
Input: nums = [9,1,4,2,3,3,7]
Output: 4
Explanation: The longest increasing subsequence is [1,2,3,7], which has a length of 4.

Example 2:
Input: nums = [0,3,1,3,2,3]
Output: 4

Constraints:
1 <= nums.length <= 1000
-1000 <= nums[i] <= 1000
*/