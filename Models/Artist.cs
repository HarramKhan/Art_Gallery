using System.ComponentModel.DataAnnotations;

namespace Art_Gallery.Models
{
    public class Artist
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string name { get; set; }
       

    }
}
