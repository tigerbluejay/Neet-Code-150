
public class TwitterS
{
    private int time;
    // followMap = {
    // 1: {2}, // User 1 is now only following User 2.
    // 2: {3}, // User 2 is still following User 3.
    // 3: {1}  // User 3 is still following User 1.
    private Dictionary<int, HashSet<int>> followMap;
    // tweetMap = {
    // 1: [(0, 10), (2, 11)],   // User 1 has posted two tweets: 
    // tweet ID 10 at timestamp 0, tweet ID 11 at timestamp 2.
    // 2: [(1, 20), (3, 21)]    // User 2 has posted two tweets:
    // tweet ID 20 at timestamp 1, tweet ID 21 at timestamp 3.
    //  }
    private Dictionary<int, List<(int, int)>> tweetMap;

    public TwitterS()
    {
        time = 0;
        followMap = new Dictionary<int, HashSet<int>>();
        tweetMap = new Dictionary<int, List<(int, int)>>();
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!tweetMap.ContainsKey(userId))
        {
            tweetMap[userId] = new List<(int, int)>();
        }
        tweetMap[userId].Add((time++, tweetId));
    }

    public List<int> GetNewsFeed(int userId)
    {
        // Fetches the list of tweets posted by the userId.
        // If the userId doesn't exist in the tweetMap,
        // it uses an empty list as the default.
        // Stores these tweets(each represented as a tuple of(time, tweetId))
        // in the feed list
        // Purpose: Start building the news feed by adding the user's own tweets.
        var feed = new List<(int, int)>(tweetMap.
            GetValueOrDefault(userId, new List<(int, int)>()));

        // Purpose: Include tweets from users that the current user follows
        // in the news feed.
        foreach (var followeeId in followMap.
            GetValueOrDefault(userId, new HashSet<int>()))
        {
            feed.AddRange(tweetMap.
                GetValueOrDefault(followeeId, new List<(int, int)>()));
        }

        // Sorts the feed list in descending order of time
        // (the first element of each tuple).
        // This ensures the most recent tweets appear first in the feed.
        // Purpose: Organize the tweets chronologically, with the newest ones
        // appearing first.
        feed.Sort((a, b) => b.Item1 - a.Item1);


        // Purpose: Limit the news feed to at most 10 tweets and return only the
        // tweet IDs.
        var res = new List<int>();

        for (int i = 0; i < Math.Min(10, feed.Count); i++)
        {
            res.Add(feed[i].Item2);
        }
        return res;
    }

    public void Follow(int followerId, int followeeId)
    {
        if (followerId != followeeId)
        {
            if (!followMap.ContainsKey(followerId))
            {
                followMap[followerId] = new HashSet<int>();
            }
            followMap[followerId].Add(followeeId);
        }
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