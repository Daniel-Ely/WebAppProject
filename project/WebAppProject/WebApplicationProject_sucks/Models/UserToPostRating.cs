using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class UserToPostRating
    {
        
        public UserToPostRating()
        {

        }

        public UserToPostRating(string userName, int PostId , int Rating)
        {
            this.Rating = Rating;
            this.PostId = PostId;
            this.UserName = userName;
        }
        public int Rating { set; get; }
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
        //
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserName { get; set; }
        public User User { get; set; }
    }
}