using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace WebApplicationProject_sucks.Model
{
    public class Clip : Item
    {
        
        public int ClipId { get; set; }
        public string ClipTitle { get; set; }
        public byte[] ClipData { get; set; }
        public string[] Size { get; set; }
        public string[] Location { get; set; }
        
        
        public Clip()
        {
        
        }
        public void Display() { }
    }
}
