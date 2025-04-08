public partial class Solution {
    public int TPCountSubstrings(string s) {
        int res = 0;

        for (int i = 0; i < s.Length; i++) {
            // Odd-length palindromes (single char center)
            int l = i, r = i;
            while (l >= 0 && r < s.Length && s[l] == s[r]) {
                res++;  // Found palindrome s[l..r]
                l--;
                r++;
            }

            // Even-length palindromes (center between i and i+1)
            l = i;
            r = i + 1;
            while (l >= 0 && r < s.Length && s[l] == s[r]) {
                res++;  // Found palindrome s[l..r]
                l--;
                r++;
            }
        }

        return res;
    }
}
/*
i = 0:
├── odd: center at 0
│   ├── l=0, r=0 → "a" → match → count++
│   └── l=-1, r=1 → out of bounds → stop
├── even: center between 0 and 1
│   ├── l=0, r=1 → "aa" → match → count++
│   └── l=-1, r=2 → out of bounds → stop

i = 1:
├── odd: center at 1
│   ├── l=1, r=1 → "a" → match → count++
│   ├── l=0, r=2 → "aaa" → match → count++
│   └── l=-1, r=3 → out of bounds → stop
├── even: center between 1 and 2
│   ├── l=1, r=2 → "aa" → match → count++
│   └── l=0, r=3 → out of bounds → stop

i = 2:
├── odd: center at 2
│   ├── l=2, r=2 → "a" → match → count++
│   └── l=1, r=3 → out of bounds → stop
├── even: center between 2 and 3
│   └── r = 3 → out of bounds → skip

Total Counted Palindromes = 6
*/

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