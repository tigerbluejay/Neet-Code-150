/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

public partial class Solution {
    int pre_idx = 0;
    Dictionary<int, int> indices = new Dictionary<int, int>();

    public TreeNode BuildTreeHashMap(int[] preorder, int[] inorder) {
        // 1. Create a dictionary to map each value in the inorder array to its index.
        //    This allows for efficient lookup of node positions in the inorder traversal.
        for (int i = 0; i < inorder.Length; i++) {
            indices[inorder[i]] = i;
        }

        // 2. Initiate the recursive DFS traversal to build the tree.
        return Dfs(preorder, 0, inorder.Length - 1);
    }

    private TreeNode Dfs(int[] preorder, int left, int right) {
        // 1. Base case: If the left boundary exceeds the right boundary, return null.
        if (left > right) return null;

        // 2. Create a new node with the current value from the preorder traversal.
        //    Increment the preorder index to point to the next value.
        int rootVal = preorder[pre_idx++];
        TreeNode root = new TreeNode(rootVal);

        // 3. Find the index of the root value in the inorder traversal.
        //    This index divides the inorder traversal into left and right subtrees.
        int mid = indices[rootVal];

        // 4. Recursively build the left subtree using the left part of the preorder and inorder arrays.
        root.left = Dfs(preorder, left, mid - 1);

        // 5. Recursively build the right subtree using the right part of the preorder and inorder arrays.
        root.right = Dfs(preorder, mid + 1, right);

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