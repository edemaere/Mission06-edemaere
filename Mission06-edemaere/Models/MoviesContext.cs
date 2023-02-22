using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_edemaere.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext (DbContextOptions<MoviesContext> options) : base (options)
        {

        }

        public DbSet<MovieEntry> Entries { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Seed Category table with categories from provided data
            mb.Entity<Category>().HasData(
                    new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                    new Category { CategoryId = 2, CategoryName = "Comedy" },
                    new Category { CategoryId = 3, CategoryName = "Drama" },
                    new Category { CategoryId = 4, CategoryName = "Family" },
                    new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                    new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                    new Category { CategoryId = 7, CategoryName = "Television" },
                    new Category { CategoryId = 8, CategoryName = "VHS" }
                );

            //Seed movie table with a few of my favorite shows
            mb.Entity<MovieEntry>().HasData(
                new MovieEntry
                {
                    EntryId = 1,
                    CategoryId = 1,
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Notes = "It's lit bro"
                },
                new MovieEntry
                {
                    EntryId = 2,
                    CategoryId = 1,
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Notes = "It's lit too"
                },
                new MovieEntry
                {
                    EntryId = 3,
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Notes = "Chris Nolan = Chad"
                }

            );
        }
    }
}
