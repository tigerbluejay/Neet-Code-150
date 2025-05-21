public partial class Solution {
    // Dictionary to memoize results: memo[i] = whether s[i:] can be segmented
    private Dictionary<int, bool> WBDPTDmemo;

    // Entry point
    public bool DPTDWordBreak(string s, List<string> wordDict) {
        // base case: empty suffix is valid
        WBDPTDmemo = new Dictionary<int, bool> { { s.Length, true } };  
        return WBDPTDDfs(s, wordDict, 0);  // Start from index 0
    }

    private bool WBDPTDDfs(string s, List<string> wordDict, int i) {
        // If we've already computed the result for index i, 
        // return it
        if (WBDPTDmemo.ContainsKey(i)) {
            return WBDPTDmemo[i];
        }

        // Try matching every word in the dictionary
        foreach (var w in wordDict) {
            if (i + w.Length <= s.Length &&
                s.Substring(i, w.Length) == w) {
                // If the word matches, recurse from the next index
                if (WBDPTDDfs(s, wordDict, i + w.Length)) {
                    WBDPTDmemo[i] = true;  // Memoize and return true
                    return true;
                }
            }
        }

        // No valid segmentation found from i onward
        WBDPTDmemo[i] = false;
        return false;
    }
}

/*
🌲 Execution Tree with Memoization

Input: s = "applepenapple", wordDict = ["apple", "pen", "ape"]
We’ll show the memo table updates inline!

Start: i = 0
├── Try "apple" at i = 0 → match
│   └── i = 5
│       ├── Try "apple" → "pen..." ≠ "apple"
│       ├── Try "pen" at i = 5 → match
│       │   └── i = 8
│       │       ├── Try "apple" at i = 8 → match
│       │       │   └── i = 13 (base case) → return true ✅
│       │       │   └── memo[13] = true
│       │       └── memo[8] = true
│       └── memo[5] = true
└── memo[0] = true

No need to try "pen" or "ape" at i=0, because we've
already returned true.

✅ Summary for This Implementation

DFS + Memoization of i → bool to avoid recomputation.
Much more efficient than the previous two for large 
inputs or high branching.
Still a top-down recursive approach.
Returns true for this input, and memo looks like:

memo = {
    13: true,
    8:  true,
    5:  true,
    0:  true
}



/*

Input: s = "catsincars", wordDict = ["cats","cat","sin","in","car"]
Output: false

Start: i = 0

├── Try "cats" at i = 0 → ✅ match
│   └── i = 4
│       ├── Try "sin" → ✅ match
│       │   └── i = 7
│       │       ├── Try "car" at i = 7 → ✅ match
│       │       │   └── i = 10 → not end of string (string ends at 10, but "cars" != "car")
│       │       │   └── memo[10] = false ❌
│       │       └── Try "in", "cats", etc → no match
│       │       └── memo[7] = false ❌
│       └── Try "in" at i = 4 → ✅ match
│           └── i = 6
│               ├── Try "car" at i = 6 → ✅ match
│               │   └── i = 9
│               │       ├── Try "sin", "cats", etc → no match
│               │       └── memo[9] = false ❌
│               └── Try "cars" → no match
│               └── memo[6] = false ❌
│       └── memo[4] = false ❌
├── Try "cat" at i = 0 → ✅ match
│   └── i = 3
│       ├── Try "sin" at i = 3 → ✅ match
│       │   └── i = 6 → already memoized → memo[6] = false ❌
│       ├── Try "in" → no match
│       └── memo[3] = false ❌
└── memo[0] = false ❌
📒 Memo Table at the End

memo = {
    10: false,
    9:  false,
    7:  false,
    6:  false,
    4:  false,
    3:  false,
    0:  false
}

🧠 Summary
The algorithm explores valid paths like "cats" → "sin" → "car", 
but fails to reach the end of the string.

Every path results in hitting a point where no valid words match
anymore, and memo[i] = false is recorded to avoid rechecking.

The early memo lookup at i = 6 avoids repeating "car" again under 
"cat → sin".
*/

/*
Word Break

Given a string s and a dictionary of strings wordDict, return true if s 
can be segmented into a space-separated sequence of dictionary words.

You are allowed to reuse words in the dictionary an unlimited number of 
times. You may assume all dictionary words are unique.

Example 1:
Input: s = "neetcode", wordDict = ["neet","code"]
Output: true
Explanation: Return true because "neetcode" can be split into "neet" 
and "code".

Example 2:
Input: s = "applepenapple", wordDict = ["apple","pen","ape"]
Output: true
Explanation: Return true because "applepenapple" can be split into 
"apple", "pen" and "apple". Notice that we can reuse words and also 
not use all the words.

Example 3:
Input: s = "catsincars", wordDict = ["cats","cat","sin","in","car"]
Output: false

Constraints:
1 <= s.length <= 200
1 <= wordDict.length <= 100
1 <= wordDict[i].length <= 20
s and wordDict[i] consist of only lowercase English letters.
*/