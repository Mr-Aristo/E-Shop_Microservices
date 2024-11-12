

using BuildingBlock.Behaviors;
using Catalog.API.Data;

var builder = WebApplication.CreateBuilder(args);



//Add services  to the container.

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    //The reason of the typeof(Program).Assembly to provide to run commands and queriesd only in this progran.cs
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    //Registration of Pipeline behavior
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));//<,> that mean generic
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddMarten(options =>
{ 
    options.Connection(builder.Configuration.GetConnectionString("PostgreDataBase")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();



var app = builder.Build();



// Configure the HTTP request pipline.

app.MapCarter();


app.Run();
 