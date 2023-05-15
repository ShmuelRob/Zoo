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
                new { CategoryId = 1, Name = "Mammal" },
                new { CategoryId = 2, Name = "Birds" },
                new { CategoryId = 3, Name = "Fish" },
                new { CategoryId = 4, Name = "Amphibians" },
                new { CategoryId = 5, Name = "reptiles" }
                );


            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, CategoryId = 1, Age = 5, Name = "Lion", ImageSource = sources[1], Description = "description for lion" },
                new { AnimalId = 2, CategoryId = 1, Age = 2, Name = "Dog", ImageSource = sources[2], Description = "description for dog" },
                new { AnimalId = 3, CategoryId = 2, Age = 12, Name = "Eagle", ImageSource = sources[3], Description = "description for eagle" },
                new { AnimalId = 4, CategoryId = 3, Age = 3, Name = "Shark", ImageSource = sources[4], Description = "description for shark" },
                new { AnimalId = 5, CategoryId = 1, Age = 4, Name = "Cat", ImageSource = sources[5], Description = "description for cat" },
                new { AnimalId = 6, CategoryId = 5, Age = 1, Name = "Chameleon", ImageSource = sources[6], Description = "description for chameleon" },
                new { AnimalId = 7, CategoryId = 3, Age = 15, Name = "Whale", ImageSource = sources[7], Description = "description for whale" },
                new { AnimalId = 8, CategoryId = 2, Age = 2, Name = "Pigeon", ImageSource = sources[8], Description = "description for pigeon" },
                new { AnimalId = 9, CategoryId = 5, Age = 4, Name = "Alligator", ImageSource = sources[9], Description = "description for alligator" },
                new { AnimalId = 10, CategoryId = 2, Age = 9, Name = "Owl", ImageSource = sources[10], Description = "description for owl" }
                );


            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, AnimalId = 1, Content = "king of animals", Visitor = "Admin" },
                new { CommentId = 2, AnimalId = 2, Content = "the man's best friend", Visitor = "Shmuel" },
                new { CommentId = 3, AnimalId = 1, Content = "Simba is his brother" },
                new { CommentId = 4, AnimalId = 5, Content = "licks itself", Visitor = "Moshe" },
                new { CommentId = 5, AnimalId = 6, Content = "can change colors", Visitor = "David" },
                new { CommentId = 6, AnimalId = 7, Content = "the biggest fish in the world", Visitor = "Yossi" },
                new { CommentId = 7, AnimalId = 9, Content = "you don't want to mess with this guy..." },
                new { CommentId = 8, AnimalId = 10, Content = "the smartest bird", Visitor = "Avi" }
                );
        }
    }
}
