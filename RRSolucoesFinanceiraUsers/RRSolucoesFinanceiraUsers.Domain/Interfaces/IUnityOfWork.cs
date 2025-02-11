namespace RRSolucoesFinanceiraUsers.Domain.Interfaces;

public interface IUnityOfWork
{
    IAddressEntityRepository AddressEntityRepository { get; }
    IDocumentEntityRepository DocumentEntityRepository { get; }
    IPhoneEntityRepository PhoneEntityRepository { get; }
    IUserEntityRepository UserEntityRepository { get; }
    IUserEntityRolesRepository UserEntityRolesRepository { get; }
    Task CommitAsync();
}
