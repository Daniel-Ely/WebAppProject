using System;
using System.Collections.Generic;

namespace WebApplicationProject_sucks.Model
{
    public class Post
    {
        public int PostID { get; set; }

        public List<string> Categories { get; set; }

        public string Title { get; set; }

        public string Creator { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Item> Content { get; set; }

        public int Rating { get; set; }

        public int NumOfRating { get; set; }

        public Post(string creator)
        {
            this.Creator = creator;
        }

    }
}
