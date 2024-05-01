using System.ComponentModel.DataAnnotations;

namespace LibraryWeb.Models
{
    public class LentBooks 
    {
        
        public int Id { get; set; } 
        
        public DateTime Lent_Date { get; set; }
        
        public DateTime Due_Date { get; set; }
       
        public int Member_Id {  get; set; }
        [Required]
        public int Is_Lent {  get; set; }
        
    }
}

