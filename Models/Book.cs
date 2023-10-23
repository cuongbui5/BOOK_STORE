using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BOOK_STORE_DEMO.Dtos;

namespace BOOK_STORE_DEMO.Models
{
    public class Book
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Author { get; set; }
        public DateTime PublishDate { get; set; }

        public string? Publisher { get; set; }
        public string ?ImageCover { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category ?Category { get; set; }

      
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
