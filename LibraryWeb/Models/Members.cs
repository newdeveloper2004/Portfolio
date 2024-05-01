using System.ComponentModel.DataAnnotations;

namespace LibraryWeb.Models
{
    public class Members
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
