namespace R_RSolucoesFinanceirasAuth.Application.Interfaces;

public interface IUserEventPublish
{
    Task PublishUserCreatedAsync(Guid userId, string email);
}
