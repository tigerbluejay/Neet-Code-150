
/**
 * Definition for a binary tree node is in InvertaBinaryTree.cs file.
 */

public partial class Solution {
    public int GoodNodesBFS(TreeNode root) {
        int res = 0;
        Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>();
        q.Enqueue((root, int.MinValue));

        while (q.Count > 0) {
            var (node, maxval) = q.Dequeue();
            
            // every time there is a good node, count it
            if (node.val >= maxval) {
                res++;
            }
            // Update maxval and add the left child to the queue
            if (node.left != null) {
                q.Enqueue((node.left, Math.Max(maxval, node.val)));
            }
            // Update maxval and add the right child to the queue
            if (node.right != null) {
                q.Enqueue((node.right, Math.Max(maxval, node.val)));
            }
        }
        return res;
    }
}

//        2
//   1         1
// 3  null    1  5 

// while loop
// The algorithm uses a queue to explore each level of the tree before moving on to the next level 
// (hence "breadth-first").

// first iteration of while loop:
// Dequeue (2, -∞), res = 1
// Queue after iteration: [(1, 2), (1, 2)] (where the second item in each are the max values (2))

// second iteration of the while loop:
// Dequeue (1, 2), res = 1
// Queue after iteration: [(1, 2), (3, 2)] (there were no right children)

// third iteration of the while loop
// Dequeue (1, 2), res = 1
// Queue after iteration: [(3, 2), (1, 2), (5, 2)]

// fourth iteration of the while loop
// Dequeue (3, 2), res = 2
// Queue after iteration: [(1, 2), (5, 2)]

// fifth iteration of the while loop
// Dequeue (1, 2), res = 2
// Queue after iteration: [(5, 2)]

// sixth iteration of the while loop
// Dequeue (5, 2), res = 3
// Queue after iteration: []


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