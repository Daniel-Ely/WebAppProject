using System;

public class Post
{
    private int identifier;

    private list<string> categories;

    private string title;

    private string creator;

    private DateTime date;

    private list<Comment> comments;

    private list<Item> content;

	public Post(string creator)
	{
        this.Creator = creator;
       
    }
    #region
    public int Identifier { get => identifier;  }
    public list<string> Categories { get => categories; set => categories = value; }
    public string Title { get => title; set => title = value; }
    public string Creator { get => creator; set => creator = value; }
    public DateTime Date { get => date; set => date = value; }
    public list<Comment> Comments { get => comments; set => comments = value; }
    public list<Item> Content { get => content; set => content = value; }
    #endregion
}
