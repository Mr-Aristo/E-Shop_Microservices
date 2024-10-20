using CatalogAPI.Products.CreateProduct.Models.Endpoint;
using CatalogAPI.Products.CreateProduct.Models.Handler;

namespace CatalogAPI.Products.CreateProduct;

//Carter library installed for endpoints.
public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateProductRequest request, ISender sender) =>//ISender from mediator to send command
        {
            var command = request.Adapt<CreateProductCommand>();//mapster for mapping and to other class

            var result = await sender.Send(command);
            var response = result.Adapt<CreateProductResponse>();

            return Results.Created($"/products/{response.Id}", response);
        })
            //CarterExtentions for endpoint
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");

    }
}
