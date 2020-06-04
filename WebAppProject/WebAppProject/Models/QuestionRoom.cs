using System;
using System.Collections.Generic;

public class QuestionRoom
{
    private string title;

    private string creator;

    private List<string> categories;

    private List<Comment> comments;


	public QuestionRoom(string title, string creator, List<string> categories, List<Comment> comments)
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
