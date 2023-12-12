using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QERH6L_HFT_2023241.Logic.Services;
using QERH6L_HFT_2023241.Models;
using QERH6L_HFT_2023241.Repository.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace QERH6L_HFT_2023241.Endpoint.Controllers
{
   
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;
        public CinemaController(CinemaService service)
        {
            this._cinemaService = service;
        }
        [Route("/cinemas/all")]
        [HttpGet]
        public List<Cinema> GetAll()
        {
            return _cinemaService.ReadAll().ToList();
        }
        [Route("/cinemas/delete/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            _cinemaService.Delete(id);
            return true;
        }
        [Route("/cinemas/create")]
        [HttpPost]
        public bool Create(Cinema cinema)
        {
            _cinemaService.Create(cinema);
            return true;
        }
        [Route("/cinemas/update")]
        [HttpPut]
        public bool Update(Cinema cinema) 
        {
            _cinemaService.Update(cinema);
            return true;
        }
        [Route("/cinemas/city/{city}")]
        [HttpGet]
        public IEnumerable<Cinema> GetCinemasByCity(string city)
        {
            return _cinemaService.GetCinemasByCity(city);
               
        }
    }
}
