namespace CamKoob.Orders.Application.DTOs;

public class CreateOrderDTO
{
    public string Code { get; set; } = string.Empty;
    public List<CreateOrderItemDTO> OrderItems { get; set; } = [];
}

public class CreateOrderItemDTO
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}