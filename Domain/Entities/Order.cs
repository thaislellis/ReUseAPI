using ReUseApi.Domain.Enums;
namespace ReUseApi.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public Order()
        {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        }
    }
}

