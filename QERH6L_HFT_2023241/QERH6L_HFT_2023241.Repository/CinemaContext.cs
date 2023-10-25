using Microsoft.EntityFrameworkCore;
using QERH6L_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Repository
{
    public class CinemaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CinemaDb");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>()
                .HasMany(c => c.showtimes)
                .WithOne(s => s.cinema);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.showtimes)
                .WithOne(s => s.movie);

            modelBuilder.Entity<Cinema>().HasData(
               new Cinema() { id = 1, name = "Malom Mozi", address = "Deák Ferenc utca", city = "Kecskemét" },
               new Cinema() { id = 2, name = "Sugár Mozi", address = "Pillangó utca", city = "Budapest" },
               new Cinema() { id = 3, name = "Cinema City", address = "Malom utca", city = "Kiskunhalas" });

            modelBuilder.Entity<Movie>().HasData(
              new Movie() { id = 1, length = 120, name = "Star Wars", category = "scifi" },
              new Movie() { id = 2, length = 150, name = "Vakáció", category = "vígjáték" });
            

        }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
       
    }
}
