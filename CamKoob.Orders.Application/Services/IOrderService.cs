namespace CamKoob.Orders.Application.Services;

public interface IOrderService
{
    Task CreateAsync(CreateOrderDTO dto);
}