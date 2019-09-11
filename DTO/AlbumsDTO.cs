using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DeepMusic.DTO
{
    public class AlbumsDTO
    {
        [Key]
        public int Album_ID { get; set; }
        [Required]
        public string ArtistName { get; set; }
        [Required]
        public string Track { get; set; }
        //[Required]
        //public string Album { get; set; }
        public string AlbumCoverPath { get; set; }

        public string Genre { get; set; }
        //  public Tracks Tracks { get; set; }






    }
}
