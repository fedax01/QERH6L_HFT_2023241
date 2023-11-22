using QERH6L_HFT_2023241.Models;
using QERH6L_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Repository.Repositories
{
    public class ShowtimeRepository : IShowtimeRepository
    {
        private CinemaContext _cinemaCtx;

        public ShowtimeRepository(CinemaContext cinemaContext)
        {
            this._cinemaCtx = cinemaContext;
        }

        public void Create(Showtime item)
        {
            _cinemaCtx.Showtimes.Add(item);
            _cinemaCtx.SaveChanges();
        }

        public void Delete(int id)
        {
            Showtime showtime = _cinemaCtx.Showtimes.Where(s => s.id == id).FirstOrDefault();
            _cinemaCtx.Showtimes.Remove(showtime);
            _cinemaCtx.SaveChanges();
        }

       
        public Showtime Read(int id)
        {
            Showtime showtime = _cinemaCtx.Showtimes.Where(s => s.id == id).FirstOrDefault();
            return showtime;
        }

        public IQueryable<Showtime> ReadAll()
        {
            return _cinemaCtx.Showtimes;
        }

        public void Update(Showtime item)
        {
            _cinemaCtx.SaveChanges();
        }

    }
}
