﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProject_sucks.Models
{
    public class ProfessionalPage
    {
        [Key] public int ProffesionalPageID { get; set; }

        public string NameOfPage { get; set; }

        public virtual ICollection<PageToCategory> Categories {get; set;}

        [ForeignKey("User")]
        public string UserName { get; set; }
        public User User { get; set; }
    }
}
