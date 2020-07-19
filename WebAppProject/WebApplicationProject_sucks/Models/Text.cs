using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject_sucks
{
    public class Text : Item
    {

        public string[] Location { get; set; }
        [Key] public int TextID { get; set; }

        public string _Text { get; set; }

        public Text(string text)
        {
            this._Text = text;
        }
 
        public void Display() { }
     
    }
}
