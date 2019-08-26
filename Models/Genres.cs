using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeepMusic.Models
{
    public class Genres
    {
        [Key]
        public int Genres_ID { get; set; }
        public string Genre { get; set; }
        //public string Genre { get; set; }
        // public Albums Albums { get; set; }
    }
}
