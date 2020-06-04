using System;
using System.Collections.Generic;

public class Text: Item
{

    private List<Letter> text;

	public Text()
	{

	}

    public void addLetter(Letter l, int index)
    {
        text.insert(index, l);
    }

    public void removeLetter(int index)
    {
        text.remove(index);
    }

    public void update(Letter l, int index)
    {
       //to-do

    }

    public void display() { }
}
