/**
 * Definition for singly-linked list resides in file "ReverseLinkedLists.cs".
 */

public partial class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        var dummy = new ListNode();
        var tail = dummy;
        
        // while there are vals in the list
        while(list1 is not null && list2 is not null) {
            // if val in list 1 is smaller assign it to the tail list, and move to the next node in list 1
            if(list1.val < list2.val) {
                tail.next = list1;
                list1 = list1.next;
            }
            // if val in list 2 is smaller assign it to the tail list, and move the next node in list 2
            else {
                tail.next = list2;
                list2 = list2.next;
            }
            // move the tail to the next element
            tail = tail.next;
            // continue looping through lists1 and 2
        }
        
        // if there are values remaining in list1 append them to the tail list
        if(list1 is not null)
            tail.next = list1;
        // if there are value remaining in list2 append them to the tail list
        else if(list2 is not null)
            tail.next = list2;
        
        // return the list
        return dummy.next;
    }
}

/*
Merge Two Sorted Linked Lists

You are given the heads of two sorted linked lists list1 and list2.

Merge the two lists into one sorted linked list and return the head of the new sorted linked list.

The new list should be made up of nodes from list1 and list2.

Example 1:
Input: list1 = [1,2,4], list2 = [1,3,5]
Output: [1,1,2,3,4,5]

Example 2:
Input: list1 = [], list2 = [1,2]
Output: [1,2]

Example 3:
Input: list1 = [], list2 = []
Output: []

Constraints:
0 <= The length of the each list <= 100.
-100 <= Node.val <= 100
*/