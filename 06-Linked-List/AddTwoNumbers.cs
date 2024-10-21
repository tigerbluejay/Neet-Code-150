/**
 * Definition for singly-linked list resides in file "ReverseLinkedLists.cs".
 */

public partial class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var sumList = new ListNode();
        var current = sumList;
        int carry = 0, sum = 0;
        
        while (l1 != null || l2 != null || carry == 1)
        {
            var v1 = 
            l1 == null ? 0 : l1.val; // obtain the value
            var v2 = 
            l2 == null ? 0 : l2.val; // obatin the value
            
            sum = v1 + v2 + carry; // sum the values
            carry = sum > 9 ? 1 : 0; // is there a carry?

            sum = sum % 10; // extract the rightmost digit of the sum
            current.next = new ListNode(sum); // save the rightmost as the next value in the list
            
            current = current.next; // move the pointer
            l1 = 
            l1 == null ? null : l1.next;
            l2 = 
            l2 == null ? null : l2.next;
        }
        
        return sumList.next;
    }
}


/*
Add Two Numbers

You are given two non-empty linked lists, l1 and l2, where each represents a non-negative integer.

The digits are stored in reverse order, e.g. the number 123 is represented as 3 -> 2 -> 1 -> in the linked list.

Each of the nodes contains a single digit. You may assume the two numbers do not contain any leading zero, 
except the number 0 itself.

Return the sum of the two numbers as a linked list.

Example 1:
Input: l1 = [1,2,3], l2 = [4,5,6]
Output: [5,7,9]
Explanation: 321 + 654 = 975.

Example 2:
Input: l1 = [9], l2 = [9]
Output: [8,1]

Constraints:
1 <= l1.length, l2.length <= 100.
0 <= Node.val <= 9
*/