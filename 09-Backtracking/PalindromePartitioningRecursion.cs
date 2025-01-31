public partial class Solution {
    
    public List<List<string>> PartitionRecursion(string s) {
        int n = s.Length;
        bool[,] dp = new bool[n, n];
        for (int l = 1; l <= n; l++) {
            for (int i = 0; i <= n - l; i++) {
                // precompute a multidimensional array
                // with true and false values for when there is
                // a palindrome or there isn't
                dp[i, i + l - 1] = (s[i] == s[i + l - 1] && 
                                    (i + 1 > (i + l - 2) || 
                                    dp[i + 1, i + l - 2]));
            }
        }
        
        return PPRDfs(s, dp, 0);
    }

    private List<List<string>> PPRDfs(string s, bool[,] dp, int i) {
        if (i >= s.Length) {
            return new List<List<string>> { new List<string>() };
        }

        var ret = new List<List<string>>();
        for (int j = i; j < s.Length; j++) {
            if (dp[i, j]) { // if at such index there is a palindrome
                // proceed with Dfs
                var nxt = PPRDfs(s, dp, j + 1);
                foreach (var part in nxt) {
                    var cur = new List<string> { s.Substring(i, j - i + 1) };
                    cur.AddRange(part);
                    ret.Add(cur);
                }
            }
        }
        return ret;
    }
}
/*
Dfs(0):
  
  Iteration 0: Check substring "a" → IsPali = true
    Dfs(1):
      Iteration 1: Check substring "a" → IsPali = true
        Dfs(2):
          Iteration 2: Check substring "b" → IsPali = true
            Dfs(3): Base Case → Return [[]]
          Combine "b" with [[]] → Add ["b"]
        Combine "a" with ["b"] → Add ["a", "b"]
      Backtrack: Remove "a"
      Iteration 2: Check substring "ab" → IsPali = false
    Combine "a" with ["a", "b"] → Add ["a", "a", "b"]
  Backtrack: Remove "a"
  
  Iteration 1: Check substring "aa" → IsPali = true
    Dfs(2):
      Iteration 2: Check substring "b" → IsPali = true
        Dfs(3): Base Case → Return [[]]
      Combine "b" with [[]] → Add ["b"]
    Combine "aa" with ["b"] → Add ["aa", "b"]
  Backtrack: Remove "aa"
  
  Iteration 2: Check substring "aab" → IsPali = false

Combine Results: Add ["a", "a", "b"] and ["aa", "b"]
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