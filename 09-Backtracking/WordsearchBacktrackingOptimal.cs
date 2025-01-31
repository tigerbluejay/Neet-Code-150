public partial class Solution {
    private int WSOROWS, WSOCOLS;

    public bool ExistOptimal(char[][] board, string word) {
        WSOROWS = board.Length;
        WSOCOLS = board[0].Length;

        for (int r = 0; r < WSOROWS; r++) {
            for (int c = 0; c < WSOCOLS; c++) {
                if (WSODfs(board, word, r, c, 0)) {
                    return true;
                }
            }
        }
        return false;
    }

    private bool WSODfs(char[][] board, string word, int r, int c, int i) {
        if (i == word.Length) {
            return true;
        }
        if (r < 0 || c < 0 || r >= WSOROWS || c >= WSOCOLS || 
        board[r][c] != word[i] || board[r][c] == '#') {
            return false;
        }

        board[r][c] = '#';
        bool res = WSODfs(board, word, r + 1, c, i + 1) ||
                   WSODfs(board, word, r - 1, c, i + 1) ||
                   WSODfs(board, word, r, c + 1, i + 1) ||
                   WSODfs(board, word, r, c - 1, i + 1);
        board[r][c] = word[i];
        return res;
    }
}

/*
This implementation differs significantly from the previous two in how
it tracks visited cells. Instead of using a HashSet or a visited matrix,
it temporarily modifies the board itself during the DFS traversal to 
mark cells as visited.

In this implementation, a visited cell is marked by overwriting its 
value in the board (e.g., changing the character to #) during the DFS 
call.

After the DFS completes, the cell's value is restored to its original 
character (board[r][c] = word[i]).

Remember the # placing and removing occurs in the context of a single DFS
branch call, when the algorihm calls root DFS the next time (to check all
possible paths starting from a new cell) the board at that point is completely
restored.

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