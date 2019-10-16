using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DeepMusic.Models
{// This is part of making the database, it's used with the Entity Framework Core commands, like add-migration.

    // Here we add in all the fields we are using.
    public class Albums
    {
        [Key]

        public int Album_ID { get; set; }
        public string ArtistName { get; set; }
        public string Track { get; set; }
        //public string Album { get; set; }
        public string AlbumCoverPath { get; set; }
        public string Genre { get; set; }
        public Tracks Tracks { get; set; }






    }
}
