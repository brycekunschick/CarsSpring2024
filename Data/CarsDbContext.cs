using CarsSpring2024.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsSpring2024.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Make> Makes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>().HasData(

                new Make
                {
                    MakeId = 1,
                    Name = "Toyota",
                    Description = "This is a description for Toyota."
                },

                new Make
                {
                    MakeId = 2,
                    Name = "Ford",
                    Description = "This is the description for Ford"
                },

                new Make
                {
                    MakeId = 3,
                    Name = "Honda",
                    Description = "This is the description for Honda"
                }

                );
        }

    }
}
