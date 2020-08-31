using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class Profession
    {
        [Required(ErrorMessage = "Profession Name is required")]
        [Key] public string Profession_Name { get; set; }

        public virtual ICollection<ProfessionToCategory> Categories { get; set; }
    }
}