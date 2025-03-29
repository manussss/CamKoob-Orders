namespace CamKoob.Orders.Application.DTOs;

public class GetOrderDTO
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public List<GetOrderItemDTO> Items { get; set; } = [];
}

public class GetOrderItemDTO
{
    public Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}