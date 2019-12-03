using System;

namespace Stackoverflow_Post
{
    class Program
    {
        static void Main(string[] args)
        {
            var post = new Post("Test Post Pls Ignore");
            Console.WriteLine(post.Votes);
            Console.WriteLine(post.PostDate);
            Console.WriteLine(post.Title);
            post.Upvote();
            post.Downvote();
            post.Upvote();
            post.Upvote();
            post.Upvote();
            Console.WriteLine(post.Votes);
            Console.WriteLine(post.PostDate);
            Console.WriteLine(post.Title);
        }
    }
}
