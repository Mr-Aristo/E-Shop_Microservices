namespace CatalogAPI.Products.CreateProduct.Models.Endpoint;

public record CreateProductRequest(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);
