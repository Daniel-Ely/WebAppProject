
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject_sucks.Models
{
    public class User
    {
        //
        //User name
        //
        [Key]
        [Required(ErrorMessage = "User name is Required")]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        //
        //First name
        //
        [Required(ErrorMessage = "first name is Required")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        //
        //Gander
        //
        [Required(ErrorMessage = "gender is Required")]
        public string Gender { get; set; }
        //
        //Birthday
        //
        [Required(ErrorMessage = "Birthday is Required")]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        //
        //Intrests
        //
        //[Required(ErrorMessage = "Choose at least one category")]
        public virtual ICollection<UserToCategory> Interests {get; set;}
        //
        //Email
        //
        [Required(ErrorMessage = "Email address is Required")]
        [Display(Name = "Email address")]
        public string Email { get; set; }
        //
        //password
        //
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        //
        //Profile image
        //
        public Image ProfileImage { get; set; }

        public bool isProfessional { get; set; }

    }
}
