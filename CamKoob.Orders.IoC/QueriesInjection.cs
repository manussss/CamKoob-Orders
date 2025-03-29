namespace CamKoob.Orders.IoC;

public static class QueriesInjection
{
    public static void AddQueries(this IServiceCollection services)
    {
        services.AddScoped<IOrderQuery, OrderQuery>();
    }
}