﻿using QERH6L_HFT_2023241.Models;
using QERH6L_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Repository.Repositories
{
    internal class MovieRepository : IMovieRepository
    {
        private CinemaContext _cinemaCtx;
        public MovieRepository(CinemaContext cinemaContext)
        {
            this._cinemaCtx = cinemaContext;
        }

        public void Create(Movie item)
        {
            _cinemaCtx.Movies.Add(item);
            _cinemaCtx.SaveChanges();
        }

        public void Delete(int id)
        {
            Movie movie= _cinemaCtx.Movies.Where(m => m.id == id).FirstOrDefault();
            _cinemaCtx.Movies.Remove(movie);
            _cinemaCtx.SaveChanges();
        }

        public Movie Read(int id)
        {
            Movie movie = _cinemaCtx.Movies.Where(m => m.id == id).FirstOrDefault();
            return movie;
        }

        public IQueryable<Movie> ReadAll()
        {
            return _cinemaCtx.Movies;
        }

        public void Update(Movie item)
        {
            _cinemaCtx.SaveChanges();
        }
    }
}