
/**
 * Definition for singly-linked list resides in file "ReverseLinkedLists.cs".
 */

public partial class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var dummy = new ListNode(0, head); // create a dummy node before the "head" or first node of our list
        var left = dummy; // set the pointer to it
        var right = head; // set the right pointer to the first node on our list
        
        // move the right pointer as many spaces as n
        while(n > 0) {
            right = right.next;
            n--;
        }
        // now the right and left pointers are separated by the right amount of space
        // such that when the right pointer reaches null, the left pointer will be at the node
        // we want to remove

        // move the right pointer until it reaches null
        // and the left pointer will be at the node to delete
        while(right != null) {
            left = left.next;
            right = right.next;
        }
        
        // delete the node (reassing 2->3->4 to 2->4, thus deleting 3)
        left.next = left.next.next;
        return dummy.next; // return the first node on our list
    }
}

/*
Remove Node From End of Linked List

You are given the beginning of a linked list head, and an integer n.

Remove the nth node from the end of the list and return the beginning of the list.
//clarification: remove starting at the end of the list

Example 1:
Input: head = [1,2,3,4], n = 2
Output: [1,2,4]

Example 2:
Input: head = [5], n = 1
Output: []

Example 3:
Input: head = [1,2], n = 2
Output: [2]

Constraints:
The number of nodes in the list is sz.
1 <= sz <= 30
0 <= Node.val <= 100
1 <= n <= sz
*/