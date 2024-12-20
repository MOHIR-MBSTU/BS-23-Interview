using System.ComponentModel.DataAnnotations;

namespace InventoryTrackingSystem.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; } // Unique Identifier
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
