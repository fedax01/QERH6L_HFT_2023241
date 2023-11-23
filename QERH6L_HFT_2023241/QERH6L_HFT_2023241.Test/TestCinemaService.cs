using NUnit.Framework;
using QERH6L_HFT_2023241.Models;
using QERH6L_HFT_2023241.Repository;
using System.Collections.Generic;
using System.Linq;
using System;
using QERH6L_HFT_2023241.Repository.Interfaces;
using QERH6L_HFT_2023241.Logic.Services;
using QERH6L_HFT_2023241.Repository.Repositories;
using System.Security.Cryptography.X509Certificates;
using Moq;

namespace QERH6L_HFT_2023241.Test
{
    public class TestCinemaService
    {
       
        CinemaService service;

       

        [Test]
        public void TestGetCinemasByCity()
        {
            List<Cinema> cinemas = new List<Cinema>();
            cinemas.Add(new Cinema() { id = 1, name = "Malom Mozi", address = "Deák Ferenc utca", city = "Kecskemét" });
            cinemas.Add(new Cinema() { id = 2, name = "Sugár Mozi", address = "Pillangó utca", city = "Budapest" });
            cinemas.Add(new Cinema() { id = 3, name = "Cinema City", address = "Malom utca", city = "Budapest" });
            var mock = new Mock<ICinemaRepository>();
            mock.Setup(c => c.ReadAll()).Returns(cinemas.AsQueryable());
            service = new CinemaService(mock.Object);
            IEnumerable<Cinema> cinemasResult = service.GetCinemasByCity("Budapest");
            Assert.AreEqual(2,cinemasResult.Count());
            Assert.AreEqual(1, cinemasResult.Where(n => n.name == "Sugár Mozi").Count());
            Assert.AreEqual(1, cinemasResult.Where(n => n.name == "Cinema City").Count());
        }
        [Test]
        public void TestCreateCinema()
        {
            var mock = new Mock<ICinemaRepository>();
            Cinema cinemaRepoParameter = null;
            mock.Setup(c => c.Create(It.IsAny<Cinema>()))
                .Callback<Cinema>(c => cinemaRepoParameter = c);
            service = new CinemaService(mock.Object);

            Cinema cinema = new Cinema() { id = 4,name = "asd",city = "Szarvas",address = "asd utca"};
            service.Create(cinema);
          
           
            Assert.AreEqual(cinema.id, cinemaRepoParameter.id);
            Assert.AreEqual(cinema.name, cinemaRepoParameter.name);
            Assert.AreEqual(cinema.city, cinemaRepoParameter.city);
            Assert.AreEqual(cinema.address, cinemaRepoParameter.address);
        }
    }
}