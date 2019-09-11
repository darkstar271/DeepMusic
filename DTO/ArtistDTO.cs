using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DeepMusic.DTO
{
    public class ArtistDTO
    {
        [Key]
        public int Artist_ID { get; set; }
        [Required]
        public string ArtistName { get; set; }
        [Required]
        //public string TrackName { get; set; }
        public string Album { get; set; }
        //[Required]
        public string AlbumCoverPath { get; set; }
        public string Genre { get; set; }
        public AlbumsDTO Albums { get; set; }





    }
}
