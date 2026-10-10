namespace FridgementBackend.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public int Qty { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
