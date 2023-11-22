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

namespace QERH6L_HFT_2023241.Test
{
    public class TestCinemaService
    {
        CinemaContext context;
        ICinemaRepository repository;
        CinemaService service;

        [SetUp]
        public void Setup()
        {
            context = new CinemaContext();
            context.Database.EnsureCreated();
            repository = new CinemaRepository(context);
            service = new CinemaService(repository);
        }

        [Test]
        public void TestGetCinemasByCity()
        {
            IEnumerable<Cinema> cinemas = service.GetCinemasByCity("Budapest");
            Assert.AreEqual(2,cinemas.Count());
            Assert.AreEqual(1, cinemas.Where(n => n.name == "Sugár Mozi").Count());
            Assert.AreEqual(1, cinemas.Where(n => n.name == "Cinema City").Count());
        }
        [Test]
        public void TestCreateCinema()
        {
            Cinema cinema = new Cinema() { id = 4,name = "asd",city = "Szarvas",address = "asd utca"};
            service.Create(cinema);
            Cinema cinema2 = service.Read(4);
           
            Assert.AreEqual(4, cinema2.id);
            Assert.AreEqual("asd", cinema2.name);
            Assert.AreEqual("Szarvas", cinema2.city);
            Assert.AreEqual("asd utca", cinema2.address);
        }
    }
}