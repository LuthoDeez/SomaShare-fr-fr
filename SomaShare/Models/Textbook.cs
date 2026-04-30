using System.ComponentModel.DataAnnotations;

namespace SomaShare.Models
{
    public class Textbook
    {
        [Key]
        public int TextbookId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Condition { get; set; } 
        public decimal Price { get; set; }
        public string Campus { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime DatePosted { get; set; }

        // Foreign Key
        public string SellerId { get; set; }
        public ApplicationUser Seller { get; set; }

        // Navigation
        public ICollection<Offer> Offers { get; set; } = new List<Offer>();
    }
}
