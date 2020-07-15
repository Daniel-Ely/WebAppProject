using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace WebApplicationProject_sucks
{
    public class Clip : Item
    {
        public string[] Size { get; set; }
        public string[] Location { get; set; }
        public int ClipID { get; set; }
        public string URLPath { get; set; }
        
        
        public Clip(string path)
        {
           // FileStream this.URLPath = path;
        }
        public void Display() { }
    }
}
