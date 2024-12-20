namespace InventoryTrackingSystem.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime Timestamp { get; set; }
        public string ChangeType { get; set; } // Addition/Deduction
        public int Quantity { get; set; }
        public string User { get; set; }
    }
}
