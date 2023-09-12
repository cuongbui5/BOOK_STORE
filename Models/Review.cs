using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BOOK_STORE_DEMO.Models
{
    public class Review
    {
       
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int BookId { get; set; }
        public Book Book { get; set; }
        [MaxLength(100)]
        public string Comment { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        [DefaultValue(5)]
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
       
        
    }
}
