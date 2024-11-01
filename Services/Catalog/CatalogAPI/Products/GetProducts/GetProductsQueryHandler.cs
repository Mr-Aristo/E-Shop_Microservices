
namespace CatalogAPI.Products.GetProducts;

//public record GetProductQuery(int? PageNumber = 1, int? PageSize ) : IQuery<GetProductResult>;
public record GetProductQuery() : IQuery<GetProductResult>;
public record GetProductResult(IEnumerable<Product> Products);
internal class GetProductsQueryHandler
    (IDocumentSession session,ILogger<GetProductsQueryHandler> log)//IDocumentsession from marten library
    : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        log.LogInformation("GetHandler.Handle called with {@Query}",query);

        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        return new GetProductResult(products);
    }
}
