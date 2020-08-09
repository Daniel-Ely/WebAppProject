using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProject_sucks.Models
{
    public class Professional 
    {
        [Key]
        [ForeignKey("User")]
        public string UserName { get; set; }
        public User User { get; set; }

        [ForeignKey("Profession")]
        public string Profession_Name { get; set; }
        public Profession Profession { get; set; }
        public string Description { get; set; }//education related- requires approvement

        public virtual ICollection<ProfessionalToCategory> ProfessionalCategories { get; set;}

        public double Score { get; set; }
  
    }
}