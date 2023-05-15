﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Zoo.DAL;

#nullable disable

namespace Zoo.Migrations
{
    [DbContext(typeof(ZooDbContext))]
    [Migration("20230514221846_Initial3")]
    partial class Initial3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Zoo.Models.Animal", b =>
                {
                    b.Property<int>("AnimalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnimalID"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryID")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageSource")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("AnimalID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalID = 1,
                            Age = 5,
                            CategoryID = 1,
                            Description = "description for lion",
                            ImageSource = "animal1.jpg",
                            Name = "Lion"
                        },
                        new
                        {
                            AnimalID = 2,
                            Age = 2,
                            CategoryID = 1,
                            Description = "description for dog",
                            ImageSource = "animal2.jpg",
                            Name = "Dog"
                        },
                        new
                        {
                            AnimalID = 3,
                            Age = 12,
                            CategoryID = 2,
                            Description = "description for eagle",
                            ImageSource = "animal3.webp",
                            Name = "Eagle"
                        },
                        new
                        {
                            AnimalID = 4,
                            Age = 3,
                            CategoryID = 3,
                            Description = "description for shark",
                            ImageSource = "animal4.jpg",
                            Name = "Shark"
                        },
                        new
                        {
                            AnimalID = 5,
                            Age = 4,
                            CategoryID = 1,
                            Description = "description for cat",
                            ImageSource = "animal5.jpg",
                            Name = "Cat"
                        },
                        new
                        {
                            AnimalID = 6,
                            Age = 1,
                            CategoryID = 5,
                            Description = "description for chameleon",
                            ImageSource = "animal6.webp",
                            Name = "Chameleon"
                        },
                        new
                        {
                            AnimalID = 7,
                            Age = 15,
                            CategoryID = 3,
                            Description = "description for whale",
                            ImageSource = "animal7.jpg",
                            Name = "Whale"
                        },
                        new
                        {
                            AnimalID = 8,
                            Age = 2,
                            CategoryID = 2,
                            Description = "description for pigeon",
                            ImageSource = "animal8.jfif",
                            Name = "Pigeon"
                        },
                        new
                        {
                            AnimalID = 9,
                            Age = 4,
                            CategoryID = 5,
                            Description = "description for alligator",
                            ImageSource = "animal9.webp",
                            Name = "Alligator"
                        },
                        new
                        {
                            AnimalID = 10,
                            Age = 9,
                            CategoryID = 2,
                            Description = "description for owl",
                            ImageSource = "animal10.jpg",
                            Name = "Owl"
                        });
                });

            modelBuilder.Entity("Zoo.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Name = "Mammal"
                        },
                        new
                        {
                            CategoryID = 2,
                            Name = "Birds"
                        },
                        new
                        {
                            CategoryID = 3,
                            Name = "Fish"
                        },
                        new
                        {
                            CategoryID = 4,
                            Name = "Amphibians"
                        },
                        new
                        {
                            CategoryID = 5,
                            Name = "reptiles"
                        });
                });

            modelBuilder.Entity("Zoo.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentID"));

                    b.Property<int>("AnimalID")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("Visitor")
                        .HasColumnType("text");

                    b.HasKey("CommentID");

                    b.HasIndex("AnimalID");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentID = 1,
                            AnimalID = 1,
                            Content = "king of animals",
                            Visitor = "Admin"
                        },
                        new
                        {
                            CommentID = 2,
                            AnimalID = 2,
                            Content = "the man's best friend",
                            Visitor = "Shmuel"
                        },
                        new
                        {
                            CommentID = 3,
                            AnimalID = 1,
                            Content = "Simba is his brother"
                        },
                        new
                        {
                            CommentID = 4,
                            AnimalID = 5,
                            Content = "licks itself",
                            Visitor = "Moshe"
                        },
                        new
                        {
                            CommentID = 5,
                            AnimalID = 6,
                            Content = "can change colors",
                            Visitor = "David"
                        },
                        new
                        {
                            CommentID = 6,
                            AnimalID = 7,
                            Content = "the biggest fish in the world",
                            Visitor = "Yossi"
                        },
                        new
                        {
                            CommentID = 7,
                            AnimalID = 9,
                            Content = "you don't want to mess with this guy..."
                        },
                        new
                        {
                            CommentID = 8,
                            AnimalID = 10,
                            Content = "the smartest bird",
                            Visitor = "Avi"
                        });
                });

            modelBuilder.Entity("Zoo.Models.Animal", b =>
                {
                    b.HasOne("Zoo.Models.Category", "Category")
                        .WithMany("Animals")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Zoo.Models.Comment", b =>
                {
                    b.HasOne("Zoo.Models.Animal", "AnimalCommented")
                        .WithMany("Comments")
                        .HasForeignKey("AnimalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnimalCommented");
                });

            modelBuilder.Entity("Zoo.Models.Animal", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Zoo.Models.Category", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
