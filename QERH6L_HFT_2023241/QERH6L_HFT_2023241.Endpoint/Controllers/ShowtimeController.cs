using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QERH6L_HFT_2023241.Logic.Services;
using QERH6L_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QERH6L_HFT_2023241.Endpoint.Controllers
{
  
    [ApiController]
    public class ShowtimeController : ControllerBase
    {
        private ShowtimeService _showtimeService;
        public ShowtimeController(ShowtimeService service)
        {
            this._showtimeService = service;
        }
        [Route("/showtime/all")]
        [HttpGet]
        public List<Showtime> GetAll()
        {
            return _showtimeService.ReadAll().ToList();
        }
        [Route("/showtime/delete/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            _showtimeService.Delete(id);
            return true;
        }
        [Route("/showtime/create")]
        [HttpPost]
        public bool Create(Showtime showtime)
        {
            _showtimeService.Create(showtime);
            return true;
        }
        [Route("/showtime/update")]
        [HttpPut]
        public bool Update(Showtime showtime)
        {
            _showtimeService.Update(showtime);
            return true;
        }
        [Route("/showtime/movieName/{movieName}")]
        [HttpGet]
        public IEnumerable<Showtime> GetShowtimesByMovie(string movieName)
        {
            return _showtimeService.GetShowtimesByMovie(movieName);

        }
        [Route("/showtime/cinemaName/{cinemaName}")]
        [HttpGet]
        public IEnumerable<Showtime> GetShowtimesByCinema(string cinemaName)
        {
            return _showtimeService.GetShowtimesByCinema(cinemaName);

        }
        [Route("/showtime/date/{date}")]
        [HttpGet]
        public IEnumerable<Showtime> GetShowtimesByDateAfter(DateTime date)
        {
            return _showtimeService.GetShowtimesByDateAfter(date);

        }
    }
}
