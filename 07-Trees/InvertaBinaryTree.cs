
// Definition for a binary tree node.
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }

public partial class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null;

        var tmp = root.left;
        root.left = root.right;
        root.right = tmp;

        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }
}

// [2,3] -> [3,2]
// into 3 [6,7] -> [7,6]
//  into 7 [null,null] -> [null, null]
//  into 6 [null,null] -> [null, null]
// into 2 [4,5] -> [5,4]
//  into 5 [null,null] -> [null, null]
//  into 4 [null,null] -> [null, null]

/*

Invert a Binary Tree

You are given the root of a binary tree root. 
Invert the binary tree and return its root.

Example 1:
Input: root = [1,2,3,4,5,6,7]
Output: [1,3,2,7,6,5,4]

Example 2:
Input: root = [3,2,1]
Output: [3,1,2]

Example 3:
Input: root = []
Output: []

Constraints:
0 <= The number of nodes in the tree <= 100.

*/