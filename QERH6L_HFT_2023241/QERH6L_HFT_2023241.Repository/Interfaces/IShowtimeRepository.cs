using QERH6L_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Repository.Interfaces
{
    internal interface IShowtimeRepository : IRepository<Showtime>
    {
        IQueryable<Showtime> GetAllByMovieName(string movieName);
    }
}
