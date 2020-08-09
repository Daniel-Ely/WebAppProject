using System;
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
        //
        [ForeignKey("Profession")]
        public string Profession_Name { get; set; }
        public Profession Profession { get; set; }
        public string Description { get; set; }//education related- requires approvement

        public virtual ICollection<ProfessionalToCategory> ProfessionalCategories { get; set; }

        public List<byte[]> ApplyFiles {set; get;}

    }
}