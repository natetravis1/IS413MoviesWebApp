using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebApp.Models
{
    public class MovieContext : DbContext
    {
        // constructor
        public MovieContext (DbContextOptions<MovieContext> options) : base (options)
        {
            // leave blank
        }

        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        // seeding the data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Thriller"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Sci-Fi"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Horror"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Drama"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Comedy"
                }
            );

            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    ApplicationId = 1,
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false, 
                    LentTo = "N/A",
                    Notes = "Great movie!"
                },
                new ApplicationResponse
                {
                    ApplicationId = 2,
                    CategoryId = 3,
                    Title = "Dune",
                    Year = 2021,
                    Director = "Denis Villenueve",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Nate",
                    Notes = "Can't wait for part 2!"
                },
                new ApplicationResponse
                {
                    ApplicationId = 3,
                    CategoryId = 2,
                    Title = "Nightcrawler",
                    Year = 2014,
                    Director = "Dan Gilroy",
                    Rating = "R",
                    Edited = false,
                    LentTo = "N/A",
                    Notes = "N/A"
                }
            );
        }
    }
}
