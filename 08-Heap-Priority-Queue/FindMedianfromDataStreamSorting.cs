class MedianFinderS
{
    private List<int> data;

    public MedianFinderS()
    {
        data = new List<int>();
    }

    public void AddNum(int num)
    {
        data.Add(num);
    }

    public double FindMedian()
    {
        data.Sort();
        int n = data.Count; // get the index
        /*
        n & 1 is a bitwise AND operation between n and 1.
        It checks whether the last bit of n is 1,
        which tells us whether n is odd or even:
            Odd number: The last bit is 1, so n & 1 == 1.
            Even number: The last bit is 0, so n & 1 == 0.
        This is a quick way to check whether n (the size of the list) is odd.
        */
        if ((n & 1) == 1)
        {
            return data[n / 2]; // if n is 3, there are three elements
                                // and 3/2 = 1, 1 is the second element since 0 is the first
                                // so we get the middle value
        }
        else
        {
            return (data[n / 2] + data[n / 2 - 1]) / 2.0; // if n is 4
                                                          // (data[2]+data[1])/2
                                                          // we get the average of two middle values
        }
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