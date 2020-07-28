using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WebApplicationProject_sucks.Models
{
    public class Text : Item
    {

        public string[] Location { get; set; }
       [Key] public int TextID { get; set; }

        public string Content { get; set; }
    }
}
