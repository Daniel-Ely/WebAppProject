using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject_sucks
{
    public class User
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public List<string> Intrest { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [Key] public int UserID { get; set; }

        public User(string userName, string firstName, string gender, DateTime birthDay, List<string> intrest, string email, string password)
        {
            this.BirthDay = birthDay;
            this.Email = email;
            this.FirstName = firstName;
            this.Gender = gender;
            this.Intrest = intrest;
            this.Password = password;

        }
        public User()
        {

        }
    }
}
