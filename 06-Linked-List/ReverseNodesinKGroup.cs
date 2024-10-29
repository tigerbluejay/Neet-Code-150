/**
 * Definition for singly-linked list resides in file "ReverseLinkedLists.cs".
 */

public partial class Solution
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        var dummy = new ListNode(0, head);
        var groupPrev = dummy;
        var groupNext = dummy;

        while (true)
        {
            // the first time kth is 3
            // the second time kth is 6
            // the third time kth is null
            var kth = getKth(groupPrev, k);
            if (kth == null)
                break;

            groupNext = kth.next;

            // reverse group
            var prev = kth.next;
            var curr = groupPrev.next;

            // every execution of this while is for a kth segment
            // so the first time it converts [1,2,3] into [3,2,1]
            // the second it converts [4,5,6] into [6,5,4]
            while (curr != groupNext)
            {
                var temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }

            // The tmp variable temporarily stores the head of the linked list before the current group is reversed.
            // groupPrev.next = kth detaches the reversed group from the rest of the list.
            // groupPrev = tmp updates the groupPrev pointer to keep track of the remaining unprocessed 
            // part of the linked list.
            var tmp = groupPrev.next; // [0->1], 1 saved in temp // [4->null], 4 saved in temp
            groupPrev.next = kth; //0 points to 3 [0->3] // 1 points to 6 [1->6]
            groupPrev = tmp; // 1 is set to groupPrev [1->4,5,6] // 4 is is set to groupPrev [4->null] 
        }

        // dummy is 0, so list is [0,3,2,1,6,5,4,null]
        return dummy.next;
    }

    private ListNode getKth(ListNode curr, int k)
    {
        while (curr != null && k > 0)
        {
            curr = curr.next;
            k -= 1;
        }

        return curr;
    }
}

/*
Reverse Nodes in K-Group

You are given the head of a singly linked list head and a positive integer k.

You must reverse the first k nodes in the linked list, 
and then reverse the next k nodes, and so on. 
If there are fewer than k nodes left, leave the nodes as they are.

Return the modified list after reversing the nodes in each group of k.

You are only allowed to modify the nodes' next pointers, not the values of the nodes.

Example 1:
Input: head = [1,2,3,4,5,6], k = 3
Output: [3,2,1,6,5,4]

Example 2:
Input: head = [1,2,3,4,5], k = 3
Output: [3,2,1,4,5]

Constraints:
The length of the linked list is n.
1 <= k <= n <= 100
0 <= Node.val <= 100
*/