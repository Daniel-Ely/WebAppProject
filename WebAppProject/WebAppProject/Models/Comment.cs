using System;

public class Comment
{

    private string userName;

    private DateTime date;

    private int identifier;

    private list<Item> content;

    public Comment(string userName)
	{
        this.UserName = userName;

    }
    #region
    public string UserName { get => userName; set => userName = value; }
    public DateTime Date { get => date; set => date = value; }
    public int Identifier { get => identifier; }
    public list<Item> Content { get => content; set => content = value; }
    #endregion
}
