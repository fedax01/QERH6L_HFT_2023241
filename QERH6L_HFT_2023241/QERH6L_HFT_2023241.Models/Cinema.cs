using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QERH6L_HFT_2023241.Models
{
    public class Cinema
    {
        [Key]
        public int id { get; set; }
        public  string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }

       

    }
}
