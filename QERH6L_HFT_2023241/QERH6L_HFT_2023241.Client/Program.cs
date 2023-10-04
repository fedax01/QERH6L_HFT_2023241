using QERH6L_HFT_2023241.Models;
using QERH6L_HFT_2023241.Repository;
using System;

namespace QERH6L_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CinemaContext())
            {
                Cinema cinema = new Cinema();
                cinema.id = 1;
                cinema.name = "CinemaCity";
                cinema.address = "József körút";
                cinema.city = "Kiskunhalas";
                context.Cinemas.Add(cinema);    
                context.SaveChanges();
            }
        }
    }
}
