public partial class Solution
{
    public int LeastIntervalMath(char[] tasks, int n)
    {
        int[] count = new int[26];
        foreach (char task in tasks)
        {
            count[task - 'A']++;
        }

        // Finds the maximum frequency of any task in the array using count.Max().
        int maxf = count.Max();
        int maxCount = 0;
        // Counts how many tasks have the same frequency as maxf (the maximum frequency).
        // This is stored in maxCount.
        foreach (int i in count)
        {
            if (i == maxf)
            {
                maxCount++;
            }
        }

        // The core formula used is:
        // Total Time = (maxf − 1) × ( n + 1 ) + maxCount
        // This formula determines the theoretical lower bound of time required
        // to schedule tasks while respecting the cooldown period.
        int time = (maxf - 1) * (n + 1) + maxCount;
        return Math.Max(tasks.Length, time);
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