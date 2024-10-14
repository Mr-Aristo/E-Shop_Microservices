using BuildingBlock.CQRS;

namespace CatalogAPI.Products.CreateProduct.Models.Handler;
public record CreateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;