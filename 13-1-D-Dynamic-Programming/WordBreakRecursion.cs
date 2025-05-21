public partial class Solution {
    // Main function that initiates the DFS from index 0
    public bool RWordBreak(string s, List<string> wordDict) {
        return WBRDfs(s, wordDict, 0);  // Start DFS from the beginning of the string
    }

    // Helper DFS function to check if we can segment s[i:] using the dictionary
    private bool WBRDfs(string s, List<string> wordDict, int i) {
        // Base case: if we've reached the end of the string, return true
        if (i == s.Length) {
            return true;
        }

        // Try every word in the dictionary
        foreach (string w in wordDict) {
            // Check if the substring starting at i matches the dictionary word
            if (i + w.Length <= s.Length && 
                s.Substring(i, w.Length) == w) {
                
                // If it matches, recursively call DFS from the next index
                if (WBRDfs(s, wordDict, i + w.Length)) {
                    return true;  // Found a valid path
                }
            }
        }

        // No valid segmentation found starting from index i
        return false;
    }
}
/*
🌲 Execution Tree

This tree shows how the algorithm checks possibilities recursively.
Input: s = "applepenapple", wordDict = ["apple","pen","ape"]

Start: i = 0, s = "applepenapple"
├── Try "apple" at i=0 → match
│   └── i = 5
│       ├── Try "apple" → "penap..." ≠ "apple"
│       ├── Try "pen" at i=5 → match
│       │   └── i = 8
│       │       ├── Try "apple" at i=8 → match
│       │       │   └── i = 13 (end of string)
│       │       │       └── return true ✅
│       │       └── (skip "pen" and "ape" – no match)
│       └── return true (because "apple" → "pen" → "apple")
├── Try "pen" at i=0 → no match
├── Try "ape" at i=0 → no match
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