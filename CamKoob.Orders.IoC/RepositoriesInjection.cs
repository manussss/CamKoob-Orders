namespace CamKoob.Orders.IoC;

public static class RepositoriesInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IOrderRepository, OrderRepository>();
    }
}