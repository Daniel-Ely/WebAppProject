using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebApplicationProject_sucks.Attributes
{
    public class Email : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                MailAddress m = new MailAddress(value.ToString());
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}