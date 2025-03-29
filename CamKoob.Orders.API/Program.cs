var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddQueries();

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

app.MapGet("api/v1/orders", async ([FromServices] IOrderQuery orderQuery) =>
{
    var orders = await orderQuery.GetAllAsync();

    return Results.Ok(orders);
})
.WithName("GetOrders")
.WithOpenApi();

app.MapGet("api/v1/orders{orderId}", async (
    Guid orderId,
    [FromServices] IOrderQuery orderQuery) =>
{
   var order = await orderQuery.GetByIdAsync(orderId);
   
   if (order is null)
       return Results.NotFound();

    return Results.Ok(order);
})
.WithName("GetOrderById")
.WithOpenApi();

await app.RunAsync();