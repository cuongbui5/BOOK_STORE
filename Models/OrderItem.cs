using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOOK_STORE_DEMO.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("ShopOrder")]
        public int OrderId { get; set; }

        public virtual Order? Order { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }

        public virtual Book? Book { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public override string ToString()
        {
            return $"Order Item Details:\n" +
                   $"ID: {Id}\n" +
                   $"Order ID: {OrderId}\n" +
                   $"Book ID: {BookId}\n" +
                   $"Quantity: {Quantity}\n" +
                   $"Price: {Price:C}\n"; 
        }
       
    }
}
