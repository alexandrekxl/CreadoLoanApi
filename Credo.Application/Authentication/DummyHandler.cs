using Credo.Domain.UsersAggregate.Events;
using MediatR;

namespace Credo.Application.Authentication
{
    public class DummyHandler : INotificationHandler<UserCreated>
    {
        public Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
