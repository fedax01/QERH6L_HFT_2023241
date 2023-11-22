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
using System.Xml.Linq;
using Moq;

namespace QERH6L_HFT_2023241.Test
{
    public class TestMovieService
    {
        
        MovieService service;

        [Test]
        public void TestGetMoviesByLength()
        {
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie() { id = 1, length = 120, name = "Star Wars", category = "scifi" });
            movies.Add(new Movie() { id = 2, length = 150, name = "Vakáció", category = "vígjáték" });
            var mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.ReadAll()).Returns(movies.AsQueryable());
            IEnumerable<Movie> moviesResult = service.GetMoviesByLength(100);
            Assert.AreEqual(2,moviesResult.Count());
           
        }
        [Test]
        public void TestCreateMovie()
        {
            Movie movie = new Movie() {id = 6, name = "Egy ropi naplója", category = "Gyerek/Vígjáték",length = 94};
            service.Create(movie);
           Movie movie2 = service.Read(6);

            Assert.AreEqual(6, movie2.id);
            Assert.AreEqual("Egy ropi naplója", movie2.name);
            Assert.AreEqual("Gyerek/Vígjáték", movie2.category);
            Assert.AreEqual(94, movie2.length);
        }
        [Test]
        public void TestReadMovie()
        {
            Movie movie = service.Read(1);

            Assert.AreEqual(1, movie.id);
            Assert.AreEqual(120, movie.length);
            Assert.AreEqual("Star Wars", movie.name);
            Assert.AreEqual("scifi", movie.category);
        }
    }
}