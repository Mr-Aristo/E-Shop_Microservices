

using BuildingBlock.Behaviors;
using Catalog.API.Data;

var builder = WebApplication.CreateBuilder(args);



//Add services  to the container.

//The reason of the typeof(Program).Assembly to provide to run commands and queriesd only in this progran.cs
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{   
    config.RegisterServicesFromAssembly(assembly);
    //Registration of Pipeline behavior
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));//<,> that mean generic
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();

builder.Services.AddMarten(options =>
{ 
    options.Connection(builder.Configuration.GetConnectionString("PostgreDataBase")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();



var app = builder.Build();
// Configure the HTTP request pipline.

app.UseExceptionHandler();
app.MapCarter();


app.Run();
 