namespace sharp_01.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? Product { get; set; }
        public int Quantity { get; set; }
    }
}
