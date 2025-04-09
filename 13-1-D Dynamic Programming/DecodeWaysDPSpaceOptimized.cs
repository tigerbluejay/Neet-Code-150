public partial class Solution {
    public int SONumDecodings(string s) {
        // dp1 = number of ways to decode from index i+1
        // dp2 = number of ways to decode from index i+2
        // dp = current value for dp[i]
        int dp = 0, dp1 = 1, dp2 = 0;

        // Loop backward through the string
        for (int i = s.Length - 1; i >= 0; i--) {
            if (s[i] == '0') {
                dp = 0; // No decoding possible from a leading '0'
            } else {
                dp = dp1; // Decode one digit
                // Check if two-digit decode is valid
                if (i + 1 < s.Length && 
                   (s[i] == '1' || 
                   (s[i] == '2' && s[i + 1] < '7'))) {
                    dp += dp2;
                }
            }

            // Shift dp1 and dp2 for the next iteration
            dp2 = dp1;
            dp1 = dp;
            dp = 0;
        }

        // dp1 now holds the answer for index 0
        return dp1;
    }
}
/*
✅ 2. Tree-Like Output for Input "1342"
Let’s simulate the values of dp, dp1, and dp2 for each index:

Input: "1342"

Initial: dp1 = 1, dp2 = 0

Index 3 ('2'):
  '2' is valid alone → dp = dp1 = 1
  No pair possible → dp = 1
  Update: dp2 = 1, dp1 = 1

Index 2 ('4'):
  '4' is valid alone → dp = dp1 = 1
  '42' is invalid → dp = 1
  Update: dp2 = 1, dp1 = 1

Index 1 ('3'):
  '3' is valid alone → dp = dp1 = 1
  '34' is invalid → dp = 1
  Update: dp2 = 1, dp1 = 1

Index 0 ('1'):
  '1' is valid alone → dp = dp1 = 1
  '13' is valid → add dp2 → dp += 1 → dp = 2
  Update: dp2 = 1, dp1 = 2

Return: dp1 = 2

🧾 Final Variable Values
i	s[i]	dp	dp1 (i+1)	dp2 (i+2)	Comment
3	'2'    	1	1	        0	        Only one-digit valid
2	'4'    	1	1	        1	        Only one-digit valid
1	'3' 	1	1	        1	        Only one-digit valid
0	'1'	    2	2	        1	        One-digit + valid two-digit ('13')/*
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