using RRSolucoesFinanceiraUsers.Domain.Validation;

namespace RRSolucoesFinanceiraUsers.Domain.Entities;

public sealed class AddressEntity
{
    public int Id { get; }
    public Guid UserId { get; private set; }
    public string? Street { get; private set; }
    public int? Number { get; private set; }
    public string? District { get; private set; }
    public char? State { get; private set; }
    public string? City { get; private set; }
    public string? ZipCode { get; private set; }
    public string? ProofOfResidencePath { get; private set; }
    public DateTime DateUpload { get; private set; }
    public UserEntity User { get; set; }

    public AddressEntity()
    {
        
    }
    public AddressEntity(int id, string? street, int number, string? district, char state,
                         string? city, string? zipCode, string? proofOfResidencePath)
    {
        DomainExceptionValidation.When(id < 0, "Invalid value for id");
        Id = id;
        ValidateDomain(street, number, district, state, city, zipCode, proofOfResidencePath);
    }

    public AddressEntity(string? street, int number, string? district, char state, 
                         string? city, string? zipCode, string? proofOfResidencePath)
    {
        ValidateDomain(street, number, district, state, city, zipCode, proofOfResidencePath);

    }


    private void ValidateDomain(string? street, int number, string? district, char state, 
                                string? city, string? zipCode, string? proofOfResidencePath)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(street),
            "The street is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(district),
            "The district is required");

        DomainExceptionValidation.When(char.IsWhiteSpace(state),
            "The state is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(city),
            "The city is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(zipCode),
            "The zipCode is required");

        DomainExceptionValidation.When(proofOfResidencePath.Length > 255,
            "the file path is too large");

        DomainExceptionValidation.When(number < 0,
                "Invalid number value");

        Street = street;
        Number = number;
        District = district;
        State = state;
        City = city;
        ZipCode = zipCode;
        ProofOfResidencePath = proofOfResidencePath;
        DateUpload = DateTime.Now;
    }
    
    public void Update(Guid userId, string? street, int number, string? district, char state,
                         string? city, string? zipCode, string? proofOfResidencePath)
    {
        ValidateDomain(street, number, district, state, city, zipCode, proofOfResidencePath);
        UserId = userId;
    }
}
