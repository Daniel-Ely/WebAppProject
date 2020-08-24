using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProject_sucks.Models
{
    public class Item
    {
        [Key] public int ItemID {get;set;}
        [ForeignKey("Post")]
        public int PostID { get; set; }
        public Post Post { get; set; }
    }

}
