
namespace CatalogAPI.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string Category): IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);
internal class GetProductByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> log) :
    IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        log.LogInformation("Get product by category called {@query}",query);

        var products = await session.Query<Product>().Where(x=> x.Category.Contains(query.Category)).ToListAsync();    

        return new GetProductByCategoryResult(products);
    }
}
