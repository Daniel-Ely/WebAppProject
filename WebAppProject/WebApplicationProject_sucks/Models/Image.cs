using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
namespace WebApplicationProject_sucks.Models
{
    public class Image : Item
    {
        [Key] public int ImageId { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string[] Size { get; set; }
        public string[] Location { get; set; }

        public void Display() { }
    }
}