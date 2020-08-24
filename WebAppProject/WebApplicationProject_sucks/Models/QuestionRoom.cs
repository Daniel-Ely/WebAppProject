using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject_sucks.Models
{
    public class QuestionRoom
    {
        [Display(Name = "Question")]
        public string Title { get; set; }

        public string Creator { get; set; }

        public virtual ICollection<RoomToCategory> Categories { get; set; }

        public virtual ICollection<QuestRoomComment> Comments { get; set; }

        [Key]  public int QuestionRoomID { get; set; }

 

    }
}
