
namespace CamKoob.Orders.Application.Queries;

public class OrderQuery(IConfiguration configuration) : IOrderQuery
{
    public async Task<IEnumerable<GetOrderDTO>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<GetOrderDTO> GetByIdAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }
}