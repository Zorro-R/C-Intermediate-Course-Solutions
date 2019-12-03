using System;

namespace Stackoverflow_Post
{
    public class Post
    {
        public string Title { get; set; }
        public DateTime PostDate { get; private set; }
        public int Votes { get; private set; }

        public Post()
        {
            PostDate = DateTime.Now;
            Votes = 0;
        }

        public Post(string title)
            :this()
        {
            Title = title;
        }

        public void Upvote()
        {
            Votes++;
        }

        public void Downvote()
        {
            Votes--;
        }
    }
}