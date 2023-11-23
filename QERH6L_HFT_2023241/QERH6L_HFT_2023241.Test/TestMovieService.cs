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
            service = new MovieService(mock.Object);
            IEnumerable<Movie> moviesResult = service.GetMoviesByLength(100);
            Assert.AreEqual(2,moviesResult.Count());
           
        }
        [Test]
        public void TestCreateMovie()
        {
            Movie movie = new Movie() {id = 6, name = "Egy ropi naplója", category = "Gyerek/Vígjáték",length = 94};
            var mock = new Mock<IMovieRepository>();
            Movie movieRepoParameter = null;
            mock.Setup(m => m.Create(It.IsAny<Movie>()))
                .Callback<Movie>(m => movieRepoParameter = m);
            service = new MovieService(mock.Object);
            service.Create(movie);
           

            Assert.AreEqual(movie.id, movieRepoParameter.id);
            Assert.AreEqual(movie.name, movieRepoParameter.name);
            Assert.AreEqual(movie.category, movieRepoParameter.category);
            Assert.AreEqual(movie.length, movieRepoParameter.length);
        }
        [Test]
        public void TestReadMovie()
        {
            Movie movie = new Movie() { id = 1, length = 120, name = "Star Wars", category = "scifi" };
            var mock = new Mock<IMovieRepository>();
            mock.Setup(m => m.Read(It.IsAny<int>())).Returns(movie);
            service = new MovieService(mock.Object);
            Movie movieResult = service.Read(1);
            
            Assert.AreEqual(1, movieResult.id);
            Assert.AreEqual(120, movieResult.length);
            Assert.AreEqual("Star Wars", movieResult.name);
            Assert.AreEqual("scifi", movieResult.category);
        }
    }
}