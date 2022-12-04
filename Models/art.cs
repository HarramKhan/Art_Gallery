using System.ComponentModel.DataAnnotations;

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

    }
}
