public partial class Solution {
    // Bottom-up DP approach to check if the string `s` can be segmented using `wordDict`
    public bool DPBUWordBreak(string s, List<string> wordDict) {
        // dp[i] represents whether the substring s[i..] can be segmented into 
        // words from the dictionary
        bool[] dp = new bool[s.Length + 1];

        // Base case: the empty string (after the end) is trivially segmentable
        dp[s.Length] = true;

        // Traverse the string from right to left
        for (int i = s.Length - 1; i >= 0; i--) {
            // Try every word in the dictionary at position i
            foreach (string w in wordDict) {
                // If the word `w` fits in the remaining string starting at position i
                if ((i + w.Length) <= s.Length && 
                    s.Substring(i, w.Length) == w) {
                    
                    // If the rest of the string after the word can be segmented, 
                    // mark dp[i] as true
                    dp[i] = dp[i + w.Length];
                }

                // Early exit: if dp[i] is already true, no need to check more words
                if (dp[i]) {
                    break;
                }
            }
        }

        // Return whether the whole string s[0..] can be segmented
        return dp[0];
    }
}

/*
Input: s = "applepenapple", wordDict = ["apple","pen","ape"]
Output: true

Starting dp array: 
[false, false, false, false, false, false, false, false, false, false, false, false, false, true]

Start: Initialize dp[13] = true

i = 12 → dp[12] = false
  Try "apple" → too long
  Try "pen"   → s[12..15] = "e" ❌
  Try "ape"   → s[12..15] = "e" ❌

i = 11 → dp[11] = false
  Try "apple" → too long
  Try "pen"   → s[11..14] = "le" ❌
  Try "ape"   → s[11..14] = "le" ❌

i = 10 → dp[10] = false
  Try "apple" → too long
  Try "pen"   → s[10..13] = "ple" ❌
  Try "ape"   → s[10..13] = "ple" ❌

i = 9 → dp[9] = false
  Try "apple" → too long
  Try "pen"   → s[9..12] = "ple" ❌
  Try "ape"   → s[9..12] = "ple" ❌

i = 8 → dp[8] = false
  Try "apple" → s[8..13] = "apple" ✅
    → dp[13] = true → set dp[8] = true ✅
    → break inner loop (found match)

i = 7 → dp[7] = false
  Try "apple" → too long
  Try "pen"   → s[7..10] = "nap" ❌
  Try "ape"   → s[7..10] = "nap" ❌

i = 6 → dp[6] = false
  Try "apple" → too long
  Try "pen"   → s[6..9] = "ena" ❌
  Try "ape"   → s[6..9] = "ena" ❌

i = 5 → dp[5] = false
  Try "apple" → too long
  Try "pen"   → s[5..8] = "pen" ✅
    → dp[8] = true → set dp[5] = true ✅
    → break inner loop (found match)

i = 4 → dp[4] = false
  Try "apple" → too long
  Try "pen"   → s[4..7] = "epen" ❌
  Try "ape"   → s[4..7] = "epen" ❌

i = 3 → dp[3] = false
  Try "apple" → too long
  Try "pen"   → s[3..6] = "lepe" ❌
  Try "ape"   → s[3..6] = "lepe" ❌

i = 2 → dp[2] = false
  Try "apple" → too long
  Try "pen"   → s[2..5] = "plep" ❌
  Try "ape"   → s[2..5] = "plep" ❌

i = 1 → dp[1] = false
  Try "apple" → too long
  Try "pen"   → s[1..4] = "pple" ❌
  Try "ape"   → s[1..4] = "pple" ❌

i = 0 → dp[0] = false
  Try "apple" → s[0..5] = "apple" ✅
    → dp[5] = true → set dp[0] = true ✅
    → break inner loop (found match)

✅ Final dp[] Values of Interest

dp[0] = true   ← entire string is segmentable
dp[5] = true   ← "apple"
dp[8] = true   ← "applepen"
dp[13] = true  ← base case (empty string)

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