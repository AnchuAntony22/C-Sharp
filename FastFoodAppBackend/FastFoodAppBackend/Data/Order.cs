namespace FastFoodAppBackend.Data
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
