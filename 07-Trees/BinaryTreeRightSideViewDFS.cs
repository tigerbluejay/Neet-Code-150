/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

public partial class Solution {
    List<int> BTRSVres = new List<int>();
    
    public List<int> RightSideView(TreeNode root) {
        BTRSVdfs(root, 0);
        return BTRSVres;
    }
    
    private void BTRSVdfs(TreeNode node, int depth) {
        if (node == null) {
            return;
        }
        
        if (BTRSVres.Count == depth) {
            BTRSVres.Add(node.val);
        }
        
        BTRSVdfs(node.right, depth + 1);
        BTRSVdfs(node.left, depth + 1);
    }
}

// Input: root = [1,2,3]
// BTRSVres.Count (0) == depth (0), add(1)
   // BTRSVres.Count (1) == depth (1), add(3)
       // is null so return
       // is null so return
   // BTRSVres.Count (2) == depth (1), don't add 2
/*
Binary Tree Right Side View

You are given the root of a binary tree. 
Return only the values of the nodes that are visible from the right side of the tree, ordered from top to bottom.

Example 1:
Input: root = [1,2,3]

Output: [1,3]
Example 2:

Input: root = [1,2,3,4,5,6,7]
Output: [1,3,7]

Constraints:
0 <= number of nodes in the tree <= 100
-100 <= Node.val <= 100

*/