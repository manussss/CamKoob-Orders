namespace CamKoob.Orders.IoC;

public static class DatabaseInjection
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrdersContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("OrdersConnection")));
    }
}