namespace ReUseApi.Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal PriceAtPurchase { get; set; }
       
        public OrderItem() 
        {
        Id = Guid.NewGuid();
        }
    }
}
