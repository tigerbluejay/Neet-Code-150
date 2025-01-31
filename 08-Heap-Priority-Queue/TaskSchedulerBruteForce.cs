
public partial class Solution
{
    public int LeastIntervalBruteForce(char[] tasks, int n)
    {
        // Block 1: Counts the occurrences of tasks.
        int[] count = new int[26];
        foreach (char task in tasks)
        {
            count[task - 'A']++;
        }

        // Block 2: Converts task frequencies into a list for processing.
        List<int[]> arr = new List<int[]>();
        for (int i = 0; i < 26; i++)
        {
            if (count[i] > 0)
            {
                arr.Add(new int[] { count[i], i });
            }
        }

        // Block 3: Simulates task scheduling while enforcing the cooldown constraint.
        int time = 0; // time represents the current time unit or the "slot" where
                      // the algorithm is executing a task (or remaining idle).
                      // Time progresses by 1 with each iteration of the while loop.
                List<int> processed = new List<int>();
        while (arr.Count > 0)
        {
            int maxi = -1; // This variable will store the index of the task in
                           // arr that can be executed in this time unit.

            // Each arr[i] contains two values:
            // arr[i][0]: remaining frequency of the task.
            // arr[i][1]: the task index(e.g., 0 for 'A', 1 for 'B').

            for (int i = 0; i < arr.Count; i++)
            {
                bool ok = true;
                for (int j = Math.Max(0, time - n); j < time; j++)
                {
                    // if the task has been processed, the loop will exit
                    if (j < processed.Count && processed[j] == arr[i][1])
                    {
                        ok = false;
                        break;
                    }
                }
                if (!ok) continue;
                // The task with the highest frequency is selected.
                // maxi stores the index of the task that will be executed
                if (maxi == -1 || arr[maxi][0] < arr[i][0])
                {
                    maxi = i;
                }
            }

            // Block 4: Executes tasks, updates frequencies,
            // and tracks time until all tasks are completed.
            time++;
            int cur = -1;
            if (maxi != -1)
            {
                // select the task to be executed
                cur = arr[maxi][1];
                arr[maxi][0]--;
                if (arr[maxi][0] == 0)
                {
                    arr.RemoveAt(maxi);
                }
            }
            // execute the task
            processed.Add(cur);
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