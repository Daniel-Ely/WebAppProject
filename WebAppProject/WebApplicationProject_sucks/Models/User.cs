using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject_sucks.Models
{
    public class User
    {
        [Display(Name = "User name")]
        [Key] public string UserName { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
       
        public string Gender { get; set; }

        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        public virtual ICollection<UserToCategory> Interests { get; set; }

        [Display(Name = "Email address")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Image ProfileImage { get; set; }

    }
}
