namespace CamKoob.Orders.Application.Queries;

public interface IOrderQuery
{
    Task<GetOrderDTO> GetByIdAsync(Guid orderId);
    Task<IEnumerable<GetOrderDTO>> GetAllAsync();
}