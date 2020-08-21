using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class Image : Item
    {
        public string ImageTitle { get; set; }
        public HttpPostedFileBase ImageData { get; set; }
        public string[] Size { get; set; }
        public string[] Location { get; set; }

        public void Display() { }
    }
}