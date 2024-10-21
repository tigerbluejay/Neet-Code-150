public class NodeRandom {
    public int val;
    public NodeRandom next;
    public NodeRandom random;
    
    public NodeRandom(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}

public partial class Solution {
    public NodeRandom CopyRandomList(NodeRandom head) {
        var map = new Dictionary<NodeRandom, NodeRandom>();
        if (head == null) return null;
        var copy = new NodeRandom(head.val);
        
        
        map[head] = copy;
        var cur1 = head.next;
        var cur2 = copy;
        
        // first pass to create the nodes
        // The loop continues until cur1 becomes null, meaning you've processed all the nodes in the original list.
        // cur1 points to the second node in the original list.
        while(cur1 != null) {
            var next2 = new NodeRandom(cur1.val);  // Create the copy of the current node
            cur2.next = next2;                     // Link the previous copied node to this new one
            map[cur1] = next2;                     // Map the original node to the copied node
            cur1 = cur1.next;                      // Move to the next node in the original list
            cur2 = cur2.next;                      // Move to the next node in the copied list 
        }
        
        cur1 = head;
        cur2 = copy;
        
        // second pass to update the random pointers
        while(cur2 != null) {
            var random = cur1.random != null 
                ? map[cur1.random]   // Map the random pointer of the original node to the copied node
                : null;              // If the original random pointer is null, set the copied random to null   
            
            cur2.random = random;   // Set the copied node's random pointer
            cur1 = cur1.next;
            cur2 = cur2.next;
                
                
        }
        return copy;
    }
}

/*

Copy Linked List with Random Pointer

You are given the head of a linked list of length n. 
Unlike a singly linked list, each node contains an additional pointer random, 
which may point to any node in the list, or null.

Create a deep copy of the list.

The deep copy should consist of exactly n new nodes, each including:

The original value val of the copied node
A next pointer to the new node corresponding to the next pointer of the original node
A random pointer to the new node corresponding to the random pointer of the original node

Note: None of the pointers in the new list should point to nodes in the original list.

Return the head of the copied linked list.

In the examples, the linked list is represented as a list of n nodes. 
Each node is represented as a pair of [val, random_index] where random_index is the index of the node (0-indexed) 
that the random pointer points to, or null if it does not point to any node.

Example 1:
Input: head = [[3,null],[7,3],[4,0],[5,1]]
Output: [[3,null],[7,3],[4,0],[5,1]]

Example 2:
Input: head = [[1,null],[2,2],[3,2]]
Output: [[1,null],[2,2],[3,2]]

Constraints:
0 <= n <= 100
-100 <= Node.val <= 100
random is null or is pointing to some node in the linked list.
*/