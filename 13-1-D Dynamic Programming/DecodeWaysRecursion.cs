public partial class Solution {
    public int RNumDecodings(string s) {
        // Helper function that performs a DFS starting at index i
        int Dfs(int i) {
            // Base case: If we've reached the end of the string, 
            // there's one valid decoding
            if (i == s.Length) return 1;

            // If the current character is '0', it's not decodable
            if (s[i] == '0') return 0;

            // Start with decoding one digit (s[i])
            int res = Dfs(i + 1);

            // Check if a valid two-digit decoding is possible (s[i]s[i+1])
            if (i < s.Length - 1) {
                // Valid two-digit decoding if:
                // - Starts with '1' (10 to 19)
                // - Starts with '2' and next digit is between 0 and 6 (20 to 26)
                if (s[i] == '1' || (s[i] == '2' && s[i + 1] < '7')) {
                    res += Dfs(i + 2);
                }
            }

            // Return total number of ways to decode from index i
            return res;
        }

        // Start DFS from index 0
        return Dfs(0);
    }
}

/*
🌲 Tree Output for Input "1342"

Each level represents a recursive call. 
The number is the index in the string we're currently at (Dfs(i)), 
followed by the next possible steps.

Dfs(0) -> '1' → valid
├── Dfs(1) -> '3' → valid
│   ├── Dfs(2) -> '4' → valid
│   │   ├── Dfs(3) -> '2' → valid
│   │   │   └── Dfs(4) ✅ = 1
│   │   └── Dfs(4) ❌ invalid (i == s.Length) -> already counted above
│   └── Dfs(3) -> '2' (check if 42 is valid) ❌ invalid two-digit
├── Dfs(2) -> '4' → check if 13 is valid ✅
│   └── Dfs(3) -> '2' → valid
│       └── Dfs(4) ✅ = 1
✅ Valid decoding paths:
"1" "3" "4" "2"

"13" "4" "2"

✅ Total: 2 decodings.

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