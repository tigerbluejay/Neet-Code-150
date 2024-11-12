/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */
 
public partial class Solution {
    static bool LeftCheck(int val, int limit) {
        return val < limit; 
    }

    static bool RightCheck(int val, int limit) {
        return val > limit; 
    }

    public bool IsValidBST(TreeNode root) {
        if (root == null) {
            return true;
        }

        if (!IsValid(root.left, root.val, LeftCheck) || 
            !IsValid(root.right, root.val, RightCheck)) {
            return false;
        }

        return IsValidBST(root.left) && IsValidBST(root.right);
    }

    public bool IsValid(TreeNode root, int limit, Func<int, int, bool> check) {
        if (root == null) {
            return true;
        }
        if (!check(root.val, limit)) {
            return false;
        }
        return IsValid(root.left, limit, check) && 
               IsValid(root.right, limit, check);
    }
}


/*
Valid Binary Search Tree

Given the root of a binary tree, return true if it is a valid binary search tree, otherwise return false.

A valid binary search tree satisfies the following constraints:

The left subtree of every node contains only nodes with keys less than the node's key.
The right subtree of every node contains only nodes with keys greater than the node's key.
Both the left and right subtrees are also binary search trees.

Example 1:
Input: root = [2,1,3]
Output: true

Example 2:
Input: root = [1,2,3]
Output: false
Explanation: The root node's value is 1 but its left child's value is 2 which is greater than 1.

Constraints:
1 <= The number of nodes in the tree <= 1000.
-1000 <= Node.val <= 1000
*/