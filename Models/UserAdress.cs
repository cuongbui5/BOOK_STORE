using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOOK_STORE_DEMO.Models
{
    public class UserAdress
    {
      
        public int UserId { get; set; }
        public User User { get; set; }
       
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public Boolean IsDefault { get; set; } = true;
    }
}
