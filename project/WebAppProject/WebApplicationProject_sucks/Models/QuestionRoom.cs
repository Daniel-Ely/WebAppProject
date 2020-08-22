using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProject_sucks.Models
{
    public class QuestionRoom
    {
        [Key] public int QuestionRoomID { get; set; }

        [Display(Name = "Question")]
        public string Title { get; set; }

        [ForeignKey("User")]
        public string CreatorName { get; set; }
        public User User { get; set; }

     
        public virtual ICollection<RoomToCategory> Categories { get; set; }

        public virtual ICollection<QuestRoomComment> Comments { get; set; }

    }
}
