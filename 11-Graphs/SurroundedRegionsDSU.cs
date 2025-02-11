/*
Union-Find (Disjoint Set Union - DSU) Explained
Union-Find, also known as Disjoint Set Union (DSU), is a data structure used to manage and merge disjoint 
(non-overlapping) sets. It is especially useful for problems involving connectivity, like determining if two 
elements belong to the same group or merging groups efficiently.

1. Core Concepts of Union-Find
Union-Find supports two main operations:
Find(x) → Determines the root/leader of the set containing x.
Union(x, y) → Merges the sets containing x and y.
Additionally, we often include: 3. Connected(x, y) → Returns true if x and y belong to the same set 
(i.e., they share the same root).
*/
public class SRDSU {
    private int[] Parent, Size;

    public SRDSU(int n) {
        Parent = new int[n + 1];
        Size = new int[n + 1];
        for (int i = 0; i <= n; i++) {
            Parent[i] = i;
            Size[i] = 1;
        }
    }

    public int SRFind(int node) {
        if (Parent[node] != node) {
            Parent[node] = SRFind(Parent[node]);
        }
        return Parent[node];
    }

    public bool SRUnion(int u, int v) {
        int pu = SRFind(u), pv = SRFind(v);
        if (pu == pv) return false;
        if (Size[pu] >= Size[pv]) {
            Size[pu] += Size[pv];
            Parent[pv] = pu;
        } else {
            Size[pv] += Size[pu];
            Parent[pu] = pv;
        }
        return true;
    }

    public bool SRConnected(int u, int v) {
        return SRFind(u) == SRFind(v);
    }
}

public partial class Solution {
    public void SRDSUSolve(char[][] board) {
        int ROWS = board.Length, COLS = board[0].Length;
        // This node represents all border 'O' cells.
        SRDSU SRdsu = new SRDSU(ROWS * COLS + 1);
        int[][] directions = new int[][] { 
            new int[] { 1, 0 }, new int[] { -1, 0 }, 
            new int[] { 0, 1 }, new int[] { 0, -1 } 
        };

        // First Pass: Union All Border 'O's with the Virtual Node
        // If the cell is not 'O', skip it.
        // If it’s a border 'O', connect it to the virtual node (SRROWS * SRCOLS).
        // Otherwise, connect it to any adjacent 'O', forming groups of connected 'O's.
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (board[r][c] != 'O') continue;
                if (r == 0 || c == 0 || 
                    r == ROWS - 1 || c == COLS - 1) {
                    SRdsu.SRUnion(ROWS * COLS, r * COLS + c);
                } else {
                    foreach (var dir in directions) {
                        int nr = r + dir[0], nc = c + dir[1];
                        if (board[nr][nc] == 'O') {
                            SRdsu.SRUnion(r * COLS + c, nr * COLS + nc);
                        }
                    }
                }
            }
        }
        // Second Pass: Change All Non-Border 'O's to 'X'
        // If an 'O' is NOT connected to the virtual node, it means it is completely surrounded.
        // These get flipped to 'X'.
        for (int r = 0; r < ROWS; r++) {
            for (int c = 0; c < COLS; c++) {
                if (!SRdsu.SRConnected(ROWS * COLS, r * COLS + c)) {
                    board[r][c] = 'X';
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