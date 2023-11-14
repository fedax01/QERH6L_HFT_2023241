using QERH6L_HFT_2023241.Models;
using QERH6L_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Logic.Services
{
    public class CinemaService
    {
        ICinemaRepository cinemaRepository;
        public CinemaService(ICinemaRepository cinemaRepository)
        {
            this.cinemaRepository = cinemaRepository;
        }
        public IEnumerable<Cinema> ReadAll()
        {
            return cinemaRepository.ReadAll();
        }
        public void Create(Cinema cinema)
        {
            cinemaRepository.Create(cinema);
        }
        public void Delete(int id)
        {
            cinemaRepository.Delete(id);
        }
        public Cinema Read(int id)
        {
            return cinemaRepository.Read(id);
        }
        public void Update(Cinema cinema)
        {
            cinemaRepository.Update(cinema);
        }
        public IEnumerable<Cinema> GetCinemasByCity(string city)
        {
            return cinemaRepository.ReadAll()
                .Where(c => c.city == city)
                .ToList();
        }
    }
}
