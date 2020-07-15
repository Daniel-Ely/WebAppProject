using System;
using System.Drawing;

namespace WebApplicationProject_sucks
{
    public class Photo : Item
    {

        public string[] Size { get; set; }
        public string[] Location { get; set; }
        public Image Img { get; set; }

        public int PhotoID { get; set; }

        public Photo(string path)//this refers to local images.
        { 
           Img= Image.FromFile(path);         
        }

        public void Display() { }
    }
}