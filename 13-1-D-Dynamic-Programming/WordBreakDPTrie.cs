// Trie node class to represent each character
public class WBTrieNode {
    public Dictionary<char, WBTrieNode> Children; 
    // Children nodes for each possible next character
    public bool IsWord; // Marks if the current node ends a complete word

    public WBTrieNode() {
        Children = new Dictionary<char, WBTrieNode>();
        IsWord = false;
    }
}

// Trie structure for efficient prefix-based word lookup
public class WBTrie {
    public WBTrieNode Root;

    public WBTrie() {
        Root = new WBTrieNode();
    }

    // Inserts a word into the trie
    public void Insert(string word) {
        WBTrieNode node = Root;
        foreach (char c in word) {
            if (!node.Children.ContainsKey(c)) {
                node.Children[c] = new WBTrieNode(); // Create node if it doesn't exist
            }
            node = node.Children[c]; // Move to the next node
        }
        node.IsWord = true; // Mark the end of the word
    }

    // Searches for substring s[i..j] in the trie, returns true if it is a valid word
    public bool Search(string s, int i, int j) {
        WBTrieNode node = Root;
        for (int idx = i; idx <= j; idx++) {
            if (!node.Children.ContainsKey(s[idx])) {
                return false; // Character path not found
            }
            node = node.Children[s[idx]]; // Continue traversal
        }
        return node.IsWord; // Return true only if the path ends at a valid word
    }
}

// Main solution class
public partial class Solution {
    public bool DPTWordBreak(string s, IList<string> wordDict) {
        WBTrie trie = new WBTrie();
        
        // Insert all words into the trie
        foreach (string word in wordDict) {
            trie.Insert(word);
        }

        int n = s.Length;
        bool[] dp = new bool[n + 1];
        dp[n] = true; // Base case: empty suffix can be segmented

        int maxLen = 0;
        // Find the length of the longest word (to limit inner loop)
        foreach (string word in wordDict) {
            maxLen = Math.Max(maxLen, word.Length);
        }

        // Fill dp table from right to left
        for (int i = n - 1; i >= 0; i--) {
            // Try all possible word endings starting at position i, bounded by max word length
            for (int j = i; j < Math.Min(n, i + maxLen); j++) {
                // If s[i..j] is a valid word and the suffix s[j+1..] can be segmented
                if (trie.Search(s, i, j)) {
                    dp[i] = dp[j + 1];
                    if (dp[i]) break; // No need to try longer matches if this works
                }
            }
        }

        return dp[0]; // True if entire string can be segmented
    }
}

/*
Initial Setup:

n = 13 (length of "applepenapple")
maxLen = 5 (longest word in wordDict)
dp[13] = true (base case)
All other dp[k] = false

i = 12
  j = 12 → s[12..12] = "e" → not in trie → dp[12] remains false

i = 11
  j = 11 → s[11..11] = "l" → not in trie
  j = 12 → s[11..12] = "le" → not in trie

i = 10
  j = 10 → s[10..10] = "p" → not in trie
  j = 11 → s[10..11] = "pl" → not in trie
  j = 12 → s[10..12] = "ple" → not in trie

i = 9
  j = 9 → s[9..9] = "p" → not in trie
  j = 10 → s[9..10] = "pp" → not in trie
  j = 11 → s[9..11] = "ppl" → not in trie
  j = 12 → s[9..12] = "pple" → not in trie

i = 8
  j = 8 → s[8..8] = "a" → not in trie
  j = 9 → s[8..9] = "ap" → not in trie
  j = 10 → s[8..10] = "app" → not in trie
  j = 11 → s[8..11] = "appl" → not in trie
  j = 12 → s[8..12] = "apple" → ✅ in trie → dp[13] = true → dp[8] = true ✔

i = 7
  j = 7 → s[7..7] = "n" → not in trie
  j = 8 → s[7..8] = "na" → not in trie
  j = 9 → s[7..9] = "nap" → not in trie
  j = 10 → s[7..10] = "napp" → not in trie
  j = 11 → s[7..11] = "nappl" → not in trie

i = 6
  j = 6 → s[6..6] = "e" → not in trie
  j = 7 → s[6..7] = "en" → not in trie
  j = 8 → s[6..8] = "ena" → not in trie
  j = 9 → s[6..9] = "enap" → not in trie
  j = 10 → s[6..10] = "enapp" → not in trie

i = 5
  j = 5 → s[5..5] = "p" → not in trie
  j = 6 → s[5..6] = "pe" → not in trie
  j = 7 → s[5..7] = "pen" → ✅ in trie → dp[8] = true → dp[5] = true ✔

i = 4
  j = 4 → s[4..4] = "e" → not in trie
  j = 5 → s[4..5] = "ep" → not in trie
  j = 6 → s[4..6] = "epe" → not in trie
  j = 7 → s[4..7] = "epen" → not in trie
  j = 8 → s[4..8] = "epena" → not in trie

i = 3
  j = 3 → s[3..3] = "l" → not in trie
  j = 4 → s[3..4] = "le" → not in trie
  j = 5 → s[3..5] = "lep" → not in trie
  j = 6 → s[3..6] = "lepe" → not in trie
  j = 7 → s[3..7] = "lepen" → not in trie

i = 2
  j = 2 → s[2..2] = "p" → not in trie
  j = 3 → s[2..3] = "pl" → not in trie
  j = 4 → s[2..4] = "ple" → not in trie
  j = 5 → s[2..5] = "plep" → not in trie
  j = 6 → s[2..6] = "plepe" → not in trie

i = 1
  j = 1 → s[1..1] = "p" → not in trie
  j = 2 → s[1..2] = "pp" → not in trie
  j = 3 → s[1..3] = "ppl" → not in trie
  j = 4 → s[1..4] = "pple" → not in trie
  j = 5 → s[1..5] = "pplep" → not in trie

i = 0
  j = 0 → s[0..0] = "a" → not in trie
  j = 1 → s[0..1] = "ap" → not in trie
  j = 2 → s[0..2] = "app" → not in trie
  j = 3 → s[0..3] = "appl" → not in trie
  j = 4 → s[0..4] = "apple" → ✅ in trie → dp[5] = true → dp[0] = true ✔

Final dp array:

Index:   0  1  2  3  4  5  6  7  8 ... 13
dp[] = [ T, F, F, F, F, T, F, F, T ... T ]
return dp[0] = true
*/


/*
Word Break

Given a string s and a dictionary of strings wordDict, return true if s 
can be segmented into a space-separated sequence of dictionary words.

You are allowed to reuse words in the dictionary an unlimited number of 
times. You may assume all dictionary words are unique.

Example 1:
Input: s = "neetcode", wordDict = ["neet","code"]
Output: true
Explanation: Return true because "neetcode" can be split into "neet" 
and "code".

Example 2:
Input: s = "applepenapple", wordDict = ["apple","pen","ape"]
Output: true
Explanation: Return true because "applepenapple" can be split into 
"apple", "pen" and "apple". Notice that we can reuse words and also 
not use all the words.

Example 3:
Input: s = "catsincars", wordDict = ["cats","cat","sin","in","car"]
Output: false

Constraints:
1 <= s.length <= 200
1 <= wordDict.length <= 100
1 <= wordDict[i].length <= 20
s and wordDict[i] consist of only lowercase English letters.
*/