using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeepMusic.DTO
{
    public class GenresDTO
    {
        [Key]
        public int Genres_ID { get; set; }

        [Required]
        public string Genre { get; set; }
        //public string Genre { get; set; }
        // public Albums Albums { get; set; }
    }
}
