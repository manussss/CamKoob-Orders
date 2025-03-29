namespace CamKoob.Orders.Application.Queries;

public class OrderQuery(IConfiguration configuration) : IOrderQuery
{
    public async Task<IEnumerable<GetOrderDTO>> GetAllAsync()
    {
        IEnumerable<GetOrderDTO> orders = [];
        var query = @"
            SELECT 
                O.ID, O.CODE, O.TOTALPRICE, OI.PRODUCTNAME, OI.PRICE, OI.QUANTITY, OI.ID
            FROM 
                ORDERS O
            INNER JOIN ORDERITEMS OI ON O.ID = OI.ORDERID
        ";

        using (var connection = new SqlConnection(configuration.GetConnectionString("OrdersConnection")))
        {
            orders = await connection.QueryAsync<GetOrderDTO, GetOrderItemDTO, GetOrderDTO>(
                query,
                (order, orderItems) =>
                {
                    if (order.Items == null)
                        order.Items = new List<GetOrderItemDTO>();

                    order.Items.Add(orderItems);
                    return order;
                },
                splitOn: "PRODUCTNAME");
        }

        return orders;
    }

    public async Task<GetOrderDTO> GetByIdAsync(Guid orderId)
    {
        GetOrderDTO order;
        var query = @"
            SELECT 
                O.ID, O.CODE, O.TOTALPRICE, OI.PRODUCTNAME, OI.PRICE, OI.QUANTITY, OI.ID
            FROM 
                ORDERS O
            INNER JOIN ORDERITEMS OI ON O.ID = OI.ORDERID
            WHERE O.Id = @OrderId
        ";

        using (var connection = new SqlConnection(configuration.GetConnectionString("OrdersConnection")))
        {
            var result = await connection.QueryAsync<GetOrderDTO, GetOrderItemDTO, GetOrderDTO>(
                query,
                (order, orderItems) =>
                {
                    if (order.Items == null)
                        order.Items = new List<GetOrderItemDTO>();

                    order.Items.Add(orderItems);
                    return order;
                },
                param: new { OrderId = orderId },
                splitOn: "PRODUCTNAME"
            );

            order = result.FirstOrDefault();
        }

        return order;
    }
}