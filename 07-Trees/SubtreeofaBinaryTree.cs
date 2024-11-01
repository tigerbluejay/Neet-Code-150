/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

public partial class Solution {
    
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if (subRoot == null) {
            return true;
        }
        if (root == null) {
            return false;
        }

        // will return true if both trees are null
        // and will return true if comparing child elements (and their children)
        // results finally in both compared trees being null
        // if they are not the same at every point, it will return false
        if (SameTree(root, subRoot)) {
            return true;
        }
        // and the algorithm will check again but this time comparing
        // the roots left or the roots right child to the subtree
        return IsSubtree(root.left, subRoot) || 
               IsSubtree(root.right, subRoot);
    }

    public bool SameTree(TreeNode root, TreeNode subRoot) {
        if (root == null && subRoot == null) {
            return true;
        }
        if (root != null && subRoot != null && root.val == subRoot.val) {
            return SameTree(root.left, subRoot.left) && 
                   SameTree(root.right, subRoot.right);
        }
        return false;
    }
}


/*
Subtree of a Binary Tree

Given the roots of two binary trees root and subRoot, 
return true if there is a subtree of root with the same structure 
and node values of subRoot and false otherwise.

A subtree of a binary tree tree is a tree that consists of a node 
in tree and all of this node's descendants. The tree tree could also 
be considered as a subtree of itself.

Example 1:
Input: root = [1,2,3,4,5], subRoot = [2,4,5]
Output: true

Example 2:
Input: root = [1,2,3,4,5,null,null,6], subRoot = [2,4,5]
Output: false

Constraints:
0 <= The number of nodes in both trees <= 100.
-100 <= root.val, subRoot.val <= 100

*/