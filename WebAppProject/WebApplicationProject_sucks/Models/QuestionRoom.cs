using System;
using System.Collections.Generic;

namespace WebApplicationProject_sucks
{
    public class QuestionRoom
    {
        public string Title { get; set; }

        public string Creator { get; set; }

        public List<string> Categories { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public int QuestionRoomID { get; set; }

        public QuestionRoom(string title, string creator, List<string> categories, List<Comment> comments)
        {

            this.Categories = categories;
            this.Comments = comments;
            this.Creator = creator;
            this.Title = title;


        }

    }
}
