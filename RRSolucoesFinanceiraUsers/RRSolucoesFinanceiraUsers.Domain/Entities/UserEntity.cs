using RRSolucoesFinanceiraUsers.Domain.Validation;

namespace RRSolucoesFinanceiraUsers.Domain.Entities;

public sealed class UserEntity
{
    public Guid Id { get; }
    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public DateOnly? BirthDate { get; private set; }
    public char? Sex { get; private set; }
    public string? PhotoPath { get; private set; }
    public DateTime RegistrationDate { get; private set; }
    public bool? IsRegistrationComplete { get; private set; }
    public AddressEntity? Address { get; set; }
    public DocumentEntity? Document { get; set; }
    public UserEntityRoles? Role { get; set; }
    public ICollection<PhoneEntity>? Phones { get; set; }

    public UserEntity()
    {

    }
    public UserEntity(Guid id, string name, string email, DateOnly birthDate, char sex, string photoPath,
                      AddressEntity address, DocumentEntity document, List<PhoneEntity> phones)
    {
        DomainExceptionValidation.When(Guid.Empty.Equals(id), "Invalid id value");
        Id = id;
        ValidateDomain(name, email, birthDate, sex, photoPath);
    }

    public UserEntity(string name, string email, DateOnly birthDate, char sex, string photoPath, AddressEntity address,
                      DocumentEntity document, List<PhoneEntity> phones, bool isRegistrationComplete)
    {
        ValidateDomain(name, email, birthDate, sex, photoPath);
        IsRegistrationComplete = isRegistrationComplete;
    }
    public UserEntity(string email, Guid id, DateTime createdAt, bool isRegistrationComplete)
    {
        DomainExceptionValidation.When(Guid.Empty.Equals(id), "Invalid id value");
        Id = id;
        RegistrationDate = createdAt;
        IsRegistrationComplete = isRegistrationComplete;
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
    }

    private void ValidateDomain(string email)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "The email is required");

        Email = email;
        RegistrationDate = DateTime.Now;
    }
}
