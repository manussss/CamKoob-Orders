namespace CamKoob.Orders.Domain.Interfaces;

public interface IOrderRepository
{
    Task CreateAsync(Order order);
}