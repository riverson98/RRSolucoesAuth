using RRSolucoesFinanceiraUsers.Domain.Validation;
using System.Net;
using System.Reflection.Metadata;

namespace RRSolucoesFinanceiraUsers.Domain.Entities;

public sealed class UserEntity
{
    public int Id { get; }
    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public DateOnly? BirthDate { get; private set; }
    public char? Sex { get; private set; }
    public string? PhotoPath {  get; private set; }
    public DateTime RegistrationDate { get; private set; }
    public AddressEntity? Address { get; set; }
    public DocumentEntity? Document { get; set; }
    public UserEntityRoles Role { get; set; }
    public ICollection<PhoneEntity>? Phones { get; set; }

    public UserEntity()
    {
        
    }
    public UserEntity(int id, string name, string email, DateOnly birthDate, char sex, string photoPath,
                      AddressEntity address, DocumentEntity document, List<PhoneEntity> phones)
    {
        DomainExceptionValidation.When(id < 0, "Invalid id value");
        Id = id;
        ValidateDomain(name, email, birthDate, sex, photoPath);
    }

    public UserEntity(string name, string email, DateOnly birthDate, char sex, string photoPath, AddressEntity address,
                      DocumentEntity document, List<PhoneEntity> phones)
    {
        ValidateDomain(name, email, birthDate, sex, photoPath);
    }
    public UserEntity(string email)
    {
        ValidateDomain(email);
    }

    private void ValidateDomain(string name, string email, DateOnly birthDate, char sex, string photoPath)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "The name is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "The email is required");

        DomainExceptionValidation.When(char.IsWhiteSpace(sex),
            "The sex is required");

        DomainExceptionValidation.When(photoPath.Length > 255,
            "the file path is too large");

        DomainExceptionValidation.When(birthDate.Equals(DateOnly.MinValue),
            "The birth date is required");

        var today = DateOnly.FromDateTime(DateTime.Today);
        int age = today.Year - birthDate.Year;

        
        if (birthDate > today.AddYears(-age))
            age--;
        
        DomainExceptionValidation.When(age < 18,
            "User must be at least 18 years old");

        Name = name;
        Email = email;
        BirthDate = birthDate;
        PhotoPath = photoPath;
        RegistrationDate = DateTime.Now;
    }

    private void ValidateDomain(string email)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "The email is required");

        Email = email;
    }
}
