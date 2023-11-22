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
    public class TestsShowtimeService
    {
        CinemaContext context;
        IShowtimeRepository showtimeRepository;
        ShowtimeService service;
        

        [SetUp]
        public void Setup()
        {
            context = new CinemaContext();
            context.Database.EnsureCreated();
            showtimeRepository = new ShowtimeRepository(context);
            service = new ShowtimeService(showtimeRepository);
        }
        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public void TestGetShowtimesByMovie()
        {
            IEnumerable<Showtime> showtimes = service.GetShowtimesByMovie("Star Wars");
            Assert.AreEqual(2,showtimes.Count());
            
        }

        [Test]
        public void TestGetShowtimesByCinema()
        {
            IEnumerable<Showtime> showtimes = service.GetShowtimesByCinema("Cinema City");
            Assert.AreEqual(2, showtimes.Count());

        }
        [Test]
        public void TestGetShowtimesByDateAfter()
        {
            IEnumerable<Showtime> showtimes = service.GetShowtimesByDateAfter(new DateTime(2009,3,5));
            Assert.AreEqual(3, showtimes.Count());
            Assert.AreEqual(new DateTime(2012, 8, 17), showtimes.ToArray()[0].date);
        }
        [Test]
        public void TestCreateShowtime()
        {
            Showtime showtime = new Showtime() {id = 5, date = new DateTime(2023,11,5), movieId = 1, cinemaId = 1};
            service.Create(showtime);
            Showtime showtime2 = service.Read(5);

            Assert.AreEqual(5, showtime2.id);
            Assert.AreEqual(new DateTime(2023, 11, 5), showtime2.date);
            Assert.AreEqual(1, showtime2.movieId);
            Assert.AreEqual(1, showtime2.cinemaId);
        }
        [Test]
        public void TestReadShowtime()
        {
            Showtime showtime2 = service.Read(1);

            Assert.AreEqual(1, showtime2.id);
            Assert.AreEqual(new DateTime(2018, 1, 26), showtime2.date);
            Assert.AreEqual(1, showtime2.movieId);
            Assert.AreEqual(2, showtime2.cinemaId);
        }
    }
}