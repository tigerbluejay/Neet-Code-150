public partial class Solution {

    // A set for quick lookup of dictionary words
    private HashSet<string> wordSet;

    // Memoization dictionary: key = current index in string `s`, 
    // value = whether the substring from this index can lead to a successful segmentation
    private Dictionary<int, bool> WBDPHSmemo;

    // `t` stores the length of the longest word in the dictionary to limit unnecessary 
    // substring checks
    private int t;

    // Main function to determine if the input string `s` can be segmented using words in 
    // `wordDict`
    public bool DPHSWordBreak(string s, List<string> wordDict) {
        // Initialize wordSet from the list for O(1) lookups
        wordSet = new HashSet<string>(wordDict);
        
        // Initialize the memoization dictionary
        WBDPHSmemo = new Dictionary<int, bool>();

        // Determine the length of the longest word to limit search space
        t = 0;
        foreach (var w in wordDict) {
            t = Math.Max(t, w.Length);
        }

        // Start recursive DFS from index 0
        return WBDPHSDfs(s, 0);
    }

    // Recursive DFS function to check if the substring from index `i` to end can be segmented
    private bool WBDPHSDfs(string s, int i) {
        // If we've reached the end of the string, return true (successful segmentation)
        if (i == s.Length) {
            return true;
        }

        // If result for this index has already been computed, return it
        if (WBDPHSmemo.ContainsKey(i)) {
            return WBDPHSmemo[i];
        }

        // Try every substring starting at index `i` up to max length `t`
        for (int j = i; j < Math.Min(i + t, s.Length); j++) {
            // If the current substring is in the dictionary
            if (wordSet.Contains(s.Substring(i, j - i + 1))) {
                // Recursively check if the rest of the string can be segmented
                if (WBDPHSDfs(s, j + 1)) {
                    WBDPHSmemo[i] = true; // Memoize and return true
                    return true;
                }
            }
        }

        // If no valid segmentation found starting at `i`, memoize and return false
        WBDPHSmemo[i] = false;
        return false;
    }
}

/*
"applepenapple" (i=0)
├── "a"        ❌
├── "ap"       ❌
├── "app"      ❌
├── "appl"     ❌
├── "apple"    ✅ word found
│   └── "penapple" (i=5)
│       ├── "p"      ❌
│       ├── "pe"     ❌
│       ├── "pen"    ✅ word found
│       │   └── "apple" (i=8)
│       │       ├── "a"       ❌
│       │       ├── "ap"      ❌
│       │       ├── "app"     ❌
│       │       ├── "appl"    ❌
│       │       ├── "apple"   ✅ word found
│       │       │   └── "" (i=13) ✅ END — success
│       │       └── ... (remaining substrings skipped, already succeeded)
│       ├── "pena"    ❌
│       ├── "penap"   ❌
│       ├── "penapp"  ❌
│       ├── "penappl" ❌
│       └── "penapple"❌
├── "applep"   ❌
├── "applepe"  ❌
├── "applepen" ❌
├── "applepena"❌
├── "applepenap"❌
└── "applepenapp"❌
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