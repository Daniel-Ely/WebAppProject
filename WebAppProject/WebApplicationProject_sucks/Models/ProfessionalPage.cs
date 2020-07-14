using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationProject_sucks
{
    public class ProfessionalPage
    {

        public string NameOfPage { get; set; }

        public List<string> Categories { get; set; }

        public List<Post> Posts { get; set; }

        public string UserName { get; set; }

        [Key]public int ProffesionalPageID { get; set; }

        public ProfessionalPage(string nameOfPage, List<string> categories, List<Post> posts, string userName)
        {

            this.Categories = categories;
            this.NameOfPage = nameOfPage;
            this.Posts = posts;
            this.UserName = userName;

        }

    }
}
