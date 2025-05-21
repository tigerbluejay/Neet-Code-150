public partial class Solution {
    
    public int TPOCountSubstrings(string s) {
        int res = 0;
        for (int i = 0; i < s.Length; i++) {
            res += CountPali(s, i, i);
            res += CountPali(s, i, i + 1);
        }
        return res;
    }

    private int CountPali(string s, int l, int r) {
        int res = 0;
        while (l >= 0 && r < s.Length && s[l] == s[r]) {
            res++;
            l--;
            r++;
        }
        return res;
    }
}


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