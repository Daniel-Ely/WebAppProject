using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject_sucks.Model
{
    public class QuestionRoom
    {
        public string Title { get; set; }

        public string Creator { get; set; }

        public List<string> Categories { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [Key]  public int QuestionRoomID { get; set; }

        public QuestionRoom(string title, string creator, List<string> categories, List<Comment> comments)
        {

            this.Categories = categories;
            this.Comments = comments;
            this.Creator = creator;
            this.Title = title;


        }

    }
}
