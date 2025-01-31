public partial class Solution {
    
    public List<List<string>> PartitionBT3(string s) {
        int n = s.Length;
        bool[,] dp = new bool[n, n];
        for (int l = 1; l <= n; l++) {
            for (int i = 0; i <= n - l; i++) {
                dp[i, i + l - 1] = (s[i] == s[i + l - 1] && 
                                    (i + 1 > (i + l - 2) || 
                                    dp[i + 1, i + l - 2]));
            }
        }
        
        List<List<string>> res = new List<List<string>>();
        List<string> part = new List<string>();
        PBT3Dfs(0, s, part, res, dp);
        return res;
    }

    private void PBT3Dfs(int i, string s, List<string> part, List<List<string>> res, bool[,] dp) {
        if (i >= s.Length) {
            res.Add(new List<string>(part));
            return;
        }
        for (int j = i; j < s.Length; j++) {
            if (dp[i, j]) {
                part.Add(s.Substring(i, j - i + 1));
                PBT3Dfs(j + 1, s, part, res, dp);
                part.RemoveAt(part.Count - 1);
            }
        }
    }
}

/*
In this algorithm, the dp table is used for precomputing palindrome 
information about substrings in the input string s.

During the DFS traversal, instead of recalculating whether a substring 
is a palindrome (like in IsPali), the algorithm directly references 
the precomputed dp[i, j].
If dp[i, j] is true, it proceeds to recursively explore partitions for 
the rest of the string.

What dp contains:
Step-by-Step Computation

1. Substrings of Length 1 (l = 1):
All single-character substrings are palindromes:
dp[0][0] = true (substring: "a")
dp[1][1] = true (substring: "a")
dp[2][2] = true (substring: "b")
2. Substrings of Length 2 (l = 2):

Check if the first and last characters are equal:
dp[0][1] = true (substring: "aa" → first and last are equal)
dp[1][2] = false (substring: "ab" → first and last are not equal)

3. Substrings of Length 3 (l = 3):
Check if the first and last characters are equal, and if the middle portion is a palindrome:
dp[0][2] = false (substring: "aab" → first and last are not equal)


Dfs(0, "aab", [], res)  
  Iteration 0: Check dp[0,0] ("a") → true  
    Dfs(1, "aab", ["a"], res)  
      Iteration 1: Check dp[1,1] ("a") → true  
        Dfs(2, "aab", ["a", "a"], res)  
          Iteration 2: Check dp[2,2] ("b") → true  
            Dfs(3, "aab", ["a", "a", "b"], res)  
              Add partition ["a", "a", "b"] to res  
          Backtrack: Remove "b" from ["a", "a", "b"]  
        Backtrack: Remove "a" from ["a", "a"]  
      Iteration 2: Check dp[1,2] ("ab") → false  
    Backtrack: Remove "a" from ["a"]  
  
  Iteration 1: Check dp[0,1] ("aa") → true  
    Dfs(2, "aab", ["aa"], res)  
      Iteration 2: Check dp[2,2] ("b") → true  
        Dfs(3, "aab", ["aa", "b"], res)  
          Add partition ["aa", "b"] to res  
      Backtrack: Remove "b" from ["aa", "b"]  
    Backtrack: Remove "aa" from ["aa"]  
  
  Iteration 2: Check dp[0,2] ("aab") → false  

*/

/*
Palindrome Partitioning

Given a string s, split s into substrings where every substring is a 
palindrome. Return all possible lists of palindromic substrings.

You may return the solution in any order.

Example 1:
Input: s = "aab"
Output: [["a","a","b"],["aa","b"]]

Example 2:
Input: s = "a"
Output: [["a"]]

Constraints:
1 <= s.length <= 20
s contains only lowercase English letters.
*/