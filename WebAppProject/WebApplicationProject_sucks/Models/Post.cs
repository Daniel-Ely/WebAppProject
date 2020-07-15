using System;
using System.Collections.Generic;

namespace WebApplicationProject_sucks
{
    public class Post
    {
        public int PostID { get; set; }

        public List<string> Categories { get; set; }

        public string Title { get; set; }

        public string Creator { get; set; }

        public DateTime Date { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Item> Content { get; set; }



        public Post(string creator)
        {
            this.Creator = creator;
        }

    }
}
