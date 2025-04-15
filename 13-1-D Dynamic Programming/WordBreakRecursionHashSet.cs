public partial class Solution {
    // Main method that initializes a HashSet for faster lookups
    public bool RHSWordBreak(string s, List<string> wordDict) {
        HashSet<string> wordSet = new HashSet<string>(wordDict);  // O(1) lookup
        return WBRHSDfs(s, wordSet, 0);  // Start DFS from index 0
    }

    // Recursive DFS that builds substrings from index i
    private bool WBRHSDfs(string s, HashSet<string> wordSet, int i) {
        // Base case: we've segmented the entire string
        if (i == s.Length) {
            return true;
        }

        // Try all substrings starting from i up to end
        for (int j = i; j < s.Length; j++) {
            string sub = s.Substring(i, j - i + 1);  // substring s[i..j]
            if (wordSet.Contains(sub)) {
                // If the current substring is in the word set,
                // recursively try to segment the rest of the string
                if (WBRHSDfs(s, wordSet, j + 1)) {
                    return true;  // Found a valid segmentation
                }
            }
        }

        // No valid segmentation found starting at index i
        return false;
    }
}
/*
🌲 Execution Tree

Input: s = "applepenapple", 
wordDict = ["apple","pen","ape"]

We will show substring building from left to right:
Start: i = 0

├── j = 0 → "a"      → not in wordSet
├── j = 1 → "ap"     → not in wordSet
├── j = 2 → "app"    → not in wordSet
├── j = 3 → "appl"   → not in wordSet
├── j = 4 → "apple"  → ✅ in wordSet
│   └── i = 5
│       ├── j = 5 → "p"     → not in wordSet
│       ├── j = 6 → "pe"    → not in wordSet
│       ├── j = 7 → "pen"   → ✅ in wordSet
│       │   └── i = 8
│       │       ├── j = 8 → "a"     → not in wordSet
│       │       ├── j = 9 → "ap"    → not in wordSet
│       │       ├── j =10 → "app"   → not in wordSet
│       │       ├── j =11 → "appl"  → not in wordSet
│       │       ├── j =12 → "apple" → ✅ in wordSet
│       │       │   └── i = 13 (end of string) → return true ✅
│       │       └── return true ✅
│       └── return true ✅
└── return true ✅
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