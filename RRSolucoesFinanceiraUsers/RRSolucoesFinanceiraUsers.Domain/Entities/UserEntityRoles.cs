using RRSolucoesFinanceiraUsers.Domain.Enums;
using RRSolucoesFinanceiraUsers.Domain.Validation;
using System.Data;

namespace RRSolucoesFinanceiraUsers.Domain.Entities;

public sealed class UserEntityRoles
{
    public int Id { get; private set; }
    public  Roles Roles { get; private set; }
    public bool RequiredAddress { get; private set; }
    public bool RequiredPhone { get; private set; }
    public bool RequiredDocument { get; private set; }
    public int UserId {  get; private set; }
    public UserEntity User { get; set; }

    public UserEntityRoles()
    {
        
    }
    public UserEntityRoles(int id, bool requiredAddress, bool requiredPhone, bool requiredDocument, Roles roles)
    {
        DomainExceptionValidation.When(id < 0, "Invalid id value");
        DomainExceptionValidation.When(roles < 0, "Invalid value for roles");
        Id = id;
        RequiredAddress = requiredAddress;
        RequiredPhone = requiredPhone;
        RequiredDocument = requiredDocument;
        Roles = roles;
    }

    public UserEntityRoles(bool requiredAddress, bool requiredPhone, bool requiredDocument, Roles roles)
    {
        DomainExceptionValidation.When(roles < 0, "Invalid value for roles");
        RequiredAddress = requiredAddress;
        RequiredPhone = requiredPhone;
        RequiredDocument = requiredDocument;
        Roles = roles;
    }

    public void Update(bool requiredAddress, bool requiredPhone, bool requiredDocument, Roles roles, int userId)
    {
        DomainExceptionValidation.When(roles < 0, "Invalid value for roles");
        RequiredAddress = requiredAddress;
        RequiredPhone = requiredPhone;
        RequiredDocument = requiredDocument;
        Roles = roles;
        UserId = userId;
    }
}
