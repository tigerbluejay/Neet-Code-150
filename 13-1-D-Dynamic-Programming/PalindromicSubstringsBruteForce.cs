public partial class Solution {
    public int BFCountSubstrings(string s) {
        int res = 0;

        for (int i = 0; i < s.Length; i++) {
            for (int j = i; j < s.Length; j++) {
                int l = i, r = j;
                while (l < r && s[l] == s[r]) {
                    l++;
                    r--;
                }
                res += (l >= r) ? 1 : 0;
            }
        }

        return res;
    }
}
/*
Input: s = "aaa"

We loop i from 0 to 2 (inclusive)
  For each i, we loop j from i to 2 (inclusive)
    For each substring s[i..j], check if it's a palindrome

Tree walkthrough:

i = 0
├── j = 0 → substring: "a"
│   └── l = 0, r = 0 → s[l] == s[r] → l >= r → valid → count++
├── j = 1 → substring: "aa"
│   ├── l = 0, r = 1 → s[0] == s[1] ('a'=='a') → l=1, r=0 → l >= r → valid → count++
├── j = 2 → substring: "aaa"
│   ├── l = 0, r = 2 → s[0] == s[2] ('a'=='a') → l=1, r=1
│   └── s[1] == s[1] ('a'=='a') → l=2, r=0 → l >= r → valid → count++

i = 1
├── j = 1 → substring: "a"
│   └── l = 1, r = 1 → s[l] == s[r] → l >= r → valid → count++
├── j = 2 → substring: "aa"
│   ├── l = 1, r = 2 → s[1] == s[2] ('a'=='a') → l=2, r=1 → l >= r → valid → count++

i = 2
├── j = 2 → substring: "a"
│   └── l = 2, r = 2 → s[l] == s[r] → l >= r → valid → count++

Total palindromic substrings: 6
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