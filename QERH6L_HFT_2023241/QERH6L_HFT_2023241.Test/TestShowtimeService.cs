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
    public class TestsShowtimeService
    {
        ShowtimeService service;
        


        [Test]
        public void TestGetShowtimesByMovie()
        {
            List<Showtime> showtimes = new List<Showtime>();
            showtimes.Add(new Showtime() { id = 1, date = new DateTime(2018, 1, 26), movieId = 1, cinemaId = 2, movie = new Movie() {name = "Star Wars"} });
            showtimes.Add(new Showtime() { id = 2, date = new DateTime(2012, 8, 17), movieId = 2, cinemaId = 3,  movie = new Movie() { name = "Star Wars" } });
            showtimes.Add(new Showtime() { id = 3, date = new DateTime(2016, 3, 9), movieId = 1, cinemaId = 3 , movie = new Movie() { name = "Titanik" } });  
      
            var mock = new Mock<IShowtimeRepository>();
            mock.Setup(s => s.ReadAll()).Returns(showtimes.AsQueryable());
            service = new ShowtimeService(mock.Object);
            IEnumerable<Showtime> showtimeResult = service.GetShowtimesByMovie("Star Wars");
            Assert.AreEqual(2, showtimeResult.Count());
          
            
        }

        [Test]
        public void TestGetShowtimesByCinema()
        {
            List<Showtime> showtimes = new List<Showtime>();
            showtimes.Add(new Showtime() { id = 1, date = new DateTime(2018, 1, 26), movieId = 1, cinemaId = 2, cinema = new Cinema() { name = "Sugár Mozi" } });
            showtimes.Add(new Showtime() { id = 2, date = new DateTime(2012, 8, 17), movieId = 2, cinemaId = 3, cinema = new Cinema() { name = "Cinema City" } });
            showtimes.Add(new Showtime() { id = 3, date = new DateTime(2016, 3, 9), movieId = 1, cinemaId = 3, cinema = new Cinema() { name = "Cinema City" } });

            var mock = new Mock<IShowtimeRepository>();
            mock.Setup(s => s.ReadAll()).Returns(showtimes.AsQueryable());
            service = new ShowtimeService(mock.Object);
            IEnumerable<Showtime> showtimesResult = service.GetShowtimesByCinema("Cinema City");
            Assert.AreEqual(2, showtimesResult.Count());

        }
        [Test]
        public void TestGetShowtimesByDateAfter()
        {
            List<Showtime> showtimes = new List<Showtime>();
            showtimes.Add(new Showtime() { id = 1, date = new DateTime(2018, 1, 26), movieId = 1, cinemaId = 2});
            showtimes.Add(new Showtime() { id = 2, date = new DateTime(2012, 8, 17), movieId = 2, cinemaId = 3});
            showtimes.Add(new Showtime() { id = 3, date = new DateTime(2016, 3, 9), movieId = 1, cinemaId = 3});
            var mock = new Mock<IShowtimeRepository>();
            mock.Setup(s => s.ReadAll()).Returns(showtimes.AsQueryable());
            service = new ShowtimeService(mock.Object);
            IEnumerable<Showtime> showtimesResult = service.GetShowtimesByDateAfter(new DateTime(2009,3,5));
            Assert.AreEqual(3, showtimesResult.Count());
            
        }
        [Test]
        public void TestCreateShowtime()
        {
            Showtime showtime = new Showtime() {id = 5, date = new DateTime(2023,11,5), movieId = 1, cinemaId = 1};
            var mock = new Mock<IShowtimeRepository>();
            Showtime showtimeRepoParameter = null;
            mock.Setup(m => m.Create(It.IsAny<Showtime>()))
                .Callback<Showtime>(m => showtimeRepoParameter = m);
            service = new ShowtimeService(mock.Object);
            service.Create(showtime);

            Assert.AreEqual(showtime.id, showtimeRepoParameter.id);
            Assert.AreEqual(showtime.date, showtimeRepoParameter.date);
            Assert.AreEqual(showtime.movieId, showtimeRepoParameter.movieId);
            Assert.AreEqual(showtime.cinemaId,showtimeRepoParameter.cinemaId);
        }
        [Test]
        public void TestReadShowtime()
        {
            Showtime showtime = new Showtime() { id = 5, date = new DateTime(2023, 11, 5), movieId = 1, cinemaId = 1 };
            var mock = new Mock<IShowtimeRepository>();
            Showtime showtimeRepoParameter = null;
            mock.Setup(m => m.Read(It.IsAny<int>()))
                .Returns(showtime);
            service = new ShowtimeService(mock.Object);
            Showtime showtimeResult = service.Read(1);

            Assert.AreEqual(5, showtimeResult.id);
            Assert.AreEqual(new DateTime(2023, 11, 5), showtimeResult.date);
            Assert.AreEqual(1, showtimeResult.movieId);
            Assert.AreEqual(1, showtimeResult.cinemaId);
        }
    }
}