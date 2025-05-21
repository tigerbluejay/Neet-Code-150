public partial class Solution {
    public string TPLongestPalindrome(string s) {
        // Store the length and starting index of the longest palindrome found
        int resLen = 0, resIdx = 0;

        // Iterate through each character in the string
        for (int i = 0; i < s.Length; i++) {
            // === Handle odd-length palindromes (centered at s[i]) ===
            int l = i, r = i;  // both left and right start at center
            while (l >= 0 && r < s.Length && s[l] == s[r]) {
                // Update result if new longer palindrome is found
                if (r - l + 1 > resLen) {
                    resIdx = l;
                    resLen = r - l + 1;
                }
                l--;  // expand left
                r++;  // expand right
            }

            // === Handle even-length palindromes (centered between s[i] and s[i+1]) ===
            l = i;
            r = i + 1;  // center is between characters
            while (l >= 0 && r < s.Length && s[l] == s[r]) {
                if (r - l + 1 > resLen) {
                    resIdx = l;
                    resLen = r - l + 1;
                }
                l--;
                r++;
            }
        }

        // Return the longest palindromic substring
        return s.Substring(resIdx, resLen);
    }
}

/*
✅ 2. Tree-Like Step-by-Step Output for Input "ababd"

Input: s = "ababd"

Character positions:
  a   b   a   b   d
  0   1   2   3   4

i = 0
 - Odd center at s[0] ("a")
   → Expand: s[0] = 'a' → ✅
   → "a" (len 1) ← new max
 - Even center between s[0] & s[1] ("ab") → ❌

---

i = 1
 - Odd center at s[1] ("b")
   → Expand: s[1] = 'b' → ✅
   → Expand: s[0]='a', s[2]='a' → ✅
   → "aba" (len 3) ← new max
 - Even center between s[1] & s[2] ("ba") → ❌

---

i = 2
 - Odd center at s[2] ("a")
   → Expand: s[2] = 'a' → ✅
   → Expand: s[1]='b', s[3]='b' → ✅
   → Expand: s[0]='a', s[4]='d' → ❌
   → "bab" (len 3) ← same as current max
 - Even center between s[2] & s[3] ("ab") → ❌

---

i = 3
 - Odd center at s[3] ("b")
   → Expand: s[3] = 'b' → ✅
   → Expand: s[2]='a', s[4]='d' → ❌
   → "b" (len 1)
 - Even center between s[3] & s[4] ("bd") → ❌

---

i = 4
 - Odd center at s[4] ("d")
   → Expand: s[4] = 'd' → ✅
   → "d" (len 1)
 - Even center between s[4] & s[5] → out of bounds → ❌

---

✅ Final result: "aba" (length 3)
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