using Order.Application;
using Order.Infrastructure;
using OrderAPI; 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddIfrasturctureService(builder.Configuration)
    .AddAPIServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
