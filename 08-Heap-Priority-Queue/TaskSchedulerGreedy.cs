
public partial class Solution
{
    public int LeastIntervalGreedy(char[] tasks, int n)
    {
        int[] count = new int[26];
        foreach (char task in tasks)
        {
            count[task - 'A']++;
        }

        Array.Sort(count);
        // Calculate Idle Slots: Using the task with the maximum frequency (maxf),
        // calculate the minimum number of idle slots required to space out tasks.
        // Example: For maxf = 3 and n = 2:
        // A _ _ A _ _ A
        // Number of idle slots = (3 - 1) * 2 = 4
        int maxf = count[25];
        int idle = (maxf - 1) * n;

        // What it does:
        // Loops through the task frequencies(except the most frequent one) in descending order.
        // For each task, it reduces the idle slots by the number of tasks that can fit in the idle spaces.
        // Math.Min(maxf - 1, count[i]) ensures we don’t overfill the gaps.
        // Other tasks can "fill" the idle slots to reduce the idle time and optimize the schedule.
        for (int i = 24; i >= 0; i--)
        {
            idle -= Math.Min(maxf - 1, count[i]);
        }
        // If idle slots remain, they must be added to the total task time.
        // If no idle slots remain, the total time is simply the length of the tasks.
        return Math.Max(0, idle) + tasks.Length;
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