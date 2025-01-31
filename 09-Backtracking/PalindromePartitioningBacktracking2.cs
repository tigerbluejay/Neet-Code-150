public partial class Solution {
    
    public List<List<string>> PartitionBT2(string s) {
        List<List<string>> res = new List<List<string>>();
        List<string> part = new List<string>();
        PBT2Dfs(0, s, part, res);
        return res;
    }

    private void PBT2Dfs(int i, string s, List<string> part, List<List<string>> res) {
        if (i >= s.Length) {
            res.Add(new List<string>(part));
            return;
        }
        for (int j = i; j < s.Length; j++) {
            if (IsPali(s, i, j)) {
                part.Add(s.Substring(i, j - i + 1));
                PBT2Dfs(j + 1, s, part, res);
                part.RemoveAt(part.Count - 1);
            }
        }
    }

    private bool IsPali(string s, int l, int r) {
        while (l < r) {
            if (s[l] != s[r]) {
                return false;
            }
            l++;
            r--;
        }
        return true;
    }
}

/*
Dfs(0, "aab", [], res)  

  Iteration 0: Check substring "a" → IsPali = true  
    Dfs(1, "aab", ["a"], res)  
      Iteration 1: Check substring "a" → IsPali = true  
        Dfs(2, "aab", ["a", "a"], res)  
          Iteration 2: Check substring "b" → IsPali = true  
            Dfs(3, "aab", ["a", "a", "b"], res)  
              Add partition ["a", "a", "b"] to res  
          Backtrack: Remove "b" from ["a", "a", "b"]  
        Backtrack: Remove "a" from ["a", "a"]  
      Iteration 2: Check substring "ab" → IsPali = false  
    Backtrack: Remove "a" from ["a"]  

  Iteration 1: Check substring "aa" → IsPali = true  
    Dfs(2, "aab", ["aa"], res)  
      Iteration 2: Check substring "b" → IsPali = true  
        Dfs(3, "aab", ["aa", "b"], res)  
          Add partition ["aa", "b"] to res  
      Backtrack: Remove "b" from ["aa", "b"]  
    Backtrack: Remove "aa" from ["aa"]  

  Iteration 2: Check substring "aab" → IsPali = false 

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