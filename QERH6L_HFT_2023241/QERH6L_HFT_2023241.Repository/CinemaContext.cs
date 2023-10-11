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
            Cinema cinema = new Cinema() {name = "Malom Mozi", address = "Deák Ferenc utca", city = "Kecskemét" };
            Cinema cinema2 = new Cinema() { name = "Sugár Mozi", address = "Pillangó utca", city = "Budapest" };
            Cinema cinema3 = new Cinema() { name = "Cinema City", address = "Malom utca", city = "Kiskunhalas" };
        }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
       
    }
}
