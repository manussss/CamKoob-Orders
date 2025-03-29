namespace CamKoob.Orders.Application.DTOs;

public class CreateOrderDTO
{
    public string CustomerId { get; set; } = string.Empty;
    public string ProductId { get; set; } = string.Empty;
    public int Quantity { get; set; }
}