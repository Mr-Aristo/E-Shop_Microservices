namespace Order.Domain.Events;

public record OrderUpdatedEvent(Orders order) : IDomainEvent;

