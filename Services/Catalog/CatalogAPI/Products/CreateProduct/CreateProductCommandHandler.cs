using MediatR;

namespace CatalogAPI.Products.CreateProduct;

/*
 IRequest<T>
 IRequestHandler<TCommand,TResponse>
*/

//CQRS (MediatR) Command
public record CreateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : IRequest<CreateProductResult>;

public record CreateProductResult(Guid Id);


internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{

    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {

        throw new NotImplementedException();
    }
}
