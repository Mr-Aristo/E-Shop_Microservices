using Order.Application;
using Order.Infrastructure;
using Order.Infrastructure.Data.Extentions;
using OrderAPI; 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddIfrasturctureService(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync(); // This is for auto migration (update-database)
}


app.Run();
