public partial class Solution {
    private int SRBFSROWS, SRBFSCOLS;
    private int[][] SRBFSdirections = new int[][] { 
        new int[] { 1, 0 }, new int[] { -1, 0 }, 
        new int[] { 0, 1 }, new int[] { 0, -1 } 
    };

    public void SRBFSSolve(char[][] board) {
        SRBFSROWS = board.Length;
        SRBFSCOLS = board[0].Length;

        SRBFSCapture(board);

        // final step: flip Os to Xs and Ts (on the border regions and adjacent) to Os
        for (int r = 0; r < SRBFSROWS; r++) {
            for (int c = 0; c < SRBFSCOLS; c++) {
                if (board[r][c] == 'O') {
                    board[r][c] = 'X';
                } else if (board[r][c] == 'T') {
                    board[r][c] = 'O';
                }
            }
        }
    }

    private void SRBFSCapture(char[][] board) {
        Queue<int[]> q = new Queue<int[]>();
        for (int r = 0; r < SRBFSROWS; r++) {
            for (int c = 0; c < SRBFSCOLS; c++) {
                if (r == 0 || r == SRBFSROWS - 1 || 
                    c == 0 || c == SRBFSCOLS - 1 && 
                    board[r][c] == 'O') {
                    q.Enqueue(new int[] { r, c });
                }
            }
        }
        while (q.Count > 0) {
            int[] cell = q.Dequeue();
            int r = cell[0], c = cell[1];
            if (board[r][c] == 'O') {
                board[r][c] = 'T';
                foreach (var direction in SRBFSdirections) {
                    int nr = r + direction[0];
                    int nc = c + direction[1];
                    if (nr >= 0 && nr < SRBFSROWS && 
                        nc >= 0 && nc < SRBFSCOLS) {
                        q.Enqueue(new int[] { nr, nc });
                    }
                }
            }
        }
    }
}

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