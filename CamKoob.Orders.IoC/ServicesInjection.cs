namespace CamKoob.Orders.IoC;

public static class ServicesInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IOrderService, OrderService>();
    }
}