using System;
using System.Drawing;

namespace WebApplicationProject_sucks
{
    public class Image : Item
    {
        public int ImageId { get; set; }
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