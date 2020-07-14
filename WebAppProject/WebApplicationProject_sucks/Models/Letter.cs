using System;

namespace WebApplicationProject_sucks
{
    public class Letter
    {

        public int Color { get; set; }

        public int Size { get; set; }

        public string Font { get; set; }

        public char _Letter { get; set; }

        public int LetterID { get; set; }

        public Letter(int color, int size, string font, char letter)
        {

            this.Color = color;
            this.Font = font;
            this._Letter = letter;
            this.Size = size;
        }
    }
}
