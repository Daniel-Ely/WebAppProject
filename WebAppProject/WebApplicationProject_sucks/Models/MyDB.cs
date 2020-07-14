using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplicationProject_sucks
{
    public class MyDB:DbContext
    {

        public DbSet<Comment> Comment{ set; get; }
        public DbSet<Clip> Clip { set; get; }
        public DbSet<Letter> Letter { set; get; }
        public DbSet<Photo> Photo { set; get; }
        public DbSet<Post> Post { set; get; }
        public DbSet<Professional> Professional { set; get; }
        public DbSet<ProfessionalPage> ProfessionalPages { set; get; }
        public DbSet<QuestionRoom> QuestionRooms { set; get; }
        public DbSet<Text> Text { set; get; }
        public DbSet<User> User { set; get; }

        

        

    }
}