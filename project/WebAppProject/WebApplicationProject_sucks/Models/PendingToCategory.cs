using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class PendingToCategory
    {

        public PendingToCategory(string userName, string categoryname)
        {
            this.P_UserName = userName;
            this.CategoryName = categoryname;
        }

        public PendingToCategory()
        {

        }

        [Key]
        [Column(Order = 0)]
        [ForeignKey("ProfessionalPending")]
        public string P_UserName { get; set; }
        public ProfessionalPending ProfessionalPending { get; set; }
        
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Category")]
        public string CategoryName { get; set; }
        public Category Category { get; set; }
    }
}