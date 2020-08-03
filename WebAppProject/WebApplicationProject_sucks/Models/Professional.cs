using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationProject_sucks.Models
{
    public class Professional : User
    {

        [ForeignKey("Profession")]
        public string Profession_Name { get; set; }
        public Profession Profession { get; set; }
        public string Description { get; set; }//education related- requires approvement

        public virtual ICollection<ProfessionalToCategory> ProfessionalCategories { get; set;}

        public double Score { get; set; }
  
    }
}