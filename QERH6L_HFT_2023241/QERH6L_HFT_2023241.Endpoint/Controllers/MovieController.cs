using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QERH6L_HFT_2023241.Logic.Services;
using QERH6L_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace QERH6L_HFT_2023241.Endpoint.Controllers
{
    
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieService _movieService;
        public MovieController(MovieService service)
        {
            this._movieService = service;
        }
        [Route("/movie/all")]
        public List<Movie> GetAll()
        {
            return _movieService.ReadAll().ToList();
        }
        [Route("/movie/delete/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            _movieService.Delete(id);
            return true;
        }
        [Route("/movie/create")]
        [HttpPost]
        public bool Create(Movie movie)
        {
            _movieService.Create(movie);
            return true;
        }
        [Route("/movie/update")]
        [HttpPut]
        public bool Update(Movie movie)
        {
            _movieService.Update(movie);
            return true;
        }
        [Route("/movie/length/{length}")]
        public IEnumerable<Movie> GetMoviesByLength(int length)
        {
            return _movieService.GetMoviesByLength(length);

        }
    }
}
