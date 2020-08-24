using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationProject_sucks.Models
{
    public class UserToCategory
    {
    
        [Key]
        [Column(Order = 0)]
        [ForeignKey("User")]
        public string UserName { get; set; }
        public User User { get; set; }
        //
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Category")]
        public string CategoryName { get; set; }
        public Category Category { get; set; }

        public int NumOfVisits { set; get; }

        public DateTime LastTouched { get; set; }
        public UserToCategory(string username, string categoryname)
        {
            this.UserName = username;
            this.CategoryName = categoryname;
            this.NumOfVisits = 0;
            this.LastTouched = DateTime.Today;
        }
    }
}