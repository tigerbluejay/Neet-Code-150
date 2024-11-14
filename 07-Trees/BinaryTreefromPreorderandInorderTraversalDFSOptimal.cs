/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */


public partial class Solution {
    int preIdx = 0;
    int inIdx = 0;

    public TreeNode BuildTreeDFSOptimal(int[] preorder, int[] inorder) {
        // 1. Initiate the recursive DFS traversal to build the tree.
        return Dfs(preorder, inorder, int.MaxValue);
    }

    private TreeNode Dfs(int[] preorder, int[] inorder, int limit) {
        // 1. Base case: If the preorder index has reached the end, return null.
        if (preIdx >= preorder.Length) return null;

        // 2. Base case: If the current inorder value matches the limit, it means
        //    we've reached the end of the current subtree. Increment the inorder index
        //    and return null.
        if (inorder[inIdx] == limit) {
            inIdx++;
            return null;
        }

        // 3. Create a new node with the current value from the preorder traversal.
        //    Increment the preorder index to point to the next value.
        TreeNode root = new TreeNode(preorder[preIdx++]);

        // 4. Recursively build the left subtree using the current root value as the limit.
        root.left = Dfs(preorder, inorder, root.val);

        // 5. Recursively build the right subtree using the original limit.
        root.right = Dfs(preorder, inorder, limit);

        return root;
    }
}

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