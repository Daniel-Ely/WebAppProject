using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProject_sucks.Models
{
    public class Item
    {

        [ForeignKey("Post")]
        public string PostID { get; set; }
        public Post Post { get; set; }
    }

}
