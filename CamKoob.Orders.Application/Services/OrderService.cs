namespace CamKoob.Orders.Application.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    public async Task CreateAsync(CreateOrderDTO dto)
    {
        var orderItems = dto.OrderItems.Select(x => new OrderItem(x.ProductName, x.Price, x.Quantity)).ToList();
        var order = new Order(dto.Code, orderItems);
        
        await orderRepository.CreateAsync(order);
    }
}