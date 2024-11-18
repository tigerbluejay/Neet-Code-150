/**
* Definition for a binary tree node is in InvertaBinaryTree.cs file.
*/

public partial class Solution {

    public int MaxPathSumDFSOptimal(TreeNode root) {
        int res = root.val;
        Dfs(root, ref res);
        return res;
    }

    private int Dfs(TreeNode root, ref int res) {
        if (root == null) {
            return 0;
        }

        int leftMax = Math.Max(Dfs(root.left, ref res), 0);
        int rightMax = Math.Max(Dfs(root.right, ref res), 0);

        res = Math.Max(res, root.val + leftMax + rightMax);
        return root.val + Math.Max(leftMax, rightMax);
    }
}

// Input: root = [-15,10,20,null,null,15,5,-5]
//              -15
//      10                  20
//   null null          15      5
// -5
// Output: 40
// Explanation: The path is 15 -> 20 -> 5 with a sum of 15 + 20 + 5 = 40.

/* Dfs(root, res) where res is the max between res, and the sum of root+left+right
call Dfs(-15,-15)                                           => will return  35 (compares -15, with the max between 10 and 35(20+15))
    call Dfs(10,-15) (leftMax)                  => returns 10
        call Dfs(null,-15)            
        call Dfs(null,-15)           
    call Dfs(20,10) (rightMax)                  => returns 20 (compares 20 with the max between 15 and 5, and returns the max)
        call Dfs(15,10) (leftMax)    => return 15           
            call Dfs(null,10)        
            call Dfs(null,10)        
        call Dfs(5,15) (rightMax)    => return 5
            call Dfs(null,15)
            call Dfs(null,15)



/*
Binary Tree Maximum Path Sum

Given the root of a non-empty binary tree, return the maximum path sum of any non-empty path.

A path in a binary tree is a sequence of nodes where each pair of adjacent nodes has an edge connecting them. 
A node can not appear in the sequence more than once. 
The path does not necessarily need to include the root.

The path sum of a path is the sum of the node's values in the path.

Example 1:
Input: root = [1,2,3]
Output: 6
Explanation: The path is 2 -> 1 -> 3 with a sum of 2 + 1 + 3 = 6.

Example 2:
Input: root = [-15,10,20,null,null,15,5,-5]
Output: 40
Explanation: The path is 15 -> 20 -> 5 with a sum of 15 + 20 + 5 = 40.

Constraints:
1 <= The number of nodes in the tree <= 1000.
-1000 <= Node.val <= 1000

*/