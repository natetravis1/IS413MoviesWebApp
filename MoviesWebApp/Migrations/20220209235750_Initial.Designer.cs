﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesWebApp.Models;

namespace MoviesWebApp.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20220209235750_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("MoviesWebApp.Models.ApplicationResponse", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("ApplicationId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            ApplicationId = 1,
                            CategoryId = 1,
                            Director = "Christopher Nolan",
                            Edited = false,
                            LentTo = "N/A",
                            Notes = "Great movie!",
                            Rating = "PG-13",
                            Title = "The Dark Knight",
                            Year = 2008
                        },
                        new
                        {
                            ApplicationId = 2,
                            CategoryId = 3,
                            Director = "Denis Villenueve",
                            Edited = false,
                            LentTo = "Nate",
                            Notes = "Can't wait for part 2!",
                            Rating = "PG-13",
                            Title = "Dune",
                            Year = 2021
                        },
                        new
                        {
                            ApplicationId = 3,
                            CategoryId = 2,
                            Director = "Dan Gilroy",
                            Edited = false,
                            LentTo = "N/A",
                            Notes = "N/A",
                            Rating = "R",
                            Title = "Nightcrawler",
                            Year = 2014
                        });
                });

            modelBuilder.Entity("MoviesWebApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Action/Adventure"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Thriller"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Sci-Fi"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Horror"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Drama"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Comedy"
                        });
                });

            modelBuilder.Entity("MoviesWebApp.Models.ApplicationResponse", b =>
                {
                    b.HasOne("MoviesWebApp.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
