using System;

public class User
{

    private string userName;

    private string firstName;

    private string gender;

    private DateTime birthDay;

    private list<string> intrest;

    private string email;

    private string password;


public User(string userName, string firstName, string gender, DateTime birthDay, list<string> intrest, string email, string password)
	{
        this.BirthDay = birthDay;
        this.Email = email;
        this.FirstName = firstName;
        this.Gender = gender;
        this.Intrest = intrest;
        this.Password = password;

    }

    //setters and getters
    #region
    public string UserName { get => userName; set => userName = value; }
    public string FirstName { get => firstName; set => firstName = value; }
    public string Gender { get => gender; set => gender = value; }
    public DateTime BirthDay { get => birthDay; set => birthDay = value; }
    public list<string> Intrest { get => intrest; set => intrest = value; }
    public string Email { get => email; set => email = value; }
    public string Password { get => password; set => password = value; }
    #endregion
}
