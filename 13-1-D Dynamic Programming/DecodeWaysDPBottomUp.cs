
public partial class Solution {
    public int BUNumDecodings(string s) {
        // dp[i] represents the number of ways to decode the substring s[i..]
        int[] dp = new int[s.Length + 1];

        // Base case: there's 1 way to decode an empty string
        dp[s.Length] = 1;

        // Iterate from the second-last character to the first
        for (int i = s.Length - 1; i >= 0; i--) {
            // If the current digit is '0', it can't be decoded
            if (s[i] == '0') {
                dp[i] = 0;
            } else {
                // At least we can decode the current digit as a letter
                dp[i] = dp[i + 1];

                // Also try decoding two digits (if valid)
                if (i + 1 < s.Length && 
                   (s[i] == '1' || 
                   (s[i] == '2' && s[i + 1] < '7'))) {
                    dp[i] += dp[i + 2];
                }
            }
        }

        // The answer is the number of ways to decode from index 0
        return dp[0];
    }
}

/*
✅ 2. Tree-like Structure for Input "1342"
Let’s simulate the bottom-up table filling process for s = "1342":

🧾 Tree-Like Output (Notepad Friendly)

BUNumDecodings("1342")

Index: 3, Char: '2'
    dp[3] = 1   // '2' is valid → 1 way (dp[4])

Index: 2, Char: '4'
    dp[2] = 1   // '4' is valid → dp[3]
    '42' is invalid as a pair → no dp[4] added

Index: 1, Char: '3'
    dp[1] = 1   // '3' is valid → dp[2]
    '34' is invalid → no dp[3] added

Index: 0, Char: '1'
    dp[0] = 1   // '1' is valid → dp[1]
    '13' is valid → dp[2] added
    dp[0] = 1 + 1 = 2

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