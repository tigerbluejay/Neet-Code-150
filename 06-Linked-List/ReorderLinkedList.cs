/**
 * Definition for singly-linked list resides in file "ReverseLinkedLists.cs".
 */

public partial class Solution {
    
    public void ReorderList(ListNode head) {
        if(head == null || head.next == null) return;
        
        // find middle
        var slow = head;
        var fast = head.next;
        var nodeCount = 1;
        while(true) {
            // when the fast pointer reaches the end, the slow pointer will be at the middle of the list
            if(fast == null || fast.next == null) break;
            slow = slow.next;
            nodeCount++;
            fast = fast.next.next; 
        }
        
        // the slow pointer is now at the middle point o the list
        var middle = slow.next;
        slow.next = null;
        
        // reverse the second half of the list
        var secondHead = revList(middle);
        
        // merge two lists
        var first = head;
        var second = secondHead;

        // merging:
        // Input: head = [2,4,6,8]
        // Output: [2,8,4,6]
        while(second != null) {
            var temp1 = first.next;
            var temp2 = second.next;
            first.next = second;
            second.next = temp1;
            first = temp1;
            second = temp2;
            
        }
        // first = 2, second = 8
        // first iteration
        // first.next = 8, second.next = 4
        // [2->8->4]
        // first= 4, second = 6
        
        // second iteration
        // first.next = 6, second.next = null (after 6 is null)
        // [2->8->4->6->null]
        // first = null, second = null
        
        return;
    }

    private ListNode revList(ListNode head) {

        ListNode prev = null;        
        var cur = head;
        
        while(cur != null) {
            var temp = cur.next;
            cur.next = prev;
            prev = cur;
            cur = temp;
        }
        return prev;
        
    }
}
/*
Reorder Linked List

You are given the head of a singly linked-list.

The positions of a linked list of length = 7 for example, can intially be represented as:
[0, 1, 2, 3, 4, 5, 6]

Reorder the nodes of the linked list to be in the following order:
[0, 6, 1, 5, 2, 4, 3]

Notice that in the general case for a list of length = n the nodes are reordered to be in the following order:
[0, n-1, 1, n-2, 2, n-3, ...]

You may not modify the values in the list's nodes, but instead you must reorder the nodes themselves.
Example 1:
Input: head = [2,4,6,8]
Output: [2,8,4,6]

Example 2:
Input: head = [2,4,6,8,10]
Output: [2,10,4,8,6]

Constraints:
1 <= Length of the list <= 1000.
1 <= Node.val <= 1000
*/