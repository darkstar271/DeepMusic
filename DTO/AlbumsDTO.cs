using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DeepMusic.DTO
{/// <summary>
/// This DTO uses System.ComponentModel.DataAnnotations, which means you can enforce data entry of a required  type or other attributes,
/// like for "ArtistName" it has the Required Attribute, data has to be entered or "The ArtistName field is required.    " will be shown.
/// DTO's can also be used to keep sensitive information internal to the program.
/// https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netframework-4.8
/// </summary>
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
