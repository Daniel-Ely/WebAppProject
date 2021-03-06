﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class ProfessionalPending
    {
        [Key]
        [ForeignKey("User")]
        public string UserName {set; get;}
        public User User { get; set; }

        [Required(ErrorMessage = "Profession is required")]
        [ForeignKey("Profession")]
        public string Profession_Name { get; set; }
        public Profession Profession { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }//education related- requires approvement

      
        //categories
        public virtual ICollection<PendingToCategory> ProfessionalCategories { get; set; }

        //application files
        public virtual ICollection<PendingFile> ApplyFiles { get; set; }
    }
}