using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Attributes
{
    public class Birthday : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value.GetType().Equals(DataType.DateTime.GetType()))
            {
                return false;
            }
            else
            {
                var dateValue = (DateTime)value;
                if (dateValue.DayOfYear > DateTime.Today.DayOfYear && dateValue.Year >= DateTime.Today.Year)
                return false;
            }
            return true;
        }
        public override string FormatErrorMessage(string name)
        {
            return "sorry we do not accept pepole from the future :)";
        }
    }
}