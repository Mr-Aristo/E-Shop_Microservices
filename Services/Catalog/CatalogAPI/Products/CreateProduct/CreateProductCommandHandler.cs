namespace CatalogAPI.Products.CreateProduct;



//IDocumentSession is member of MartenLibrary

internal class CreateProductCommandHandler (IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{

    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {

        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };


        //Save to database;
        // Marten lib.
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}
