
/**
 * Definition for singly-linked list. */ 
 
 public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }

public partial class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null, curr = head;

        // while there is a curr element
        while (curr != null)
        {
            // grab the next node to assign it to the current node down the line
            var temp = curr.next;
            // prev's value comes from the previous iteration, assigns the next value
            curr.next = prev;
            // store the current value to prev to be used in the next iteration
            prev = curr;
            // assign the current node
            curr = temp;
        }
        return prev;
    }
}

// [0->1->2->3]

// first iteration - curr = 0, curr.next = null
// (curr = 1, prev = 0, stored for next iteration)
// (where curr will be assigned to prev and prev will be assigned to next)
// [0->null]

// second iteration - curr = 1, curr.next = 0
// (curr = 2, prev = 1, stored for next iteration)
// [1->0->null]

// third iteration - curr = 2, curr.next = 1
// (curr = 3, prev = 2 stored for next iteration)
// [2->1->0->null]

// fourth iteration - curr = 3,  curr.next = 2
// (curr = null, prev = 3 stored for next iteration)
// [3->2->1->0->null]
/*
Reverse a Linked List

Given the beginning of a singly linked list head, reverse the list, and return the new beginning of the list.

Example 1:
Input: head = [0,1,2,3]
Output: [3,2,1,0]

Example 2:
Input: head = []
Output: []

Constraints:
0 <= The length of the list <= 1000.
-1000 <= Node.val <= 1000
*/