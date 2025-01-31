
public partial class Solution {
    public List<string> FindWords(char[][] board, string[] words) {
        int ROWS = board.Length, COLS = board[0].Length;
        List<string> res = new List<string>();

        foreach (string word in words) {
            bool flag = false;
            for (int r = 0; r < ROWS && !flag; r++) {
                for (int c = 0; c < COLS; c++) {
                    if (board[r][c] != word[0]) continue;
                    if (Backtrack(board, r, c, word, 0)) {
                        res.Add(word);
                        flag = true;
                        break;
                    }
                }
            }
        }
        return res;
    }

    private bool Backtrack(char[][] board, int r, int c, string word, int i) {
        if (i == word.Length) return true;
        if (r < 0 || c < 0 || r >= board.Length || 
            c >= board[0].Length || board[r][c] != word[i])
            return false;

        board[r][c] = '*';
        bool ret = Backtrack(board, r + 1, c, word, i + 1) ||
                   Backtrack(board, r - 1, c, word, i + 1) ||
                   Backtrack(board, r, c + 1, word, i + 1) ||
                   Backtrack(board, r, c - 1, word, i + 1);
        board[r][c] = word[i];
        return ret;
    }
}

/*
Marking the board with an asterisk ('*') in the algorithm serves to temporarily
mark a cell as visited. This ensures that the same cell is not reused during the 
construction of the current word. The marking happens after visiting the cell in 
question but before exploring its neighbors.

Here's how it works step-by-step:

Why Mark the Board?
Avoid Revisiting the Same Cell:
Once you visit a cell (e.g., board[r][c]), it cannot be revisited for the current 
path. Without marking, the algorithm might loop back to the same cell, 
leading to incorrect results or infinite recursion.
Backtracking:
The marking is temporary. After the algorithm finishes exploring all paths 
from the current cell, it restores the original character to allow other 
potential words or paths to reuse the cell.
*/

/*
Recursive tree to find the word "cat"

Find "cat" starting from (anywhere in board):
├── Start at (0,2) [c] ✓
    ├── Move Down (1,2) [a] ✓
        ├── Move Down (2,2) [k] ×
        ├── Move Up (0,2) [*] ×
        ├── Move Right (1,3) [t] ✓
            ├── Move Down (2,3) [e] ×
            ├── Move Up (0,3) [d] ×
            ├── Move Right (1,4) [out of bounds] ×
            ├── Move Left (1,2) [*] ×
        ├── Backtrack from (1,3) [t]
        ├── Backtrack from (1,2) [a]
    ├── Move Up (-1,2) [out of bounds] ×
    ├── Move Right (0,3) [d] ×
    ├── Move Left (0,1) [b] ×
├── Start at (2,1) [c] ✓
    ├── Move Down (3,1) [c] ×
    ├── Move Up (1,1) [a] ✓
        ├── Move Down (2,1) [c] ×
        ├── Move Up (0,1) [b] ×
        ├── Move Right (1,2) [a] ×
        ├── Move Left (1,0) [s] ×
    ├── Backtrack from (1,1) [a]
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