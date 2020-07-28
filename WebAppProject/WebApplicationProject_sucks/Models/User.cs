using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject_sucks.Models
{
    public class User
    {     
       [Key] public string UserName { get; set; }

        public string FirstName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDay { get; set; }

        public virtual ICollection<Category> Interests { get; set; }     

        public string Email { get; set; }

        public string Password { get; set; }


    }
}
