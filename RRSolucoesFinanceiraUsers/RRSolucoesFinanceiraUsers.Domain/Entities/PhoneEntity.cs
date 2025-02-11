using RRSolucoesFinanceiraUsers.Domain.Enums;
using RRSolucoesFinanceiraUsers.Domain.Validation;

namespace RRSolucoesFinanceiraUsers.Domain.Entities;

public sealed class PhoneEntity
{
    public int Id { get; }
    public int UserId { get; private set; }
    public TypeOfContact TypeOfContact { get; private set; }
    public string PhoneNumber { get; private set; }
    public UserEntity User { get; set; }

    public PhoneEntity()
    {
        
    }
    public PhoneEntity(int id, string phoneNumber, TypeOfContact typeOfContact)
    {
        DomainExceptionValidation.When(id < 0 , "invalid value for id");
        Id = id;
        ValidateDomain(phoneNumber, typeOfContact);
    }

    public PhoneEntity(string phoneNumber, TypeOfContact typeOfContact)
    {
        ValidateDomain(phoneNumber, typeOfContact);
    }

    private void ValidateDomain(string phoneNumber, TypeOfContact typeOfContact)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(phoneNumber),
            "The phone number is required");

        DomainExceptionValidation.When(phoneNumber.Length > 12,
            "Invalid value for phone number");
        
        DomainExceptionValidation.When(typeOfContact < 0,
            "Invalid value for type of contact");

        PhoneNumber = phoneNumber;
        TypeOfContact = typeOfContact;
    }

    public void Update(string phoneNumber, TypeOfContact typeOfContact, int userId)
    {
        ValidateDomain(phoneNumber, typeOfContact);
        UserId = userId;
    }
}
