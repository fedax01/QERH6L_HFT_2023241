using QERH6L_HFT_2023241.Models;
using QERH6L_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Logic.Services
{
    public class ShowtimeService
    {
        IShowtimeRepository showtimeRepository;
        public ShowtimeService(IShowtimeRepository showtimeRepository)
        {
            this.showtimeRepository = showtimeRepository;
        }
        public IEnumerable<Showtime> ReadAll()
        {
            return showtimeRepository.ReadAll();
        }
        public void Create(Showtime showtime)
        {
            showtimeRepository.Create(showtime);
        }
        public void Delete(int id)
        {
            showtimeRepository.Delete(id);
        }
        public Showtime Read(int id)
        {
            return showtimeRepository.Read(id);
        }
        public void Update(Showtime showtime)
        {
           showtimeRepository.Update(showtime);
        }
        public IEnumerable<Showtime> GetShowtimesByMovie(string movieName)
        {
           return showtimeRepository.ReadAll()
                .Where(n => n.movie.name == movieName)
                .ToList();
        }
        public IEnumerable<Showtime> GetShowtimesByCinema(string cinemaName)
        {
            return showtimeRepository.ReadAll()
                 .Where(n => n.cinema.name == cinemaName)
                 .ToList();
        }
        public IEnumerable<Showtime> GetShowtimesByDateAfter(DateTime date)
        {
            return showtimeRepository.ReadAll()
                .Where(d => d.date > date)
                .OrderBy(d => d.date)
                .Take(5)
                .ToList();
        }
    }
}
