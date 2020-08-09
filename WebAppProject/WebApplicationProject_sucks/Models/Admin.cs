using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class Admin
    {
        [Key]
        public string AdminName{get; set;}
        [DataType(DataType.Password)]
        public string user { get; set;}
    }
}