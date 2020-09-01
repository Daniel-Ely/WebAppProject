
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using WebApplicationProject_sucks.Attributes;

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
        [Birthday]
        public DateTime BirthDay { get; set; }
        //
        //Intrests
        //

 
        public virtual ICollection<UserToCategory> Interests {get; set;}
        //
        //Email
        //
        [Required(ErrorMessage = "Email address is Required")]
        [Display(Name = "Email address")]
        [Email]
        public string Email { get; set; }
        //
        //password
        //
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        public byte[] salt { get; set; }
        //
        //Profile image
        //
        public byte[] ProfileImage { get; set; }
        
        public bool isProfessional { get; set; }
        
        //theres no need for admin model since we dont hold any additional data
        //hard-coded insertion to DB
        public bool isAdmin { get; set; }

    }
}
