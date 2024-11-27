namespace Order.Domain.Abstractions;

public interface IDomainEvent : INotification
{
    Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.Now;

    public string EventType => GetType().AssemblyQualifiedName;
}

//Domain Events represent something that happened in the
//past and the other parts of the same service boundart
//same domain need to react ti these changes.
//Domain Event is a business event that occurs within the domain model.
//It often represents a side effect of a domain operation.
//Achieve consistency between aggreagates in the same domain. 