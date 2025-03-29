var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("api/v1/orders", (CreateOrderDTO dto) =>
{
    var orderItems = dto.OrderItems.Select(x => new OrderItem(x.ProductName, x.Price, x.Quantity)).ToList();
    var order = new Order(dto.Code, orderItems);
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