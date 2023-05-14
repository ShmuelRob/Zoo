using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Zoo.Models;

namespace Zoo.DAL
{
    public class ZooDbContext: DbContext
    {
        public virtual DbSet<Animal>? Animals { get; set; }
        public virtual DbSet<Category>? Categories { get; set; }
        public virtual DbSet<Comment>? Comments { get; set; }

        public ZooDbContext(DbContextOptions<ZooDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sources = new string[]
            {
                "error",
                "animal1.jpg",
                "animal2.jpg",
                "animal3.webp",
                "animal4.jpg",
                "animal5.jpg",
                "animal6.webp",
                "animal7.jpg",
                "animal8.jfif",
                "animal9.webp",
                "animal10.jpg",
            };


            modelBuilder.Entity<Category>().HasData(
                new { CategoryID = 1, Name = "Mammal" },
                new { CategoryID = 2, Name = "Birds" },
                new { CategoryID = 3, Name = "Fish" },
                new { CategoryID = 4, Name = "Amphibians" },
                new { CategoryID = 5, Name = "reptiles" }
                );


            modelBuilder.Entity<Animal>().HasData(
                new { AnimalID = 1, CategoryID = 1, Age = 5, Name = "Lion", ImageSource = sources[1], Description = "description for lion" },
                new { AnimalID = 2, CategoryID = 1, Age = 2, Name = "Dog", ImageSource = sources[2], Description = "description for dog" },
                new { AnimalID = 3, CategoryID = 2, Age = 12, Name = "Eagle", ImageSource = sources[3], Description = "description for eagle" },
                new { AnimalID = 4, CategoryID = 3, Age = 3, Name = "Shark", ImageSource = sources[4], Description = "description for shark" },
                new { AnimalID = 5, CategoryID = 1, Age = 4, Name = "Cat", ImageSource = sources[5], Description = "description for cat" },
                new { AnimalID = 6, CategoryID = 5, Age = 1, Name = "Chameleon", ImageSource = sources[6], Description = "description for chameleon" },
                new { AnimalID = 7, CategoryID = 3, Age = 15, Name = "Whale", ImageSource = sources[7], Description = "description for whale" },
                new { AnimalID = 8, CategoryID = 2, Age = 2, Name = "Pigeon", ImageSource = sources[8], Description = "description for pigeon" },
                new { AnimalID = 9, CategoryID = 5, Age = 4, Name = "Alligator", ImageSource = sources[9], Description = "description for alligator" },
                new { AnimalID = 10, CategoryID = 2, Age = 9, Name = "Owl", ImageSource = sources[10], Description = "description for owl" }
                );


            modelBuilder.Entity<Comment>().HasData(
                new { CommentID = 1, AnimalID = 1, Content = "king of animals", Visitor = "Admin" },
                new { CommentID = 2, AnimalID = 2, Content = "the man's best friend", Visitor = "Shmuel" },
                new { CommentID = 3, AnimalID = 1, Content = "Simba is his brother" },
                new { CommentID = 4, AnimalID = 5, Content = "licks itself", Visitor = "Moshe" },
                new { CommentID = 5, AnimalID = 6, Content = "can change colors", Visitor = "David" },
                new { CommentID = 6, AnimalID = 7, Content = "the biggest fish in the world", Visitor = "Yossi" },
                new { CommentID = 7, AnimalID = 9, Content = "you don't want to mess with this guy..." },
                new { CommentID = 8, AnimalID = 10, Content = "the smartest bird", Visitor = "Avi" }
                );
        }
    }
}
