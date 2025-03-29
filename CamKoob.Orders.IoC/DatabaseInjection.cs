namespace CamKoob.Orders.IoC;

public static class DatabaseInjection
{
    public static void AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<OrdersContext>(opt => opt.UseInMemoryDatabase("Orders"));
    }
}