/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

public partial class Solution {
    private bool _result = true;

    public bool IsBalanced(TreeNode root) {
        Dfs(root);
        return _result; // is every node we visit from the bottom up balanced? If not, the whole tree is not balanced
    }

    private int Dfs(TreeNode root) {
        if(root == null) {
            return -1;
        }

        var leftDepth = Dfs(root.left);
        var rightDepth = Dfs(root.right);

        // _result is true if the node and its subtree is balanced
        // Math.Abs(rightDepth - leftDepth) <= 1 // will tell you if there is any unbalanced subtree
        // in other words if right depth and left depth differ by more than 1, the subtree is unbalanced.
        _result = _result && (Math.Abs(rightDepth - leftDepth) <= 1);

        return Math.Max(leftDepth, rightDepth) + 1; // returns the max height between each of the branches of the subtree + 1
    }
}

// Input: root = [1,2,3,null,null,4]
// first node 2, leftDepth = -1 (child is null), rightDepth = -1 (child is null)
// then node 4, leftDepth = -1 (child is null), rightDepth = -1 (child is null)
// then node 3, leftDepth = 0 (child is 4), rightDepth = -1 (child is null)
// then node 1, leftDepth = 0 (child is 2), rightDepth = 1 (child is 3, then 3's child is 4)
// difference between left and right at any node for its subtree is 1 or less, so the tree is balanced.

/*
Balanced Binary Tree

Given a binary tree, return true if it is height-balanced and false otherwise.

A height-balanced binary tree is defined as a binary tree in which the left and right 
subtrees of every node differ in height by no more than 1.

Example 1:
Input: root = [1,2,3,null,null,4]
Output: true

Example 2:
Input: root = [1,2,3,null,null,4,null,5]
Output: false

Example 3:
Input: root = []
Output: true

Constraints:
The number of nodes in the tree is in the range [0, 1000].
-1000 <= Node.val <= 1000
*/