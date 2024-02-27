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

        public DbSet<Car> Cars { get; set; } //adds the Books table to the db

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

            modelBuilder.Entity<Car>().HasData(

                new Car
                {
                    CarId = 1,
                    Model = "Camry",
                    Price = 25000m,
                    MakeId = 1
                },

                new Car
                {
                    CarId = 2,
                    Model = "F-150",
                    Price = 69000m,
                    MakeId = 2
                },

                new Car
                {
                    CarId = 3,
                    Model = "Civic",
                    Price = 20000m,
                    MakeId = 3
                }

                );
        }

    }
}
