using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BOOK_STORE_DEMO.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public ICollection<UserAdress> UserAdresses { get; set; }
    }
}
