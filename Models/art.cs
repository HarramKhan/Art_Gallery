using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_Gallery.Models
{
    public class art
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string URL { get; set; }
        [Required]
        public int price { get; set; }

        [ForeignKey("ArtArtist")]
        public int ArtistID { get; set; }
        public virtual Artist ArtArtist { get; set; }


    }
}
