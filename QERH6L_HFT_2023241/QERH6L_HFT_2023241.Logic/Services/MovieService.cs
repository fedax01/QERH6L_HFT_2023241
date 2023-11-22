using QERH6L_HFT_2023241.Models;
using QERH6L_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Logic.Services
{
    public class MovieService
    {
        IMovieRepository movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public IEnumerable<Movie> ReadAll()
        {
            return movieRepository.ReadAll();
        }
        public void Create(Movie movie)
        {
            movieRepository.Create(movie);
        }
        public void Delete(int id)
        {
            movieRepository.Delete(id);
        }
        public Movie Read(int id)
        {
            return movieRepository.Read(id);
        }
        public void Update(Movie movie)
        {
            movieRepository.Update(movie);
        }
        public IEnumerable<Movie> GetMoviesByLength (int length)
        {
            return movieRepository.ReadAll()
                .Where(m => m.length > length)
                .ToList();
        }
    }
}
