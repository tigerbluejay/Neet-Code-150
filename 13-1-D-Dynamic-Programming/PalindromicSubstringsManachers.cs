public partial class Solution {
    // Manacher's Algorithm: builds an array p[i] that tells how far we can expand from i
    public int[] PSManacher(string s) {
        // Preprocess: insert '#' between every character and at ends
        // This handles even and odd length palindromes uniformly
        string t = "#" + string.Join("#", s.ToCharArray()) + "#";
        int n = t.Length;
        int[] p = new int[n]; // p[i] = radius of palindrome centered at i
        int l = 0, r = 0;     // current palindrome boundaries

        for (int i = 0; i < n; i++) {
            // Try to mirror and use previously computed value if within bounds
            if (i < r) {
                p[i] = Math.Min(r - i, p[l + (r - i)]);
            }

            // Expand around center i
            while (i + p[i] + 1 < n && i - p[i] - 1 >= 0 &&
                   t[i + p[i] + 1] == t[i - p[i] - 1]) {
                p[i]++;
            }

            // Update the rightmost palindrome if this one expands farther
            if (i + p[i] > r) {
                l = i - p[i];
                r = i + p[i];
            }
        }

        return p;
    }

    // Counts palindromic substrings from the p[] array
    public int MCountSubstrings(string s) {
        int[] p = PSManacher(s);
        int res = 0;

        // Each radius p[i] contributes (p[i] + 1) / 2 substrings
        foreach (int i in p) {
            res += (i + 1) / 2;
        }

        return res;
    }
}

/*
🧪 Input: s = "aaa"
Transformed string with sentinels:

t = # a # a # a #
    0 1 2 3 4 5 6

🌳 Walkthrough Tree for Manacher's Algorithm (index by t)

i = 0 → center '#'
├── p[0] = 0 (can't expand)

i = 1 → center 'a'
├── expands to match '#' at 0 and '#' at 2 → p[1] = 1

i = 2 → center '#'
├── mirrors i=0 (symmetric around i=1) → p[2] = 0
├── expands to match 'a' at 1 and 'a' at 3 → p[2] = 1

i = 3 → center 'a'
├── mirrors i=1 → p[3] = 1
├── expands to match '#' at 2 and '#' at 4 → p[3] = 2

i = 4 → center '#'
├── mirrors i=2 → p[4] = 1
├── expands to match 'a' at 3 and 'a' at 5 → p[4] = 2

i = 5 → center 'a'
├── mirrors i=3 → p[5] = 2
├── expands to match '#' at 4 and '#' at 6 → p[5] = 3

i = 6 → center '#'
├── mirrors i=4 → p[6] = 0 (edge)

📊 Final p[] array
Index (t):  0  1  2  3  4  5  6
Char (t):   #  a  #  a  #  a  #
p[i]:       0  1  1  2  2  3  0

📈 Count Palindromic Substrings from p[]
Using (p[i] + 1) / 2 per index:

p = [0, 1, 1, 2, 2, 3, 0]
     ↓  ↓  ↓  ↓  ↓  ↓  ↓
     0+ 1+ 1+ 1+ 1+ 2+ 0 = 6

✅ Total Palindromic Substrings: 6

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