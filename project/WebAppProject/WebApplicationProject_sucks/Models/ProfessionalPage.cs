using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProject_sucks.Models
{
    public class ProfessionalPage
    {
        [Key] public int ProfessionalPageID { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string NameOfPage { get; set; }

        [Required(ErrorMessage = "Pick at least one category")]
        public virtual ICollection<PageToCategory> Categories {get; set;}

        public virtual ICollection<Post> Posts { get; set; }

        [ForeignKey("User")]
        public string UserName { get; set; }
        public User User { get; set; }
    }
}
