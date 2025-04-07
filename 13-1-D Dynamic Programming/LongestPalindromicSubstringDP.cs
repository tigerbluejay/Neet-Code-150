public partial class Solution {
    public string DPLongestPalindrome(string s) {
        int resIdx = 0, resLen = 0; // To keep track of the starting index and 
        // length of the longest palindrome found
        int n = s.Length;

        // dp[i, j] will be true if the substring s[i..j] is a palindrome
        bool[,] dp = new bool[n, n];

        // We fill the table in reverse order so that when checking dp[i+1, j-1],
        // we are guaranteed that its value has already been computed.
        // (This is important because dp[i,j] depends on dp[i+1,j-1])
        for (int i = n - 1; i >= 0; i--) {
            for (int j = i; j < n; j++) {

                // Case 1: s[i] != s[j] → not a palindrome
                // Case 2: s[i] == s[j]
                //   Subcase 2.1: if j - i <= 2, then it's either:
                //     - a 1-letter substring (i == j), e.g., "a"
                //     - a 2-letter substring like "aa"
                //     - a 3-letter palindrome like "aba"
                //     → all of which are palindromes if outer chars match
                //   Subcase 2.2: if j - i > 2, we need to check if the inner 
                //  substring s[i+1..j-1] is also a palindrome
                if (s[i] == s[j] &&
                   (j - i <= 2 || dp[i + 1, j - 1])) {

                    dp[i, j] = true;

                    // Update the result if this palindrome is longer than any 
                    // we've seen
                    if (resLen < (j - i + 1)) {
                        resIdx = i;             // Save the start index
                        resLen = j - i + 1;     // Save the new max length
                    }
                }
            }
        }

        // After checking all substrings, extract and return the longest palindromic 
        // substring
        return s.Substring(resIdx, resLen);
    }
}

/*
Input: "ababd"
resIdx = 0, resLen = 0
Initialize dp[5][5] = false

Loop i=4
  j=4 → "d" → palindrome → res = "d", resLen = 1

Loop i=3
  j=3 → "b" → palindrome → res = "b"
  j=4 → "bd" → not palindrome

Loop i=2
  j=2 → "a" → palindrome
  j=3 → "ab" → not palindrome
  j=4 → "abd" → not palindrome

Loop i=1
  j=1 → "b" → palindrome
  j=2 → "ba" → not palindrome
  j=3 → "bab" → palindrome → res = "bab", resLen = 3
  j=4 → "babd" → not palindrome

Loop i=0
  j=0 → "a" → palindrome
  j=1 → "ab" → not palindrome
  j=2 → "aba" → palindrome → res = "aba" (same length, but earlier start)
  j=3 → "abab" → not palindrome
  j=4 → "ababd" → not palindrome

Longest Palindromic Substring: "aba"

*/

/*
Complex Area Breakdown
🧠 Why We Loop from End to Start (i from n-1 to 0):
This is to ensure that when we are filling dp[i][j], the value of dp[i+1][j-1] 
is already computed.
This is crucial for dynamic programming problems with overlapping subproblems 
that build upon smaller subproblems.

🧠 The if (s[i] == s[j] && (j - i <= 2 || dp[i + 1, j - 1])) Condition:
s[i] == s[j] ensures the outer characters match (a requirement for any palindrome).

j - i <= 2 handles:
1-character (e.g., "a") → always a palindrome
2-character (e.g., "aa") → palindrome if both chars match
3-character (e.g., "aba") → palindrome if outer chars match (the middle one doesn't matter in this check)

dp[i+1, j-1] checks if the inner string is a palindrome — crucial for substrings 
longer than 3 characters
*/

/*
Here's the final dp table for the input string s = "ababd" as it would look in code, 
filled with every boolean value (true or false) after all iterations are complete:

Initial String: "a  b  a  b  d"
                 0  1  2  3  4

bool[,] dp = new bool[5, 5]
{
    // j=0    j=1    j=2    j=3    j=4
    { true,  false, true,  false, false }, // i=0
    { false, true,  false, true,  false }, // i=1
    { false, false, true,  false, false }, // i=2
    { false, false, false, true,  false }, // i=3
    { false, false, false, false, true  }  // i=4
};
*/
/*
Longest Palindromic Substring

Given a string s, return the longest substring of s that is a palindrome.

A palindrome is a string that reads the same forward and backward.

If there are multiple palindromic substrings that have the same length, return any one of them.

Example 1:

Input: s = "ababd"

Output: "bab"
Explanation: Both "aba" and "bab" are valid answers.

Example 2:

Input: s = "abbc"

Output: "bb"
Constraints:

1 <= s.length <= 1000
s contains only digits and English letters.
*/