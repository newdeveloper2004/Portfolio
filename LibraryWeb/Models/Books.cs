using System.ComponentModel.DataAnnotations;

namespace LibraryWeb.Models
{
    public class Books
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        [Required]
        public int Price { get; set; }
               
    }

}
