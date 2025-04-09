public partial class Solution {

    // Entry point for the decoding count
    public int TDNumDecodings(string s) {
        // Dictionary for memoization: stores results of subproblems
        Dictionary<int, int> dp = new Dictionary<int, int>();

        // Base case: one valid decoding from the end of the string
        dp[s.Length] = 1;

        // Start recursion from index 0
        return Dfs(s, 0, dp);
    }

    // Recursive function with memoization
    private int Dfs(string s, int i, Dictionary<int, int> dp) {
        // If result is already computed, return it
        if (dp.ContainsKey(i)) {
            return dp[i];
        }

        // If character is '0', no valid decoding
        if (s[i] == '0') {
            return 0;
        }

        // Start with decoding one digit
        int res = Dfs(s, i + 1, dp);

        // Check if decoding two digits is valid
        if (i + 1 < s.Length && 
            (s[i] == '1' || (s[i] == '2' && s[i + 1] < '7'))) {
            res += Dfs(s, i + 2, dp);
        }

        // Save result in memoization dictionary
        dp[i] = res;
        return res;
    }
}

/*
Dfs(0) -> '1' is valid
├── Dfs(1) -> '3' is valid
│   ├── Dfs(2) -> '4' is valid
│   │   ├── Dfs(3) -> '2' is valid
│   │   │   └── Dfs(4) ✅ base case → 1
│   │   └── Dfs(4) = 1 → cached
│   │   => dp[3] = 1, dp[2] = 1
│   └── Dfs(3) = 1 → cached
│   => dp[1] = 1
├── Dfs(2) -> check "13" → valid two-digit
│   └── Dfs(3) = 1 → cached
│   => dp[0] = 2

Memoization Table (Final State)
dp[4] = 1  // base case
dp[3] = 1  // decoding "2"
dp[2] = 1  // decoding "4" then "2"
dp[1] = 1  // decoding "3" then "4" then "2"
dp[0] = 2  // "1-3-4-2" or "13-4-2"

Final Result:
2 decoding ways for "1342"
"1" "3" "4" "2"
"13" "4" "2"

What Is the DP Dictionary Doing?

The dp dictionary stores the number of ways to decode the substring 
starting at index i in the string s.

So, dp[i] = number of decoding ways for s[i..end].

This avoids recalculating results for the same index multiple times 
(which happens a lot in pure recursion).

*/

/*
Decode Ways

A string consisting of uppercase english characters can be encoded to a 
number using the following mapping:

'A' -> "1"
'B' -> "2"
...
'Z' -> "26"

To decode a message, digits must be grouped and then mapped back into 
letters using the reverse of the mapping above. There may be multiple ways 
to decode a message. For example, "1012" can be mapped into:

"JAB" with the grouping (10 1 2)
"JL" with the grouping (10 12)
The grouping (1 01 2) is invalid because 01 cannot be mapped into a letter 
since it contains a leading zero.

Given a string s containing only digits, return the number of ways to 
decode it. You can assume that the answer fits in a 32-bit integer.

Example 1:
Input: s = "12"
Output: 2
Explanation: "12" could be decoded as "AB" (1 2) or "L" (12).

Example 2:
Input: s = "01"
Output: 0
Explanation: "01" cannot be decoded because "01" cannot be mapped into a letter.

Constraints:
1 <= s.length <= 100
s consists of digits
*/