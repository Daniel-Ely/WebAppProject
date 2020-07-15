using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace WebApplicationProject_sucks
{
    public class Clip : Item
    {
        public string[] Size { get; set; }
        public string[] Location { get; set; }
        public int ClipID { get; set; }
        public string VideoPath { get; set; }
        
        
        public Clip(HttpPostedFileBase file)
        {
            string fileName = file.FileName;
            VideoPath = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
            file.SaveAs(VideoPath);
        }
        public void Display() { }
    }
}
