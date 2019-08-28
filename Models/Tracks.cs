using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DeepMusic.Models
{
    public class Tracks
    {
        [Key]
        public int Track_ID { get; set; }
        public string ArtistName { get; set; }
        //public string TrackName { get; set; }
        public string Album { get; set; }
        public string Track { get; set; }
        //public string AlbumCoverPath { get; set; }
        public int Time { get; set; }
        public string Genre { get; set; }
        public Genres Genres { get; set; }




    }
}
