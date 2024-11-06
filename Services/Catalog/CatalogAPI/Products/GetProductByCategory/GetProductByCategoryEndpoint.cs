
using CatalogAPI.Products.GetProducts;
using NetTopologySuite.Utilities;

namespace CatalogAPI.Products.GetProductByCategory;

public record class GetProductByCategoryResponse(IEnumerable<Product> Products);
public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products-with-category/{Category}", async (string Category , ISender sender) =>
        {
            var result = await sender.Send(new GetProductByCategoryQuery(Category)); //from handler 
            var response = result.Adapt<GetProductByCategoryResponse>();

            return response;
        }).WithName("GetProductByCategory")
            .Produces<GetProductsResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Category")
            .WithDescription("Get Product By Category");
    }
}
