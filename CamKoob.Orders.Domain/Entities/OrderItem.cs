namespace CamKoob.Orders.Domain.Entities;

public class OrderItem : Entity
{
    public Guid OrderId { get; private set; }
    public Order? Order { get; private set; }
    public string ProductName { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public decimal TotalPrice => Price * Quantity;

    public OrderItem(string productName, decimal price, int quantity)
    {
        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }
}