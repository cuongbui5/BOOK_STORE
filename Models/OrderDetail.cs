
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BOOK_STORE_DEMO.Models
{
    public class OrderDetail 
    {
        
        public int ShopOrderId { get; set; }
        public ShopOrder ShopOrder { get; set; }
       
        public int CartItemId { get; set; }
        public CartItem CartItem { get; set; }
    }
}
