using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class PostToCategory
    {

        public PostToCategory(int postId, string categoryname)
        {
            this.PostID = postId;
            this.CategoryName = categoryname;
        }
        public PostToCategory()
        {

        }

        [Key]
        [Column(Order = 0)]
        [ForeignKey("Post")]
        public int PostID { get; set; }
        public Post Post { get; set; }
        //
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Category")]
        public string CategoryName { get; set; }
        public Category Category { get; set; }
    }
}