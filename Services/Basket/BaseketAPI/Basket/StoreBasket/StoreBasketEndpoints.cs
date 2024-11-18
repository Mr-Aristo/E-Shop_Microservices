
namespace BaseketAPI.Basket.StoreBasket;
public record StoreBasketRequest(ShoppingCart Cart);
public record StoreBasketResponse(string UserName);

public class StoreBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket-store", async (StoreBasketRequest request, ISender sender) =>
        {

            var command = request.Adapt<StoreBasketCommand>();

            var result = await sender.Send(command);

            var response = request.Adapt<StoreBasketResponse>();

            return Results.Created($"/basket-store/{response.UserName}", response);

        })
        .WithName("CreatBasket")
        .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Basket")
        .WithDescription("Create Basket");
    }
}
