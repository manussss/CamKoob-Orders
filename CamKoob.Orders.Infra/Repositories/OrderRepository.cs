namespace CamKoob.Orders.Infra.Repositories;

public class OrderRepository(OrdersContext context) : IOrderRepository
{
    public async Task CreateAsync(Order order)
    {
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
    }
}