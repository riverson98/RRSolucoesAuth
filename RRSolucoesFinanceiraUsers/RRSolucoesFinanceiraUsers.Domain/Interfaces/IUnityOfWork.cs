namespace RRSolucoesFinanceiraUsers.Domain.Interfaces;

public interface IUnityOfWork<T>
{
    IAddressEntityRepository AddressEntityRepository { get; }
    IDocumentEntityRepository DocumentEntityRepository { get; }
    IPhoneEntityRepository PhoneEntityRepository { get; }
    IUserEntityRepository UserEntityRepository { get; }
    IUserEntityRolesRepository UserEntityRolesRepository { get; }
    IRepository<T> Repository { get; }
    Task CommitAsync();
}
