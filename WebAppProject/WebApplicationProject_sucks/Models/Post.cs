using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProject_sucks.Models
{
    public class Post
    {
        [Key]public int PostID { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }


        public int Rating { get; set; }

        public int NumOfRating { get; set; }

        public virtual ICollection<Item> Content { get; set; }


        [ForeignKey("ProfessionalPage")]
        public string PageID { get; set; }
        public ProfessionalPage ProfessionalPage { get; set; }



        public virtual ICollection<Category> Categories { get; set; }

    }
}
