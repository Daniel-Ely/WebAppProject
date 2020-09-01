using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebApplicationProject_sucks.Attributes
{
    public class PrimaryKey:ValidationAttribute
    {
     

        public override string FormatErrorMessage(string name)
        {
            return "Username already taken!";
        }
    }

}
