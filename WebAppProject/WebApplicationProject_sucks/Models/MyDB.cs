using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplicationProject_sucks.Models;

namespace WebApplicationProject_sucks
{
    public class MyDB:DbContext
    {
        public DbSet<HTMLScript> HTMLScripts { set; get; }
        public DbSet<QuestRoomComment> Comments{ set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<Clip> Clips { set; get; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Professional> Professionals { set; get; }
        public DbSet<ProfessionalPage> ProfessionalPages { set; get; }
        public DbSet<QuestionRoom> QuestionRooms { set; get; }
        public DbSet<Text> Texts { set; get; }
        public DbSet<User> Users { set; get; }

    }
}