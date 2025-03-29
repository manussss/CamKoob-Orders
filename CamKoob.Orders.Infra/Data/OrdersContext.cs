namespace CamKoob.Orders.Infra.Data;

public class OrdersContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
    {
    }
}