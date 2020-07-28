using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class HTMLScript : Item
    {
        [Key] public int HTMLScriptID { get; set; }

        public string Content { get; set; }
        

        public void Display()
        {
          
        }
    }
}