/**
 * Definition for singly-linked list resides in file "ReverseLinkedLists.cs".
 */


public partial class Solution {
    public ListNode MergeKLists(ListNode[] lists) {

        if (lists.Length == 0)
        {
            return null;
        }
        
        while (lists.Length > 1) // this will run so long the lists have not been merged into a single list
        {
             // merged lists will contain half of the lists.Length since each index will hold two merged lists
            var mergedLists = new ListNode[(lists.Length + 1) / 2];
            for (int i = 0; i < lists.Length; i += 2) // iterate by skipping two,
            // so first lists[0] and lists[1], then lists[2] and lists[3], and so on.
            {
                var l1 = lists[i]; // lists[0] will be the first list
                var l2 = (i + 1 < lists.Length) ? lists[i + 1] : null; // lists[1] will be the second list
                mergedLists[i/2] = (MergeLists(l1, l2)); // this will save to the right index the merged lists
            }
            lists = mergedLists;
        }
        
        return lists[0];
    }
    
    public ListNode MergeLists(ListNode l1, ListNode l2)
    {
        var sorted = new ListNode();
        var current = sorted;
        
        while (l1 != null && l2 != null) // this will run as long as both are not null
        {
            if (l1.val <= l2.val)
            {
                current.next = l1; // set node
                l1 = l1.next; // for next iteration
            }
            else
            {
                current.next = l2; // set node
                l2 = l2.next; // for next iteration
            }
            current = current.next; // move to next element
        }
        
        if (l1 != null) // if l1 is not null there are still elements in l1 to append
        {
            current.next = l1;
        } else  // if l1 is null then append whatever is in l2 to the end
        {
            current.next = l2;
        }
        
        return sorted.next;
    }
}




/*
Merge K Sorted Linked Lists

You are given an array of k linked lists lists, 
where each list is sorted in ascending order.

Return the sorted linked list that is the result of merging all of the individual linked lists.

Example 1:
Input: lists = [[1,2,4],[1,3,5],[3,6]]
Output: [1,1,2,3,3,4,5,6]

Example 2:
Input: lists = []
Output: []

Example 3:
Input: lists = [[]]
Output: []

Constraints:
0 <= lists.length <= 1000
0 <= lists[i].length <= 100
-1000 <= lists[i][j] <= 1000

*/