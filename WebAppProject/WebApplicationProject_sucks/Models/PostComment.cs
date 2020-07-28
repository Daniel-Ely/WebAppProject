using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class PostComment
    {
        [Key] public int PostCommentID { get; set; }

        [ForeignKey("Post")]
        public string PostID { get; set;}
        public Post Post { get; set; }

        public Text Content { get; set; }

        [ForeignKey("User")]
        public string UserName { get; set; }
        public User User { get; set; }

        public DateTime Date { get; set; }

    }
}