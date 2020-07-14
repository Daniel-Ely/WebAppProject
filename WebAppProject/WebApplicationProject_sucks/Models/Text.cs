using System;
using System.Collections.Generic;
namespace WebApplicationProject_sucks
{
    public class Text : Item
    {
        public int TextID { get; set; }

        public List<Letter> _Text { get; set; }

        public Text()
        {
            _Text = new List<Letter>();
        }

        public void addLetter(Letter l, int index)
        {
            _Text.Insert(index, l);
        }

        public void removeLetter(int index)
        {
            _Text.RemoveRange(index, 1);
        }

        //add an update option

        public void display() { }

        //public int TextID { get => textID; }
    }
}
