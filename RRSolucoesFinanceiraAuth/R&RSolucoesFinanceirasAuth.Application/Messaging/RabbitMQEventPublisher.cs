using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Application.Events;

namespace R_RSolucoesFinanceirasAuth.Application.Messaging;

public class RabbitMQEventPublisher : IUserEventPublisher
{
    private readonly IBus _publish;
    private readonly ILogger<RabbitMQEventPublisher> _log;

    public RabbitMQEventPublisher(IBus publishEndpoint, ILogger<RabbitMQEventPublisher> log)
    {
        _publish = publishEndpoint;
        _log = log;
    }

    public async Task PublishUserCreatedAsync(string? userId, string? email, DateTime createdAt)
    {
        try
        {
            var userCreatedEvent = new UserCreatedEvent(userId, email, createdAt);

            _log.LogInformation("🚀 Publishing event to queue with the message: id:{0}, email:{1}", userId, email);

            await _publish.Publish(new UserCreatedEvent(userId, email, createdAt));

            _log.LogInformation("✅ Event sent successfully!");
        }
        catch (Exception ex)
        {
            _log.LogInformation("❌ something went wrong while publishing the event error:{0}", ex.Message);
        }
    }

}

