public partial class Solution {
    private int SRDFSROWS, SRDFSCOLS;

    public void SRDFSSolve(char[][] board) {
        SRDFSROWS = board.Length;
        SRDFSCOLS = board[0].Length;

        // loop through column 0 border all rows (left wall)
        // loop through rightmost column all rows (right wall)
        for (int r = 0; r < SRDFSROWS; r++) {
            if (board[r][0] == 'O') {
                SRDFSCapture(board, r, 0);
            }
            if (board[r][SRDFSCOLS - 1] == 'O') {
                SRDFSCapture(board, r, SRDFSCOLS - 1);
            }
        }
  
        // loop through row 0 all columns (top wall)
        // loop through bottommost row all columns (bottom wall)
        for (int c = 0; c < SRDFSCOLS; c++) {
            if (board[0][c] == 'O') {
                SRDFSCapture(board, 0, c);
            }
            if (board[SRDFSROWS - 1][c] == 'O') {
                SRDFSCapture(board, SRDFSROWS - 1, c);
            }
        }

        // final step, turn Os into Xs (those that were not turned into Ts)
        // and turn Ts back to Os
        for (int r = 0; r < SRDFSROWS; r++) {
            for (int c = 0; c < SRDFSCOLS; c++) {
                if (board[r][c] == 'O') {
                    board[r][c] = 'X';
                } else if (board[r][c] == 'T') {
                    board[r][c] = 'O';
                }
            }
        }
    }

    private void SRDFSCapture(char[][] board, int r, int c) {
        if (r < 0 || c < 0 || r == SRDFSROWS || 
            c == SRDFSCOLS || board[r][c] != 'O') {
            return;
        }
        // if it is within bounds (first four checks)
        // and if it is a an O cell at the border turn it into T
        board[r][c] = 'T'; // and recursively search neighboring cells
        SRDFSCapture(board, r + 1, c);
        SRDFSCapture(board, r - 1, c);
        SRDFSCapture(board, r, c + 1);
        SRDFSCapture(board, r, c - 1);
    }
}
/*
Essentially you are visiting all cells at the border of the graph and those that have an O we mark
with a T (for temporary - since we'll revert them to Os at the end)
Then we flip the whole remaining grid of Os to Xs, since those Os will by definition be enclosed in X
if they weren't market with a T.
*/


/*
Surrounded Regions

You are given a 2-D matrix board containing 'X' and 'O' characters.

If a continous, four-directionally connected group of 'O's is surrounded by 'X's, it is considered to be surrounded.

Change all surrounded regions of 'O's to 'X's and do so in-place by modifying the input board.

Example 1:
Input: board = [
  ["X","X","X","X"],
  ["X","O","O","X"],
  ["X","O","O","X"],
  ["X","X","X","O"]
]

Output: [
  ["X","X","X","X"],
  ["X","X","X","X"],
  ["X","X","X","X"],
  ["X","X","X","O"]
]

Explanation: Note that regions that are on the border are not considered surrounded regions.

Constraints:
1 <= board.length, board[i].length <= 200
board[i][j] is 'X' or 'O'.
*/