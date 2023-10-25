using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Models
{
    public class Showtime
    {
        [Key]
        public int id { get; set; }
        public DateTime date { get; set; }
        public Movie movie { get; set; }
        public Cinema cinema { get; set; } 
        public int movieId { get; set; }
        public int cinemaId { get;set; }
    }
}
