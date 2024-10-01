
public partial class Solution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        var pair = new (int, int)[position.Length];
        for (var i = 0; i < position.Length; i++)
        {
            pair[i] = (position[i], speed[i]);
        }

        var stack = new Stack<double>();
        foreach (var (p, s) in pair.OrderByDescending(i => i.Item1))
        {
            /* This line calculates the time it takes for a car to reach the destination and pushes it onto the stack. 
            This time calculation is crucial for determining whether a car will catch up to a fleet or become a separate fleet.
            target - p: This calculates the distance the car needs to travel to reach the destination. 
            target is the final destination, and p is the current position of the car.
            (double)s: This converts the car's speed (s) to a double data type. 
            This ensures that the division operation is performed with floating-point precision, 
            which is necessary to accurately calculate the time in hours.
            /: This divides the distance by the speed to get the time taken to travel that distance. 
            The result is the time in hours.
            stack.Push: This pushes the calculated time onto the stack. 
            The stack is used to keep track of the arrival times of cars, which is important for determining fleet formation.
            */
            stack.Push((target - p) / (double)s);
            if (stack.Count >= 2 && stack.Peek() <= stack.Skip(1).First())
            {
                stack.Pop();
            }
        }

        return stack.Count;
    }
}

/*
Car Fleet

There are n cars traveling to the same destination on a one-lane highway.

You are given two arrays of integers position and speed, both of length n.

position[i] is the position of the ith car (in miles)
speed[i] is the speed of the ith car (in miles per hour)
The destination is at position target miles.

A car can not pass another car ahead of it. It can only catch up to another car and then drive at the same speed as 
the car ahead of it.

A car fleet is a non-empty set of cars driving at the same position and same speed. A single car is also considered 
a car fleet.

If a car catches up to a car fleet the moment the fleet reaches the destination, then the car is considered to 
be part of the fleet.

Return the number of different car fleets that will arrive at the destination.

Example 1:

Input: target = 10, position = [1,4], speed = [3,2]

Output: 1

Explanation: The cars starting at 1 (speed 3) and 4 (speed 2) become a fleet, 
meeting each other at 10, the destination.

Example 2:

Input: target = 10, position = [4,1,0,7], speed = [2,2,1,1]

Output: 3
Explanation: The cars starting at 4 and 7 become a fleet at position 10. 
The cars starting at 1 and 0 never catch up to the car ahead of them. 
Thus, there are 3 car fleets that will arrive at the destination.

Constraints:

n == position.length == speed.length.
1 <= n <= 1000
0 < target <= 1000
0 < speed[i] <= 100
0 <= position[i] < target
All the values of position are unique.
*/