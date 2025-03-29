var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/v1/orders", async (
    [FromBody] CreateOrderDTO dto,
    [FromServices] IOrderService orderService) =>
{
    await orderService.CreateAsync(dto);

    return Results.Created();
})
.WithName("PostOrder")
.WithOpenApi();

app.MapGet("api/v1/orders", () =>
{
    
})
.WithName("GetOrders")
.WithOpenApi();

app.MapGet("api/v1/orders{orderId}", (Guid orderId) =>
{
    
})
.WithName("GetOrderById")
.WithOpenApi();

await app.RunAsync();