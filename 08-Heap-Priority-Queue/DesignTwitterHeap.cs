public class TwitterH
{
    private int count;

    // tweetMap = {
    // 1: [[0, 10], [2, 11]], // User 1 posted tweet ID 10 at time 0 and tweet ID 11 at time 2.
    // 2: [[1, 20]],          // User 2 posted tweet ID 20 at time 1.
    // 3: [[3, 30]]           // User 3 posted tweet ID 30 at time 3.
    // }
    private Dictionary<int, List<int[]>> tweetMap;

    // followMap = {
    // 1: {1, 2},  // User 1 follows themselves and User 2
    // 2: {2}      // User 2 follows only themselves
    private Dictionary<int, HashSet<int>> followMap;

    public TwitterH()
    {
        count = 0;
        tweetMap = new Dictionary<int, List<int[]>>();
        followMap = new Dictionary<int, HashSet<int>>();
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!tweetMap.ContainsKey(userId))
        {
            tweetMap[userId] = new List<int[]>();
        }
        tweetMap[userId].Add(new int[] { count++, tweetId });
    }

    public List<int> GetNewsFeed(int userId)
    {
        // Purpose: Prepare the structures needed to collect and prioritize tweets.
        List<int> res = new List<int>();
        PriorityQueue<int[], int> minHeap = new PriorityQueue<int[], int>();

        // Purpose: Guarantee that the user's own tweets are considered in their news feed.
        // Ensure the user follows themselves.
        if (!followMap.ContainsKey(userId))
        {
            followMap[userId] = new HashSet<int>();
        }
        followMap[userId].Add(userId);

        // The priority is -timestamp (latestTweet), so the most recent tweets
        // have the highest priority.
        // Purpose: Populate the priority queue with the most recent tweet from each
        // followee.
        foreach (int followeeId in followMap[userId])
        {
            if (tweetMap.ContainsKey(followeeId) && tweetMap[followeeId].Count > 0)
            {
                List<int[]> tweets = tweetMap[followeeId];
                int index = tweets.Count - 1;
                int[] latestTweet = tweets[index];
                minHeap.Enqueue(new int[]
                { latestTweet[0], latestTweet[1], followeeId, index }, -latestTweet[0]);
            }
        }

        // Purpose: Iteratively extract the most recent tweet and explore earlier
        // tweets, ensuring that the feed contains up to 10 tweets sorted in
        // reverse chronological order.
        while (minHeap.Count > 0 && res.Count < 10)
        {
            int[] curr = minHeap.Dequeue();
            res.Add(curr[1]);
            int index = curr[3];

            // Checks if there are earlier tweets from the same followee:
            // If so, fetches the next most recent tweet(index - 1).
            // Enqueues this earlier tweet into the minHeap
            if (index > 0)
            {
                int[] tweet = tweetMap[curr[2]][index - 1];
                minHeap.Enqueue(new int[]
                { tweet[0], tweet[1], curr[2], index - 1 }, -tweet[0]);
            }
        }

        return res;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!followMap.ContainsKey(followerId))
        {
            followMap[followerId] = new HashSet<int>();
        }
        followMap[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (followMap.ContainsKey(followerId))
        {
            followMap[followerId].Remove(followeeId);
        }
    }
}


/*
Design Twitter
Implement a simplified version of Twitter which allows users to post tweets,
follow/unfollow each other, and view the 10 most recent tweets within
their own news feed.

Users and tweets are uniquely identified by their IDs (integers).

Implement the following methods:

Twitter() Initializes the twitter object.

void postTweet(int userId, int tweetId) Publish a new tweet with ID tweetId by
the user userId. You may assume that each tweetId is unique.

List<Integer> getNewsFeed(int userId) Fetches at most the 10 most recent tweet
IDs in the user's news feed. Each item must be posted by users who the user is
following or by the user themself. Tweets IDs should be ordered from most recent
to least recent.

void follow(int followerId, int followeeId) The user with ID followerId follows
the user with ID followeeId.

void unfollow(int followerId, int followeeId) The user with ID followerId unfollows
the user with ID followeeId.

Example 1:

Input:
["Twitter",
"postTweet", [1, 10], "postTweet", [2, 20],
"getNewsFeed", [1], "getNewsFeed", [2],
"follow", [1, 2],
"getNewsFeed", [1], "getNewsFeed", [2],
"unfollow", [1, 2],
"getNewsFeed", [1]]

Output:
[null,
null, null,
[10], [20],
null,
[20, 10], [20],
null,
[10]]

Explanation:
Twitter twitter = new Twitter();
twitter.postTweet(1, 10); // User 1 posts a new tweet with id = 10.
twitter.postTweet(2, 20); // User 2 posts a new tweet with id = 20.
twitter.getNewsFeed(1);   // User 1's news feed should only contain
their own tweets -> [10].
twitter.getNewsFeed(2);   // User 2's news feed should only contain
their own tweets -> [20].
twitter.follow(1, 2);     // User 1 follows user 2.
twitter.getNewsFeed(1);   // User 1's news feed should contain both
tweets from user 1 and user 2 -> [20, 10].
twitter.getNewsFeed(2);   // User 2's news feed should still only
contain their own tweets -> [20].
twitter.unfollow(1, 2);   // User 1 follows user 2.
twitter.getNewsFeed(1);   // User 1's news feed should only contain
their own tweets -> [10].

Constraints:
1 <= userId, followerId, followeeId <= 100
0 <= tweetId <= 1000
*/