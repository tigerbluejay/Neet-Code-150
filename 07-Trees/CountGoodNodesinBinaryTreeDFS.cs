
/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

public partial class Solution {
    
    public int GoodNodes(TreeNode root) {
        return Dfs(root, root.val);
    }

    private int Dfs(TreeNode node, int maxVal) {
        if (node == null) {
            return 0;
        }

        // res will increment by one every time we have a good node
        // but its value will be different on each iteration only cummulative within each recursion
        int res = (node.val >= maxVal) ? 1 : 0;
        maxVal = Math.Max(maxVal, node.val);
        res += Dfs(node.left, maxVal);
        res += Dfs(node.right, maxVal);
        return res;
    }
}

//        2
//   1         1
// 3  null    1  5 

/*
When you call GoodNodes(root), it does the following:

At the root (2), res = 1.
    Calls Dfs(node.left, maxVal = 2):
        At node 1 (left child), res = 0.
            Calls Dfs(node.left, maxVal = 2):
                At node 3, res = 1 (because 3 >= 2).
                Both children are null, so returns 1.
            Right child is null, so returns 1 to the parent 1 node.
    Cumulative res for the left subtree rooted at the first 1 is 1.
    Calls Dfs(node.right, maxVal = 2):
        At node 1 (right child), res = 0.
            Calls Dfs(node.left, maxVal = 2):
                At node 1, res = 0 (no new good nodes).
                Both children are null, so returns 0.
            Calls Dfs(node.right, maxVal = 2):
                At node 5, res = 1 (because 5 >= 2).
                Both children are null, so returns 1.
    Cumulative res for the right subtree rooted at the second 1 is 1.
The final return is 3, which is the sum of all good nodes in the tree.

Key Takeaway:
The "summing" you’re asking about happens automatically via the recursive accumulation (res += Dfs(...)) for each node. 
This pattern is common in recursive depth-first search algorithms where results are combined as the recursion unwinds.
*/


// return res = 1 => nodes visited before this res was returned were [2, 1, 3]
// good node(s) considered: [2, 3], The first return comes from node 3

// return res = 1 => nodes visited before this res was returned were [2, 1]
// good node(s) considered: [2], The second return is when the left subtree rooted at the first 1 completes. 
// Only the root node 2

// return res = 0 => nodes visited before this res was returned were [2, 1, 1]
// good node(s) considered: [2], The third return happens when checking the left child of the right subtree's 
// root 1. No new "good" nodes are found.

// return res = 1 => nodes visited before this res was returned were [2, 1, 1, 5]
// good node(s) considered: [2, 5], The fourth return comes from node 5, which is "good" since it’s 
// greater than all previous nodes in its path [2, 1].

// return res = 1 => nodes visited before this res was returned were [2, 1, 1]
// good node(s) considered: [2], The fifth return is after the right subtree rooted at the second 1 completes. 
// Only the root node 2 was "good" on that path.

// return res = 3 => nodes visited before this res was returned were [2]
// good node(s) considered: [2], The final return sums up all the results:








/*
Count Good Nodes in Binary Tree

Within a binary tree, a node x is considered good if the path from the root of the tree 
to the node x contains no nodes with a value greater than the value of node x

Given the root of a binary tree root, return the number of good nodes within the tree.

Example 1:
Input: root = [2,1,1,3,null,1,5]
Output: 3 - the three good nodes are (2, 2->1-3, 2->1->5)

        2
   1         1
 3  null    1  5 


Example 2:
Input: root = [1,2,-1,3,4]
Output: 4 - the four good nodes are (1, 1->2, 1->2->3, 1->2->4)

        1
   2         -1
 3  4    


Constraints:
1 <= number of nodes in the tree <= 100
-100 <= Node.val <= 100

*/