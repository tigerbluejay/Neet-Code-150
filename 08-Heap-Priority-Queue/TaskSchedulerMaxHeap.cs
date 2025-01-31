public partial class Solution
{
    public int LeastIntervalMaxHeap(char[] tasks, int n)
    {
        int[] count = new int[26];
        foreach (var task in tasks)
        {
            count[task - 'A']++;
        }

        // The PriorityQueue ensures that the task with the highest frequency is
        // always processed first.
        // Scheduling the most frequent task first ensures minimal idle time.
        var maxHeap = new PriorityQueue<int, int>();
        for (int i = 0; i < 26; i++)
        {
            if (count[i] > 0)
            {
                // the negative sign is to convert this to a MaxHeap instead
                // of a minHeap. so MaxHeap will always have in first place
                // the smallest values (the largest values with a negative sign)
                maxHeap.Enqueue(count[i], -count[i]);
            }
        }

        // time keeps track of the total units of time.
        // A queue queue is used to manage tasks that are cooling down. Each entry
        // in the queue is a pair [remaining_count, cooldown_time].
        // Tasks that have been executed but still need more executions cannot run
        // immediately.
        int time = 0;
        Queue<int[]> queue = new Queue<int[]>();
        while (maxHeap.Count > 0 || queue.Count > 0)
        {
            // If a task in the queue has completed its cooldown (time >=
            // queue.Peek()[1]), move it back to the heap for scheduling.
            if (queue.Count > 0 && time >= queue.Peek()[1])
            {
                int[] temp = queue.Dequeue();
                maxHeap.Enqueue(temp[0], -temp[0]);
            }
            if (maxHeap.Count > 0)
            {
                // Take the most frequent task (maxHeap.Dequeue()), execute it,
                // and decrease its count.
                // If the remaining count(cnt) is still greater than 0, place it
                // in the cooldown queue with the next available time(time +n + 1).
                int cnt = maxHeap.Dequeue() - 1;
                if (cnt > 0)
                {
                    queue.Enqueue(new int[] { cnt, time + n + 1 });
                }
            }
            time++;
        }
        return time;
    }
}

/*
Task Scheduler

Description

You are given an array of CPU tasks tasks, where tasks[i] is an uppercase english
character from A to Z. You are also given an integer n.

Each CPU cycle allows the completion of a single task, and tasks may be completed
in any order.

The only constraint is that identical tasks must be separated by at least n CPU
cycles, to cooldown the CPU.

Return the minimum number of CPU cycles required to complete all tasks.

Example 1:
Input: tasks = ["X","X","Y","Y"], n = 2
Output: 5
Explanation: A possible sequence is: X -> Y -> idle -> X -> Y.

Example 2:
Input: tasks = ["A","A","A","B","C"], n = 3
Output: 9
Explanation: A possible sequence is: A -> B -> C -> Idle -> A -> Idle -> Idle ->
Idle -> A.

Constraints:
1 <= tasks.length <= 1000
0 <= n <= 100
*/