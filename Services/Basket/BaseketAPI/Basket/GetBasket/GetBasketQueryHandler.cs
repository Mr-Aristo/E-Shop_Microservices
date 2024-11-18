using BuildingBlock.CQRS;
using BuildingBlock.CQRS.Handlers;

namespace BaseketAPI.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart Cart);

public class GetBasketQueryHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBa   sket(request.UserName, cancellationToken);

        return new GetBasketResult(basket);      
    }
}
