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
        public DbSet<ProfessionalPage> ProfessionalPages { set; get; }
        public DbSet<QuestionRoom> QuestionRooms { set; get; }
        public DbSet<User> Users { set; get; }
        public DbSet<ProfessionalToCategory> ProfessionalToCategories { set; get; }
        public DbSet<UserToCategory> UserToCategories { set; get; }
        public DbSet<PostToCategory> PostToCategories { set; get; }
        public DbSet<PageToCategory> PageToCategories { set; get; }
        public DbSet<RoomToCategory> RoomToCategories { set; get; }
        public DbSet<Category> Categories { set; get; }

        public DbSet<Item> Items { get; set; }

        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<Profession> Professions { get; set; }

        public DbSet<ProfessionToCategory> ProfessionToCategories { get; set; }
    }
}