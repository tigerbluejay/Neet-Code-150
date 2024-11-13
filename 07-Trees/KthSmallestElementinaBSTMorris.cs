/**
* Definition for a binary tree node is in InvertaBinaryTree.cs file.
*/

public partial class Solution {
  public int KthSmallestMorris(TreeNode root, int k) {
    TreeNode curr = root;
    
    // while there is a node to process
    while (curr != null) {
        if (curr.left == null) {
            // Case 1: No left child
            k--;
            if (k == 0) return curr.val;
            curr = curr.right; // set curr.right to be the current node
        } else {
            // Case 2: Left child exists
            // Snippet's primary goal is to find the In-Order predecessor of the current node.
            TreeNode pred = curr.left;
            while (pred.right != null && pred.right != curr) {
                pred = pred.right; // find the rightmost node in the left subtree (which is not equal to null or current), 
                //which is the In-Order predecessor.
            }
            
            if (pred.right == null) {
                // Create a threaded link
                // Creates a temporary link to the In-Order successor.
                // (Connect the previous left subtree's right most node (the predecessor) with it's successor)
                pred.right = curr;
                curr = curr.left;
            } else {
                // After processing a node we:
                // Restore the original structure (remove the links created previously between predecessor and successor)
                // Restores the original tree structure after processing a node.
                pred.right = null;
                k--;
                if (k == 0) return curr.val;
                curr = curr.right;
            }
        }
    }
    return -1;
}
}

/*
Morris Traversal is a clever technique to perform In-Order traversal of a binary tree without 
using any additional space for a stack or recursion. It leverages the tree structure itself to 
create temporary links to the predecessor nodes.

Conceptual Understanding:

Identify the Successor: For each node, we find its In-Order successor.
Create a Threaded Link: We create a temporary link from the node to its successor.
Traverse the Threaded Link: We traverse the tree using these threaded links.
Restore the Original Structure: After processing a node, we restore the original tree 
structure by breaking the temporary link.
*/

/*
Kth Smallest Integer in BST

Given the root of a binary search tree, and an integer k, 
return the kth smallest value (1-indexed) in the tree.

A binary search tree satisfies the following constraints:

The left subtree of every node contains only nodes with keys less than the node's key.
The right subtree of every node contains only nodes with keys greater than the node's key.
Both the left and right subtrees are also binary search trees.

Example 1:
Input: root = [2,1,3], k = 1
Output: 1

Example 2:
Input: root = [4,3,5,2,null], k = 4
Output: 5

Constraints:
1 <= k <= The number of nodes in the tree <= 1000.
0 <= Node.val <= 1000

*/