namespace CatalogAPI.Products.DeleteProduct.Models.Handler;


public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
