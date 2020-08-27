using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class Location
    {
        [Key]
        public int LocationID { set; get; }
        public double Long {set; get;}
        public double Lat {set; get;}
        public string Address { set; get; }
    }
}