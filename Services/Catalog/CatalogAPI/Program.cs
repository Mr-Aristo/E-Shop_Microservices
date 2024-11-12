var builder = WebApplication.CreateBuilder(args);



//Add services  to the container.

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    //The reason of the typeof(Program).Assembly to provide to run commands and queriesd only in this progran.cs
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(options =>
{ 
    options.Connection(builder.Configuration.GetConnectionString("PostgreDataBase")!);
}).UseLightweightSessions();


//Config. Validations
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();



// Configure the HTTP request pipline.

app.MapCarter();


app.Run();
 