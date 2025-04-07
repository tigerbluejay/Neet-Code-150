public partial class Solution {
    // This method finds the longest palindromic substring using brute-force
    public string BFLongestPalindrome(string s) {
        string res = "";     // Store the longest palindrome found
        int resLen = 0;      // Store the length of the longest palindrome

        // Outer loop: fix the start index of the substring
        for (int i = 0; i < s.Length; i++) {
            // Inner loop: fix the end index of the substring
            for (int j = i; j < s.Length; j++) {
                int l = i, r = j;

                // Check if the current substring s[i..j] is a palindrome
                while (l < r && s[l] == s[r]) {
                    l++;
                    r--;
                }

                // If it's a palindrome and longer than what we found before
                if (l >= r && resLen < (j - i + 1)) {
                    res = s.Substring(i, j - i + 1);  // Update the longest palindrome
                    resLen = j - i + 1;               // Update the max length
                }
            }
        }

        return res;  // Return the longest palindrome found
    }
}

/*
✅ Part 2: Tree-like Step-by-Step Output for Input "ababd"

We'll show how the function checks substrings and updates the result if it 
finds a longer palindrome.

Input: s = "ababd"
Start:
s = "ababd"
res = "", resLen = 0

Step-by-step:

i=0:
  j=0: s[0..0] = "a" → Palindrome → Update res = "a"
  j=1: s[0..1] = "ab" → Not a palindrome
  j=2: s[0..2] = "aba" → Palindrome → Update res = "aba"
  j=3: s[0..3] = "abab" → Not a palindrome
  j=4: s[0..4] = "ababd" → Not a palindrome

i=1:
  j=1: s[1..1] = "b" → Palindrome (length 1 < resLen)
  j=2: s[1..2] = "ba" → Not a palindrome
  j=3: s[1..3] = "bab" → Palindrome (length 3 = resLen) → No update
  j=4: s[1..4] = "babd" → Not a palindrome

i=2:
  j=2: s[2..2] = "a" → Palindrome (length 1 < resLen)
  j=3: s[2..3] = "ab" → Not a palindrome
  j=4: s[2..4] = "abd" → Not a palindrome

i=3:
  j=3: s[3..3] = "b" → Palindrome (length 1 < resLen)
  j=4: s[3..4] = "bd" → Not a palindrome

i=4:
  j=4: s[4..4] = "d" → Palindrome (length 1 < resLen)

Final result: "aba"
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