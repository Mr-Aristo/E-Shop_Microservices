
using FluentValidation;

namespace CatalogAPI.Products.UpdateProdcut;

#region Command-Result Records
public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price)
: ICommand<UpdateProductResult>;
public record UpdateProductResult(bool IsSuccess); 
#endregion




public class UpdateProductCommandHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var products = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (products == null)
        {
            throw new ArgumentException("Product is null");
        }

        products.Id = command.Id;
        products.Name = command.Name;
        products.Description = command.Description;
        products.ImageFile = command.ImageFile;
        products.Price = command.Price;
        products.Category = command.Category;

        session.Update(products);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}
