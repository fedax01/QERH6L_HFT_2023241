using QERH6L_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Repository
{
    public class CinemaContext : DbContext
    {
        public CinemaContext() : base("CinemaContext") { }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
       
    }
}
