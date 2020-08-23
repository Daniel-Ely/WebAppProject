using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProject_sucks.Models
{
    public class QuestRoomComment
    {

        public QuestRoomComment()
        {

        }

        public QuestRoomComment(int commentID, int roomID, string content, string creator, DateTime date)
        {
            this.QuestCommentID = commentID;
            this.RoomID = roomID;
            this.Content = content;
            this.UserName = creator;
            this.Date = date;
        }

        [Key] public int QuestCommentID { get; set; }

        [ForeignKey("QuestionRoom")]
        public int RoomID { get; set; }
        public QuestionRoom QuestionRoom { get; set; }

        public string Content { get; set; }



        [ForeignKey("User")]
        public string UserName { get; set; }
        public User User { get; set; }

        public DateTime Date { get; set; }
    }
}
