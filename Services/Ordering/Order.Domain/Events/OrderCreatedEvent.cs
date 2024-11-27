namespace Order.Domain.Events;

public record OrderCreatedEvent(Orders order) : IDomainEvent;

//domain event pattern