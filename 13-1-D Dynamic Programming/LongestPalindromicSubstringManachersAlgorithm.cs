public partial class Solution {

    // Preprocess input and compute LPS (Longest Palindromic Substring) radii
    public int[] LPSManacher(string s) {
        // Transform original string by inserting '#' between each character and 
        // at the ends
        // Example: "ababd" => "#a#b#a#b#d#"
        string t = "#" + string.Join("#", s.ToCharArray()) + "#";
        int n = t.Length;
        int[] p = new int[n]; // p[i] stores the radius of palindrome centered at i
        int l = 0, r = 0;     // [l, r] is the current known palindrome range

        for (int i = 0; i < n; i++) {
            // Mirror optimization: use previously computed value if within bounds
            p[i] = (i < r) ? Math.Min(r - i, p[l + (r - i)]) : 0;

            // Try to expand palindrome centered at i
            while (i + p[i] + 1 < n && i - p[i] - 1 >= 0 &&
                   t[i + p[i] + 1] == t[i - p[i] - 1]) {
                p[i]++;
            }

            // If expanded palindrome goes beyond current right boundary, update [l, r]
            if (i + p[i] > r) {
                l = i - p[i];
                r = i + p[i];
            }
        }

        return p;
    }

    // Use the LPS array to find and extract the longest palindrome
    public string MLongestPalindrome(string s) {
        int[] p = LPSManacher(s);
        int resLen = 0, center_idx = 0;

        // Find the center with the max radius
        for (int i = 0; i < p.Length; i++) {
            if (p[i] > resLen) {
                resLen = p[i];
                center_idx = i;
            }
        }

        // Translate the index back to the original string
        int resIdx = (center_idx - resLen) / 2;
        return s.Substring(resIdx, resLen);
    }
}
/*
Manacher’s Algorithm finds the longest palindromic 
substring in linear time O(n), which is optimal.

🔍 Core Idea:
Transform the string to handle even and odd-length palindromes 
uniformly.

Keep track of a current center (l) and right boundary (r) 
of the known palindrome.

Use previously computed information (symmetry) to skip 
unnecessary comparisons.

Update a list p[] where p[i] = length of palindrome centered at
i in the transformed string.
*/
/*
We insert # between all characters and at the ends to handle 
even/odd palindromes uniformly.

t = "#a#b#a#b#d#"
indexes:  0 1 2 3 4 5 6 7 8 9 10
original:   0   1   2   3   4

🌳 Tree-like Step-by-Step Expansion:

i = 0 → t[0] = '#'
  → expand: t[-1] out of bounds → stop
  → p[0] = 0
  → i + p[i] (=0) > r (=0)? → false → do not update center

i = 1 → t[1] = 'a'
  → expand: t[0]=# & t[2]=# → ✅
  → p[1] = 1
  → i + p[i] (=2) > r (=0)? → true
    → update center: l = 0, r = 2

i = 2 → t[2] = '#'
  → i < r → mirror = p[0] = 0 → p[2] = 0
  → expand: t[1]=a & t[3]=b → ❌
  → p[2] = 0
  → i + p[i] (=2) > r (=2)? → false

i = 3 → t[3] = 'b'
  → i < r → mirror = p[1] = 1 → p[3] = min(2,1) = 1
  → expand:
     t[2]=# & t[4]=# → ✅ → p[3] = 2
     t[1]=a & t[5]=a → ✅ → p[3] = 3
     t[0]=# & t[6]=# → ✅ → p[3] = 4
     t[-1] out of bounds → stop
  → i + p[i] (=7) > r (=2)? → true
    → update center: l = -1, r = 7

i = 4 → t[4] = '#'
  → i < r → mirror = p[2] = 0 → p[4] = 0
  → expand: t[3]=b & t[5]=a → ❌
  → p[4] = 0
  → i + p[i] (=4) > r (=7)? → false

i = 5 → t[5] = 'a'
  → i < r → mirror = p[1] = 1 → p[5] = min(2,1) = 1
  → expand:
     t[4]=# & t[6]=# → ✅ → p[5] = 2
     t[3]=b & t[7]=b → ✅ → p[5] = 3
     t[2]=# & t[8]=# → ✅ → p[5] = 4
     t[1]=a & t[9]=d → ❌
  → i + p[i] (=9) > r (=7)? → true
    → update center: l = 1, r = 9

i = 6 → t[6] = '#'
  → i < r → mirror = p[4] = 0 → p[6] = 0
  → expand: t[5]=a & t[7]=b → ❌
  → p[6] = 0

i = 7 → t[7] = 'b'
  → i < r → mirror = p[3] = 3 → p[7] = min(2,3) = 2
  → expand:
     t[6]=# & t[8]=# → ✅ → p[7] = 3
     t[5]=a & t[9]=d → ❌
  → i + p[i] (=10) > r (=9)? → true
    → update center: l = 4, r = 10

i = 8 → t[8] = '#'
  → i < r → mirror = p[2] = 0 → p[8] = 0
  → expand: t[7]=b & t[9]=d → ❌
  → p[8] = 0

i = 9 → t[9] = 'd'
  → i < r → mirror = p[1] = 1 → p[9] = min(1,1) = 1
  → expand:
     t[8]=# & t[10]=# → ✅ → p[9] = 2
     t[7]=b & t[11] out of bounds → stop
  → i + p[i] (=11) > r (=10)? → true
    → update center: l = 7, r = 11

i = 10 → t[10] = '#'
  → i < r → mirror = p[0] = 0 → p[10] = 0
  → expand: t[9]=d & t[11] out of bounds → stop

✅ Final p[] Table
int[] p = {0, 1, 0, 3, 0, 3, 0, 3, 0, 1, 0};

🧠 Final Result Extraction
We find the max value in p[], which is 3 (occurs at i = 5).

center_idx = 5
resLen = 3
resIdx = (center_idx - resLen) / 2 = (5 - 3) / 2 = 1

So we return:
s.Substring(1, 3) → "bab"
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