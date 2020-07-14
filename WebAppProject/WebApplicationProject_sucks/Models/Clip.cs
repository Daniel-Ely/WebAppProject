using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject_sucks
{
    public class Clip : Item
    {
        public int ClipID { get; set; }
        public int Size { get; set; }
        public string Path { get; set; }
        public Clip(string path)
        {
            this.Path = path;
        }
        public void display() { }
    }
}
