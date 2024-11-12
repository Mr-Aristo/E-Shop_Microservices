namespace CatalogAPI.Products.GetProducts;

//public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
public record GetProductsRequest();
public record GetProductsResponse(IEnumerable<Product> Products);

public class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProductQuery());
            var response = result.Adapt<GetProductsResponse>();//mapster

            return Results.Ok(response);
        }).WithName("GetProduct")
            .Produces<GetProductsResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product")
            .WithDescription("Get Product"); 
    }
}
