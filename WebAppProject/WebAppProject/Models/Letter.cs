using System;

public class Letter
{

    private int color;

    private int size;

    private string font;

    private char letter;

    public Letter(int color, int size, string font, char letter)
    {

        this.Color = color;
        this.Font = font;
        this.Letter = letter;
        this.Size = size;
	}

    #region
    public int Color { get => color; set => color = value; }
    public int Size { get => size; set => size = value; }
    public string Font { get => font; set => font = value; }
    public char Letter { get => letter; set => letter = value; }
    #endregion
}
