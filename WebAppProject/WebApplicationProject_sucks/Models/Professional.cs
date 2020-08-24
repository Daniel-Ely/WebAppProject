using System;
using System.Collections.Generic;

namespace WebApplicationProject_sucks.Models
{
    public class Professional : User
    {
   
        public string Description { get; set; }//education related- requires approvement

        public virtual ICollection<ProfessionalToCategory> ProfessionalCategories { get; set;}

        public double Score { get; set; }
  
    }
}