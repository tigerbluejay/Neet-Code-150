public partial class Solution
{
    public int RLongestCommonSubsequence(string text1, string text2)
    {
        // Start the DFS recursion from the beginning of both strings
        return LCSRDfs(text1, text2, 0, 0);
    }

    private int LCSRDfs(string text1, string text2, int i, int j)
    {
        // Base case: if either string is fully traversed, no further common subsequence
        if (i == text1.Length || j == text2.Length)
        {
            return 0;
        }

        // If the current characters match, count 1 and move both pointers forward
        if (text1[i] == text2[j])
        {
            return 1 + LCSRDfs(text1, text2, i + 1, j + 1);
        }

        // If not matching, branch into two options:
        // 1. Move pointer i forward (skip character in text1)
        // 2. Move pointer j forward (skip character in text2)
        // Take the maximum of these two options
        return Math.Max(
            LCSRDfs(text1, text2, i + 1, j),
            LCSRDfs(text1, text2, i, j + 1)
        );
    }
}

/*
This algorithm computes the Longest Common Subsequence (LCS) between two strings using a 
naive Depth-First Search (DFS) approach without memoization. It starts with two pointers, 
i and j, both initially at position 0 in their respective strings. If the characters at 
these positions match, the algorithm counts 1 toward the LCS length and recursively 
continues with both pointers advanced by one. If the characters do not match, it explores 
two possibilities: either skipping the character from text1 (i + 1) or from text2 (j + 1),
 and takes the maximum result of these two recursive calls. The recursion terminates when 
 either string has been completely traversed. This brute-force method has exponential time 
 complexity, O(2^(m + n)), making it inefficient for longer strings.
*/

/*
Dfs(0, 0) -> Match 'c'
|
+-- 1 + Dfs(1, 1)
    |
    +-- Dfs(1, 1) -> No Match 'a' vs 'r'
        |
        +-- Dfs(2, 1) -> No Match 't' vs 'r'
        |   |
        |   +-- Dfs(3, 1) -> Base case -> 0
        |   |
        |   +-- Dfs(2, 2) -> No Match 't' vs 'a'
        |       |
        |       +-- Dfs(3, 2) -> Base case -> 0
        |       |
        |       +-- Dfs(2, 3) -> No Match 't' vs 'b'
        |           |
        |           +-- Dfs(3, 3) -> Base case -> 0
        |           |
        |           +-- Dfs(2, 4) -> Match 't'
        |               |
        |               +-- 1 + Dfs(3, 5) -> Base case -> 0
        |               -> returns 1
        |           -> Max(0, 1) = 1
        |       -> Max(0, 1) = 1
        |   -> Max(0, 1) = 1
        |
        +-- Dfs(1, 2) -> Match 'a'
            |
            +-- 1 + Dfs(2, 3)
                |
                +-- Dfs(2, 3) -> No Match 't' vs 'b'
                    |
                    +-- Dfs(3, 3) -> Base case -> 0
                    |
                    +-- Dfs(2, 4) -> Match 't'
                        |
                        +-- 1 + Dfs(3, 5) -> Base case -> 0
                        -> returns 1
                    -> Max(0, 1) = 1
                -> 1 + 1 = 2
            -> returns 2
        -> Max(1, 2) = 2
    -> returns 2
-> 1 + 2 = 3

Result = 3
✅ Summary of Matches:
Dfs(0,0) → 'c' matches 'c'
Dfs(1,2) → 'a' matches 'a'
Dfs(2,4) → 't' matches 't'

These form the LCS "cat" of length 3.
*/


/*
Longest Common Subsequence

Given two strings text1 and text2, return the length of the longest common subsequence 
between the two strings if one exists, otherwise return 0.

A subsequence is a sequence that can be derived from the given sequence by deleting some 
or no elements without changing the relative order of the remaining characters.

For example, "cat" is a subsequence of "crabt".
A common subsequence of two strings is a subsequence that exists in both strings.

Example 1:
Input: text1 = "cat", text2 = "crabt" 
Output: 3 
Explanation: The longest common subsequence is "cat" which has a length of 3.

Example 2:
Input: text1 = "abcd", text2 = "abcd"
Output: 4

Example 3:
Input: text1 = "abcd", text2 = "efgh"
Output: 0

Constraints:
1 <= text1.length, text2.length <= 1000
text1 and text2 consist of only lowercase English characters.
*/