namespace R_RSolucoesFinanceirasAuth.Application.Messaging;

public interface IUserEventPublisher
{
    Task PublishUserCreatedAsync(string userId, string email, DateTime createdAt);
}
