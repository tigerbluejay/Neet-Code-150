/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */


public partial class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null || q == null)
            return p == q;
        
        // terms joined by && are called from left to right
        return
            p.val == q.val &&
            IsSameTree(p.left, q.left) &&
            IsSameTree(p.right, q.right);
    }
}

// Input: p = [1,2,3], q = [1,2,3]
// function returns false if at any single point the nodes are not the same
// function returns true at every single point if the nodes 
// a) have the same value
// b) have the same left subtree
// c) have the same right subtree

// point of entry IsSameTree: p = 1, q = 1
    // 1st recursive call: p=2, q=2 on IsSameTree(p.left, q.left)
        // 2nd recursive call: p=null, q=null
        // 3rd recursive call: p=null, q=null
    // return to 1st recursive call: p=3, q=3 on IsSameTree(p.right, q.right)
        // 4th recursive call: p=null, q=null
        // 5th recursive call: p=null, q=null
// return to point of entry


/*
Same Binary Tree

Given the roots of two binary trees p and q, 
return true if the trees are equivalent, otherwise return false.

Two binary trees are considered equivalent if they share the exact same 
structure and the nodes have the same values.

Example 1:
Input: p = [1,2,3], q = [1,2,3]
Output: true

Example 2:
Input: p = [4,7], q = [4,null,7]
Output: false

Example 3:

*/