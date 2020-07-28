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
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Post")]
        public string PostID { get; set; }
        public Post Post { get; set; }
        //
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Category")]
        public string CategoryID { get; set; }
        public Category Category { get; set; }
    }
}