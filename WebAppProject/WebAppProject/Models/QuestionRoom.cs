using System;

public class QuestionRoom
{
    private string title;

    private string creator;

    private list<string> categories;

    private list<Comment> comments;


	public QuestionRoom(string title, string creator, list<string> categories, list<Comment> comments)
	{

        this.Categories = categories;
        this.Comments = comments;
        this.Creator = creator;
        this.Title = title;
       

    }

    #region
    public string Title { get => title; set => title = value; }
    public string Creator { get => creator; set => creator = value; }
    public list<string> Categories { get => categories; set => categories = value; }
    public list<Comment> Comments { get => comments; set => comments = value; }
    #endregion
}
