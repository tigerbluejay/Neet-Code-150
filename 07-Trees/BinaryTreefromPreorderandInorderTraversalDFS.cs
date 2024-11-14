/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

 public partial class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if (preorder.Length == 0 || inorder.Length == 0) {
            return null;
        }

        // 1. Create a new root node with the first value from the preorder traversal.
        TreeNode root = new TreeNode(preorder[0]);
        
        // 2. Find the index of the root in the inorder traversal.
        //    This index divides the inorder traversal into left and right subtrees.
        int mid = Array.IndexOf(inorder, preorder[0]);
        
        // 3. Recursively build the left subtree using:
        //    - The slice of the preorder array from 1 to mid.
        //    - The slice of the inorder array from 0 to mid.
        root.left = BuildTree(preorder.Skip(1).Take(mid).ToArray(), inorder.Take(mid).ToArray());
        
        // 4. Recursively build the right subtree using:
        //    - The slice of the preorder array from mid + 1 to the end.
        //    - The slice of the inorder array from mid + 1 to the end.
        root.right = BuildTree(preorder.Skip(mid + 1).ToArray(), inorder.Skip(mid + 1).ToArray());
        return root;
    }
}

// Input: preorder = [1,2,3,4], inorder = [2,1,3,4]

// first call: root = 1, mid = 1, root.left([2],[2])
        // root = 2, mid = 0 => left is null, right is null
// first call:                  , root.right([3,4], [3,4])        
        // root = 3, mid = 0 => left is null, root.right([4],[4])
                                            // root = 4, mid = 0 => left is null, right is null
/*
Binary Tree from Preorder and Inorder Traversal

You are given two integer arrays preorder and inorder.

preorder is the preorder traversal of a binary tree
inorder is the inorder traversal of the same tree

Both arrays are of the same size and consist of unique values.
Rebuild the binary tree from the preorder and inorder traversals and return its root.

Example 1:
Input: preorder = [1,2,3,4], inorder = [2,1,3,4]
Output: [1,2,3,null,null,null,4]

Example 2:
Input: preorder = [1], inorder = [1]
Output: [1]

Constraints:
1 <= inorder.length <= 1000.
inorder.length == preorder.length
-1000 <= preorder[i], inorder[i] <= 1000
*/