
public class TrieNodeTHS {
    public Dictionary<char, TrieNodeTHS> Children = new Dictionary<char, TrieNodeTHS>();
    public bool IsWord = false;

    public void AddWord(string word) {
        TrieNodeTHS cur = this;
        foreach (char c in word) {
            if (!cur.Children.ContainsKey(c)) {
                cur.Children[c] = new TrieNodeTHS();
            }
            cur = cur.Children[c];
        }
        cur.IsWord = true;
    }
}

public partial class Solution {
    private HashSet<string> WSIIBTHres = new HashSet<string>();
    private bool[,] WSIIBTHvisit;
    public List<string> FindWordsTHS(char[][] board, string[] words) {
        TrieNodeTHS root = new TrieNodeTHS();
        foreach (string word in words) {
            root.AddWord(word);
        }

        int ROWS = board.Length, COLS = board[0].Length;
        WSIIBTHvisit = new bool[ROWS, COLS];

        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                WSIIDfs(board, r, c, root, "");
            }
        }
        return new List<string>(WSIIBTHres);
    }

    private void WSIIDfs(char[][] board, int r, int c, TrieNodeTHS node, string word) {
        int ROWS = board.Length, COLS = board[0].Length;
        
        // Stop the recursion if: The cell is out of bounds. The cell is already 
        // visited. The current character doesn't exist in the current Trie node's 
        // children.
        if (r < 0 || c < 0 || r >= ROWS || 
            c >= COLS || WSIIBTHvisit[r, c] || 
            !node.Children.ContainsKey(board[r][c])) {
            // Use backtracking to revert visited cells after exploring each path.
            return;
        }

        WSIIBTHvisit[r, c] = true;
        node = node.Children[board[r][c]];
        word += board[r][c];
        if (node.IsWord) {
            WSIIBTHres.Add(word);
        }

        WSIIDfs(board, r + 1, c, node, word);
        WSIIDfs(board, r - 1, c, node, word);
        WSIIDfs(board, r, c + 1, node, word);
        WSIIDfs(board, r, c - 1, node, word);

        WSIIBTHvisit[r, c] = false;
    }
}

/*
The backtracking occurs after all recursive calls to Dfs are made. 
Specifically, it's this line in the Dfs method:
visit[r, c] = false;

Why is this Backtracking?
Backtracking ensures that the visit array is reset after exploring all paths 
starting from a given cell (r, c).
When a cell is marked as visited (visit[r, c] = true), it's temporarily 
"blocked" to prevent revisiting it in the same search path. Once all recursive 
calls for that cell are complete, backtracking "unblocks" it by setting 
visit[r, c] = false.
This allows the algorithm to reuse the same cell in subsequent paths that may 
start from other board positions.

Consider this scenario:
The board:
[  ['o', 'a', 'b'],
   ['o', 't', 'c'],
   ['e', 'a', 't']
]
Words to search: ["oat", "eat"].
Without backtracking:
Starting at board[0][0] ('o'), the algorithm might explore and find oat.
If the cell board[0][0] remains marked as visited, it won't be available when 
searching for the word eat.

With backtracking:
After the first DFS completes, the algorithm resets board[0][0]'s visited status. 
Now, when starting a new DFS from board[2][0] ('e'), the cell board[0][0] can be 
reused if the search path needs it.

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