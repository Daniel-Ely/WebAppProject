using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class PageToCategory
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("ProfessionalPage")]
        public int ProfessionalPageID { get; set; }
        public ProfessionalPage ProfessionalPage { get; set; }
        //
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Category")]
        public string CategoryName { get; set; }
        public Category Category { get; set; }
    }
}