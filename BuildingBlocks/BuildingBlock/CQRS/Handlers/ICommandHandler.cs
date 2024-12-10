using MediatR;

namespace BuildingBlock.CQRS.Handlers;

/*
 IRequest<T>
 IRequestHandler<TCommand,TResponse>
*/
public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{ }

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
where TCommand : ICommand<TResponse>//Bu ifade TCommand'ın  ICommand<TResponse> ile uyumlu bir tür olmasını zorunlu kılar.
where TResponse : notnull
{

}
