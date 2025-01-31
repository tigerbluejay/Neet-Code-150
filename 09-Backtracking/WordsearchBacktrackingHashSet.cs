
public partial class Solution {
    private int WSHSROWS, WSHSCOLS;
    private HashSet<(int, int)> path = new HashSet<(int, int)>();

    public bool ExistHS(char[][] board, string word) {
        WSHSROWS = board.Length;
        WSHSCOLS = board[0].Length;

        for (int r = 0; r < WSHSROWS; r++) {
            for (int c = 0; c < WSHSCOLS; c++) {
                if (WSHSDFS(board, word, r, c, 0)) {
                    return true;
                }
            }
        }
        return false;
    }

    private bool WSHSDFS(char[][] board, string word, int r, int c, int i) {
        if (i == word.Length) {
            return true;
        }

        if (r < 0 || c < 0 || r >= WSHSROWS || c >= WSHSCOLS || 
            board[r][c] != word[i] || path.Contains((r, c))) {
            return false;
        }

        path.Add((r, c));
        bool res = WSHSDFS(board, word, r + 1, c, i + 1) || 
                   WSHSDFS(board, word, r - 1, c, i + 1) ||
                   WSHSDFS(board, word, r, c + 1, i + 1) || 
                   WSHSDFS(board, word, r, c - 1, i + 1);
        path.Remove((r, c));

        return res;
    }
}
/*
The DFS is called for each position on the board, and it tries all four 
directions (up, down, left, right) recursively. If the end of the word 
is reached (i == word.Length), it returns true. If a boundary or 
mismatch is hit, it returns false.

(0, 2) -> Start DFS for 'C' at board[0][2]
|
+-- (1, 2) -> Match 'A' below (r+1, c)
|   |
|   +-- (1, 3) -> Match 'T' to the right (r, c+1) -> Found!
|
+-- (other directions fail: out-of-bound or mismatch)

// Full tree (truncated once the logic becomes apparent)

(0,0): A  -> Fail (mismatch)
(0,1): B  -> Fail (mismatch)
(0,2): C  -> Match 'C'
   |
   +-- (1,2): A  -> Match 'A'
   |   |
   |   +-- (1,3): T  -> Match 'T' [FOUND]
   |   |
   |   +-- Backtrack (other directions fail)
   |
   +-- (other directions fail and backtrack)
(0,3): D  -> Fail (mismatch)

(1,0): S  -> Fail (mismatch)
(1,1): A  -> Fail (mismatch)
(1,2): A  -> Fail (wrong starting point for "CAT")
(1,3): T  -> Fail (wrong starting point for "CAT")

(2,0): A  -> Fail (mismatch)
(2,1): C  -> Match 'C'
   |
   +-- (3,1): Out of bounds -> Fail
   +-- (1,1): A  -> Match 'A'
   |   |
   |   +-- (1,2): T  -> Match 'T' [FOUND]
   |   |
   |   +-- Backtrack (other directions fail)
   |
   +-- (2,2): A  -> Fail (wrong path)
   +-- (2,0): A  -> Fail (backtrack to already-visited path)
(2,2): A  -> Fail (mismatch)
(2,3): E  -> Fail (mismatch)
*/

/*
Without explicitly "unmarking" the current cell (path.Remove((r, c))), 
the algorithm wouldn’t be able to revisit the same cell during a new 
branch of exploration. This process is what qualifies as true 
backtracking.
*/

/*
Start at (0,0): 'A' -> Fail (no match, no path.Add, no path.Remove)

Start at (0,1): 'B' -> Fail (no match, no path.Add, no path.Remove)

Start at (0,2): 'C' -> Match (path.Add((0,2)))
   |
   +-- Explore (1,2): 'A' -> Match (path.Add((1,2)))
   |   |
   |   +-- Explore (1,3): 'T' -> Match (path.Add((1,3)))
   |   |   |
   |   |   +-- End of word -> Success (path.Remove((1,3)))
   |   |       (1,3) unmarked as recursion ends successfully.
   |   |
   |   +-- Backtrack to (1,2): Other directions fail (path.Remove((1,2)))
   |       (1,2) unmarked as recursion backtracks to (0,2).
   |
   +-- Backtrack to (0,2): Other directions fail (path.Remove((0,2)))
       (0,2) unmarked as recursion backtracks to try other cells.

Start at (0,3): 'D' -> Fail (no match, no path.Add, no path.Remove)

Start at (1,0): 'S' -> Fail (no match, no path.Add, no path.Remove)

Start at (1,1): 'A' -> Fail (no match, no path.Add, no path.Remove)

Start at (1,2): 'A' -> Fail (already visited in a previous branch)

Start at (1,3): 'T' -> Fail (no match, no path.Add, no path.Remove)

Start at (2,0): 'A' -> Fail (no match, no path.Add, no path.Remove)

Start at (2,1): 'C' -> Match (path.Add((2,1)))
   |
   +-- Explore (1,1): 'A' -> Match (path.Add((1,1)))
   |   |
   |   +-- Explore (1,2): 'T' -> Fail (not part of the valid sequence)
   |   +-- Backtrack to (1,1): Other directions fail (path.Remove((1,1)))
   |       (1,1) unmarked as recursion backtracks to (2,1).
   |
   +-- Backtrack to (2,1): Other directions fail (path.Remove((2,1)))
       (2,1) unmarked as recursion backtracks to try other cells.

Start at (2,2): 'A' -> Fail (no match, no path.Add, no path.Remove)

Start at (2,3): 'E' -> Fail (no match, no path.Add, no path.Remove)
*/
// The path set prevents this by keeping track of visited cells during 
// a single DFS branch.
// The instructions explicitly state: The same cell may not be used 
// more than once in a word.

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