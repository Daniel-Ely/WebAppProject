using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class ProfessionToCategory
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Category")]
        public string CategoryID { get; set; }
        public Category Category { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Profession")]
        public string ProfessionID { get; set; }
        public Profession Profession { get; set; }
    }
}