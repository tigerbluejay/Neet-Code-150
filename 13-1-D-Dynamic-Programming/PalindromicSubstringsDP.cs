public partial class Solution {
    public int DPCountSubstrings(string s) {
        int res = 0, n = s.Length;

        // dp[i, j] will be true if the substring s[i..j] is a palindrome
        bool[,] dp = new bool[n, n];

        // Traverse from the end of the string toward the start
        for (int i = n - 1; i >= 0; i--) {
            // For each i, check substrings s[i..j]
            for (int j = i; j < n; j++) {
                // A substring s[i..j] is a palindrome if:
                // - s[i] == s[j], and
                // - the inner substring s[i+1..j-1] is a palindrome (or it's length 0 or 1)
                if (s[i] == s[j] && 
                   (j - i <= 2 || dp[i + 1, j - 1])) {
                    
                    dp[i, j] = true; // Mark as palindrome
                    res++;           // Increment result counter
                }
            }
        }

        return res;
    }
}
/*
Input: s = "aaa"
Length: 3 → n = 3

We fill dp[i,j] from bottom up (i from 2 to 0), j from i to 2

i = 2
├── j = 2 → substring: "a"
│   └── s[2] == s[2], (j - i = 0 ≤ 2) → palindrome → dp[2,2] = true → count++

i = 1
├── j = 1 → substring: "a"
│   └── s[1] == s[1], (j - i = 0 ≤ 2) → palindrome → dp[1,1] = true → count++
├── j = 2 → substring: "aa"
│   └── s[1] == s[2], (j - i = 1 ≤ 2) → palindrome → dp[1,2] = true → count++

i = 0
├── j = 0 → substring: "a"
│   └── s[0] == s[0], (j - i = 0 ≤ 2) → palindrome → dp[0,0] = true → count++
├── j = 1 → substring: "aa"
│   └── s[0] == s[1], (j - i = 1 ≤ 2) → palindrome → dp[0,1] = true → count++
├── j = 2 → substring: "aaa"
│   └── s[0] == s[2], (j - i = 2 ≤ 2) → palindrome → dp[0,2] = true → count++

Final dp table (true means palindrome):
[
  [T, T, T],
  [F, T, T],
  [F, F, T]
]
    j →  0     1     2
    ---------------------
i = 0 |  T  |  T  |  T
i = 1 |  F  |  T  |  T
i = 2 |  F  |  F  |  T

There are 6 true values, matching the total palindromic substrings:
"a" at i=0
"aa" at i=0
"aaa" at i=0
"a" at i=1
"aa" at i=1
"a" at i=2

Total palindromic substrings: 6


/*

Palindromic Substrings

Given a string s, return the number of substrings within s that 
are palindromes.

A palindrome is a string that reads the same forward and backward.

Example 1:
Input: s = "abc"
Output: 3
Explanation: "a", "b", "c".

Example 2:
Input: s = "aaa"
Output: 6
Explanation: "a", "a", "a", "aa", "aa", "aaa". 
Note that different substrings are counted as 
different palindromes even if the string contents are the same.

Constraints:
1 <= s.length <= 1000
s consists of lowercase English letters.
*/