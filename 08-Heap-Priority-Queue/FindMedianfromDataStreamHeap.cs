public class MedianFinderH
{

    private PriorityQueue<int, int> small; // Max heap for the smaller half
    private PriorityQueue<int, int> large; // Min heap for the larger half

    public MedianFinderH()
    {
        /*
        By default, PriorityQueue<int, int> in C# acts as a min heap.
        To make small behave as a max heap, we use a custom comparer:
            Comparer<int>.Create((a, b) => b.CompareTo(a))
        This custom comparer reverses the order of comparison:
            If a > b, it considers b as having higher priority.
        This effectively makes the largest number in small appear at the top,
        turning it into a max heap.
         */
        small = new PriorityQueue<int, int>
            (Comparer<int>.Create((a, b) => b.CompareTo(a))); // maxHeap
        large = new PriorityQueue<int, int>(); // minHeap
    }

    public void AddNum(int num)
    {
        // if num is greater than minHeaps's minimum value, add it to large
        if (large.Count != 0 && num > large.Peek())
        {
            large.Enqueue(num, num);
        }
        else // if num is smaller than minHeap's minimum value, add it to small
        {
            small.Enqueue(num, num);
        }

        // move from small to large, if small is more than 1 greater than large
        if (small.Count > large.Count + 1)
        {
            int val = small.Dequeue();
            large.Enqueue(val, val);
        } // move from large to small, if large is more than 1 greater than small
        else if (large.Count > small.Count + 1)
        {
            int val = large.Dequeue();
            small.Enqueue(val, val);
        }
    }

    public double FindMedian()
    {
        // peek maxHeap's max value if small is greater than large
        if (small.Count > large.Count)
        {
            return small.Peek();
        } // peek MinHeap's min value if large is greater than small
        else if (large.Count > small.Count)
        {
            return large.Peek();
        }

        // if lare and small size is the same, thake the average of
        // small's max value and large's min value
        int smallTop = small.Peek();
        return (smallTop + large.Peek()) / 2.0;
    }
}
/*

Find Median From Data Stream

The median is the middle value in a sorted list of integers. For lists of even
length, there is no middle value, so the median is the mean of the two middle values.

For example:

For arr = [1, 2, 3], the median is 2.
For arr = [1,2], the median is (1 + 2) / 2 = 1.5

Implement the MedianFinder class:

MedianFinder() initializes the MedianFinder object.
void addNum(int num) adds the integer num from the data stream to the data structure.
double findMedian() returns the median of all elements so far.

Example 1:
Input:
["MedianFinder", "addNum", "1", "findMedian", "addNum", "3" "findMedian",
"addNum", "2", "findMedian"]

Output:
[null, null, 1.0, null, 2.0,
null, 2.0]

Explanation:
MedianFinder medianFinder = new MedianFinder();
medianFinder.addNum(1);    // arr = [1]
medianFinder.findMedian(); // return 1.0
medianFinder.addNum(3);    // arr = [1, 3]
medianFinder.findMedian(); // return 2.0
medianFinder.addNum(2);    // arr[1, 2, 3]
medianFinder.findMedian(); // return 2.0
Constraints:

-100,000 <= num <= 100,000
findMedian will only be called after adding at least one integer to the data
structure.
*/






