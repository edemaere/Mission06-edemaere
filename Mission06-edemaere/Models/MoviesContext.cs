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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieEntry>().HasData(
                new MovieEntry
                {
                    EntryId = 1,
                    Category = "Sci-Fi",
                    Title = "Inception",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Notes = "It's lit bro"
                },
                new MovieEntry
                {
                    EntryId = 2,
                    Category = "Sci-Fi",
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Notes = "It's lit too"
                },
                new MovieEntry
                {
                    EntryId = 3,
                    Category = "Action",
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
