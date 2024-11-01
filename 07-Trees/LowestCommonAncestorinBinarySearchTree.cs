/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

public partial class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || p == null || q == null) {
            return null;
        }
        // we take the highest between p and q, and if it is less than root.val
        // we look on the left subtree of root
        if (Math.Max(p.val, q.val) < root.val) { 
            return LowestCommonAncestor(root.left, p, q);
        // if the lesser value between p and q is greater than root.val
        // we look on the right subtree of root.
        } else if (Math.Min(p.val, q.val) > root.val) {
            return LowestCommonAncestor(root.right, p, q);
        } else {
            return root;
        }
    }
}
// Example
// Input: root = [5,3,8,1,4,7,9,null,2], p = 3, q = 8
//            5
//        3       8
//     1   4     7   9
//    n 2
// if p=3 and q=8, we take the max (8) is it less than 5, no
// we take the min (3) is it more than 5, no
// this effectively means we are at the first time p and q split
// so we return root
// because this will be by definition the LCA


// if p=3 and q=4, we take the max (4) is it less than 5, yes
// so we look in the left subtree (because the nodes are less than the val, they will be by defintion both to the left of root.val)
// if p=3 and q=4, we take the max (4) is it less than 3, no
// we take the min (3), is it less than 3, no
// it is equal to 3, so we return 3... which is the LCA 
// (this is an edge case where a node CAN be its own LCA)


/*
Lowest Common Ancestor in Binary Search Tree

Given a binary search tree (BST) where all node values are unique, 
and two nodes from the tree p and q, return the lowest common ancestor 
(LCA) of the two nodes.

The lowest common ancestor between two nodes p and q is the lowest node in a 
tree T such that both p and q as descendants. The ancestor is allowed to be a 
descendant of itself.

Example 1:
Input: root = [5,3,8,1,4,7,9,null,2], p = 3, q = 8
Output: 5

Example 2:
Input: root = [5,3,8,1,4,7,9,null,2], p = 3, q = 4
Output: 3
Explanation: The LCA of nodes 3 and 4 is 3, 
since a node can be a descendant of itself.

Constraints:
2 <= The number of nodes in the tree <= 100.
-100 <= Node.val <= 100
p != q
p and q will both exist in the BST.
*/