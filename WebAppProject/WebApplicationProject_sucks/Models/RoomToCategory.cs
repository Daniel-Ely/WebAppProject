using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class RoomToCategory
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("QuestionRoom")]
        public int QuestionRoomID { get; set; }
        public QuestionRoom QuestionRoom { get; set; }
        //
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Category")]
        public string CategoryName { get; set; }
        public Category Category { get; set; }
    }
}