using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BOOK_STORE_DEMO.Models
{
    public class ShopOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        public User User { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        
        public Address Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OrderDetail> OrderDetails { get; set;}

    }
}
