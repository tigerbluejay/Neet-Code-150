
class TrieNodeT {
    public TrieNodeT[] children = new TrieNodeT[26];
    public int idx = -1;
    public int refs = 0;

    public void AddWordT(string word, int i) {
        TrieNodeT cur = this;
        cur.refs++;
        foreach (char c in word) {
            int index = c - 'a';
            if (cur.children[index] == null) {
                cur.children[index] = new TrieNodeT();
            }
            cur = cur.children[index];
            cur.refs++;
        }
        cur.idx = i;
    }
}

public partial class Solution {
    private List<string> WSIIBTres = new List<string>();

    public List<string> FindWordsT(char[][] board, string[] words) {
        TrieNodeT root = new TrieNodeT();
        for (int i = 0; i < words.Length; i++) {
            root.AddWordT(words[i], i);
        }

        for (int r = 0; r < board.Length; r++) {
            for (int c = 0; c < board[0].Length; c++) {
                WSIIBTDfs(board, root, r, c, words);
            }
        }

        return WSIIBTres;
    }

    private void WSIIBTDfs(char[][] board, TrieNodeT node, int r, int c, string[] words) {
        if (r < 0 || c < 0 || r >= board.Length || 
            c >= board[0].Length || board[r][c] == '*' || 
            node.children[board[r][c] - 'a'] == null) {
            return;
        }

        char temp = board[r][c];
        board[r][c] = '*';
        TrieNodeT prev = node;
        node = node.children[temp - 'a'];
        if (node.idx != -1) {
            WSIIBTres.Add(words[node.idx]);
            node.idx = -1;
            node.refs--;
            if (node.refs == 0) {
                node = null;
                prev.children[temp - 'a'] = null;
                board[r][c] = temp;
                return;
            }
        }

        WSIIBTDfs(board, node, r + 1, c, words);
        WSIIBTDfs(board, node, r - 1, c, words);
        WSIIBTDfs(board, node, r, c + 1, words);
        WSIIBTDfs(board, node, r, c - 1, words);

        board[r][c] = temp;
    }
}

/*
In this algorithm, the idx and refs properties in the TrieNodeT class play 
crucial roles in optimizing the Trie data structure for both storing words 
and managing their usage during the Depth First Search (DFS) traversal. 
Here's an explanation of their specific roles:

1. Role of idx
What is it?
idx is an integer that stores the index of the word in the input words array, 
if a complete word ends at the current Trie node.
If no word ends at this node, idx is set to -1 (its default value).

Why is it useful?
It allows efficient mapping from the Trie back to the original words array 
without needing to explicitly store the full word in each Trie node.
When a valid word is found during DFS (node.idx != -1), the algorithm uses 
words[node.idx] to quickly retrieve the word and add it to the result list res.

How is it used?
During the insertion phase (AddWordT), the idx is assigned to the last node in 
the Trie corresponding to the end of a word.
During DFS, whenever a node with idx != -1 is reached, the corresponding word 
is added to res:
if (node.idx != -1) {
    res.Add(words[node.idx]);
    node.idx = -1; // Mark the word as found.
}

Why is idx set to -1 after finding a word?
This ensures that the same word is not added to the results multiple times, even if 
the DFS encounters it again through a different path.

2. Role of refs
What is it?
refs is an integer that tracks how many words pass through or end at the current 
Trie node (including its children).
When a word is added to the Trie, every node in its path has its refs incremented.

Why is it useful?
It enables efficient pruning of the Trie during the DFS. Specifically:
If a word is found and the corresponding node no longer has any remaining words 
passing through it (node.refs == 0), the node and its subtree can be safely 
removed from the Trie to save memory and reduce unnecessary traversal.
This optimization is particularly important for reducing the search space when 
there are overlapping prefixes between words.

How is it used?
During insertion (AddWordT), refs is incremented for every node visited while 
adding a word.
cur.refs++;

During DFS, refs is decremented for nodes when a word is found:
node.refs--;

if (node.refs == 0) {
    node = null;
    prev.children[temp - 'a'] = null;
}
If node.refs becomes 0, the node is removed from its parent 
(prev.children[temp - 'a'] = null) since it is no longer needed.

How does this help?
By removing unused nodes, the Trie is dynamically pruned during the search, 
preventing unnecessary checks for nodes that no longer contribute to valid words.

How idx and refs Work Together
idx identifies when a valid word is found.
When a word is found (node.idx != -1), it is added to the result list, 
and the idx is set to -1 to prevent duplicates.
refs ensures the Trie remains efficient by pruning unnecessary nodes.

After marking a word as found, the algorithm decrements refs for the nodes in the 
word's path.
If refs reaches 0, the node is removed entirely, reducing the size of the Trie 
and making subsequent searches faster.

Example Walkthrough
Input:
Board:
Edit
[  ['o', 'a'],
   ['o', 't']
]
Words: ["oat", "oo"].
Step-by-Step Execution:
Trie Construction:

Insert "oat":
Trie:
  root -> 'o'(refs=1) -> 'a'(refs=1) -> 't'(idx=0, refs=1)
Insert "oo":
Trie:
  root -> 'o'(refs=2) -> 'a'(refs=1) -> 't'(idx=0, refs=1)
          \-> 'o'(idx=1, refs=1)
*/


/*
Word Search II

Given a 2-D grid of characters board and a list of strings words, 
return all words that are present in the grid.

For a word to be present it must be possible to form the word with a 
path in the board with horizontally or vertically neighboring cells. 
The same cell may not be used more than once in a word.

Example 1:
Input:
board = [
  ["a","b","c","d"],
  ["s","a","a","t"],
  ["a","c","k","e"],
  ["a","c","d","n"]
],
words = ["bat","cat","back","backend","stack"]
Output: ["cat","back","backend"]

Example 2:
Input:
board = [
  ["x","o"],
  ["x","o"]
],
words = ["xoxo"]
Output: []

Constraints:
1 <= board.length, board[i].length <= 10
board[i] consists only of lowercase English letter.
1 <= words.length <= 100
1 <= words[i].length <= 10
words[i] consists only of lowercase English letters.
All strings within words are distinct.
*/