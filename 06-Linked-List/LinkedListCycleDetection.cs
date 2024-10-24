
 public class CycleListNode {
     public int val;
     public CycleListNode next;
     public CycleListNode(int x) {
         val = x;
         next = null;
     }
 }

public partial class Solution {
    public bool HasCycle(CycleListNode head) {
        CycleListNode slow = head, fast = head;

        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
            // checks for shallow copy equality
            if (slow.Equals(fast)) return true;
        }
        return false;

        // so in [1,2,3,4]
        // slow = 1, fast = 1
        // first iteration
        // fast = 3, slow = 2
        // second iteration
        // fast = 2, slow = 3
        // third iteration
        // fast = 4, slow = 4, return true
    }
}


/*

Linked List Cycle Detection

Given the beginning of a linked list head, 
return true if there is a cycle in the linked list. 
Otherwise, return false.

There is a cycle in a linked list if at least one node in the list that can be 
visited again by following the next pointer.
My note: So in [1,2,3] there may be a cycle if at least 2 can be visited again by following next so
1,2,3,2,3, or 1,2,3,1,2,3 would be examples of this.


Internally, index determines the index of the beginning of the cycle, 
if it exists. The tail node of the list will set it's next pointer 
to the index-th node. 
If index = -1, then the tail node points to null and no cycle exists.

Note: index is not given to you as a parameter.

Example 1:
Input: head = [1,2,3,4], index = 1
Output: true

Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).

Example 2:
Input: head = [1,2], index = -1
Output: false

Constraints:
1 <= Length of the list <= 1000.
-1000 <= Node.val <= 1000
index is -1 or a valid index in the linked list.

*/