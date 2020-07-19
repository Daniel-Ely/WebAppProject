using System;
using System.Collections.Generic;
namespace WebApplicationProject_sucks.Model
{
    public class Text : Item
    {

        public string[] Location { get; set; }
        public int TextID { get; set; }

        public string _Text { get; set; }

        public Text(string text)
        {
            this._Text = text;
        }
 
        public void Display() { }
     
    }
}
