using System;
using System.Drawing;

namespace WebApplicationProject_sucks.Model
{
    public class Image : Item
    {
        [Key] public int ImageId { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string[] Size { get; set; }
        public string[] Location { get; set; }
  

        public Image()
        { 
       
        }

        public void Display() { }
    }
}