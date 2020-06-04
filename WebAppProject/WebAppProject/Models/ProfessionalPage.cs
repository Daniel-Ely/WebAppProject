using System;
using System.Collections.Generic;

public class ProfessionalPage
{

    private string nameOfPage;

    private list<string> categories;

    private list<Post> posts;

    private string userName;

    public ProfessionalPage(string nameOfPage, List<string> categories, list<Post> posts, string userName)
	{

        this.Categories = categories;
        this.NameOfPage = nameOfPage;
        this.Posts = posts;
        this.UserName = userName;

    }

    public string NameOfPage { get => nameOfPage; set => nameOfPage = value; }
    public list<string> Categories { get => categories; set => categories = value; }
    public list<Post> Posts { get => posts; set => posts = value; }
    public string UserName { get => userName; set => userName = value; }
}
