using RRSolucoesFinanceiraUsers.Domain.Validation;
using System.Xml.Linq;

namespace RRSolucoesFinanceiraUsers.Domain.Entities;

public sealed class UserEntity
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public DateOnly? BirthDate { get; private set; }
    public string? Sex { get; private set; }
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
    public UserEntity(string email, Guid id)
    {
        ValidateDomain(id, email);
    }

    public UserEntity(Guid id, string name, string email, DateOnly birthDate, string sex, string photoPath)
    {
        ValidateDomain(id, name, email, birthDate, sex, photoPath);
    }

    private void ValidateDomain(Guid id, string name, string email, DateOnly birthDate, string sex, string photoPath)
    {
        DomainExceptionValidation.When(Guid.Empty.Equals(id), "Invalid id value");

        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "The name is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "The email is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(sex),
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

        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        PhotoPath = photoPath;
        Sex = sex[0].ToString().ToUpper();
    }

    private void ValidateDomain(Guid id, string email)
    {
        DomainExceptionValidation.When(Guid.Empty.Equals(id), "Invalid id value");

        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "The email is required");

        //TODO quando o usuario esta completando seu cadastro a data de criacao esta sendo modificada
        Id = id;
        Email = email;
        RegistrationDate = DateTime.Now;
    }
}
