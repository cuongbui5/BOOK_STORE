using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BOOK_STORE_DEMO.Models
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Cart")]
        public int CartId { get; set; }
        
        public virtual Cart? Cart { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        
        public virtual Book? Book { get; set; }

        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
