using System;
using System.Collections.Generic;
namespace WebApplicationProject_sucks.Model
{
    public class Comment
    {

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        [Key] public int CommentID { get; set; }

        public Text Content { get; set; }

        public Comment(string userName)
        {
            this.UserName = userName;

        }

    }
}
