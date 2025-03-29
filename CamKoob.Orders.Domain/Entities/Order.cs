namespace CamKoob.Orders.Domain.Entities;

public class Order : Entity
{
    public string Code { get; private set; }
    public IEnumerable<OrderItem> Items { get; private set; } = [];
    public decimal TotalPrice { get; private set; }

    public Order(string code, IEnumerable<OrderItem> items)
    {
        Code = code;
        Items = items;
        TotalPrice = items.Sum(i => i.TotalPrice);
    }
}