public partial class Solution {
    private int WSVAROWS, WSVACOLS;
    private bool[,] WSVAvisited;

    public bool ExistVA(char[][] board, string word) {
        WSVAROWS = board.Length;
        WSVACOLS = board[0].Length;
        WSVAvisited = new bool[WSVAROWS, WSVACOLS];

        for (int r = 0; r < WSVAROWS; r++) {
            for (int c = 0; c < WSVACOLS; c++) {
                if (WSVADFS(board, word, r, c, 0)) {
                    return true;
                }
            }
        }
        return false;
    }

    private bool WSVADFS(char[][] board, string word, int r, int c, int i) {
        if (i == word.Length) {
            return true;
        }

        if (r < 0 || c < 0 || r >= WSVAROWS || c >= WSVACOLS || 
            board[r][c] != word[i] || WSVAvisited[r, c]) {
            return false;
        }

        WSVAvisited[r, c] = true;
        bool res = WSVADFS(board, word, r + 1, c, i + 1) || 
                   WSVADFS(board, word, r - 1, c, i + 1) ||
                   WSVADFS(board, word, r, c + 1, i + 1) || 
                   WSVADFS(board, word, r, c - 1, i + 1);
        WSVAvisited[r, c] = false;

        return res;
    }
}
/*
When to Choose Which Algorithm?
Use HashSet:
If you're working with a graph or non-grid structure.
If the board dimensions are unknown or dynamic.

Use bool[,] visited: (this algorithm)
For grid-based problems like this one, as it's faster, simpler, 
and more efficient.
*/

/*
Word Search

Given a 2-D grid of characters board and a string word, return true if 
the word is present in the grid, otherwise return false.

For the word to be present it must be possible to form it with a path 
in the board with horizontally or vertically neighboring cells. The same 
cell may not be used more than once in a word.

Example 1:
Input: 
board = [
  ["A","B","C","D"],
  ["S","A","A","T"],
  ["A","C","A","E"]
],
word = "CAT"
Output: true

Example 2:
Input: 
board = [
  ["A","B","C","D"],
  ["S","A","A","T"],
  ["A","C","A","E"]
],
word = "BAT"
Output: false

Constraints:
1 <= board.length, board[i].length <= 5
1 <= word.length <= 10
board and word consists of only lowercase and uppercase English letters.
*/