using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public int length { get; set; }
        public string name { get; set; }  
        public string category { get; set; }
        [JsonIgnore]
        public virtual List<Showtime> showtimes { get; set; }
    }
}
