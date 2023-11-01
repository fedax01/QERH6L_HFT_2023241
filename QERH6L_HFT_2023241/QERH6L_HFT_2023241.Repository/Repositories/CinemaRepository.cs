using QERH6L_HFT_2023241.Models;
using QERH6L_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Repository.Repositories
{
    internal class CinemaRepository : ICinemaRepository
    {
        private CinemaContext _cinemaCtx;
        public CinemaRepository(CinemaContext cinemaContext)
        {
            this._cinemaCtx = cinemaContext;
        }
        public void Create(Cinema item)
        {
            _cinemaCtx.Cinemas.Add(item);
            _cinemaCtx.SaveChanges();
        }

        public void Delete(int id)
        {
            Cinema cinema = _cinemaCtx.Cinemas.Where(c => c.id == id).FirstOrDefault();
            _cinemaCtx.Cinemas.Remove(cinema);
            _cinemaCtx.SaveChanges();
        }

        public Cinema Read(int id)
        {
            Cinema cinema = _cinemaCtx.Cinemas.Where(c => c.id == id).FirstOrDefault();
            return cinema;
        }

        public IQueryable<Cinema> ReadAll()
        {
             return _cinemaCtx.Cinemas;
        }

        public void Update(Cinema item)
        {
            _cinemaCtx.SaveChanges();
        }
    }
}
