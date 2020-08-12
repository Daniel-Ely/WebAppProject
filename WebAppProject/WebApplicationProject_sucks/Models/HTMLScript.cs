using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationProject_sucks.Models
{
    public class HTMLScript : Item
    {
        [AllowHtml]
        public string Content { get; set; }


        public void Display()
        {

        }
    }
}