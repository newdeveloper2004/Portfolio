using System.ComponentModel.DataAnnotations;

namespace LibraryWeb.Models
{
    public class Users
    {
        [Key]
        public int user_id { get; set; }
        [Required]
        public string user_name { get; set; }
    }
}
