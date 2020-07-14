using System;

namespace WebApplicationProject_sucks
{
    public class Photo : Item
    {

        public int Size { get; set; }

        public string Path { get; set; }

        public int PhotoID { get; set; }

        public Photo(string path)
        {
            this.Path = path;
        }




        public void display() { }
    }
}