namespace Dfe.Academies.Contracts.V4.Trusts;

[Serializable]
public class TrustDto
{
    public string Name { get; set; }

    public string Ukprn { get; set; }

    public string CompaniesHouseNumber { get; set; }

    public string ReferenceNumber { get; set; }

    public AddressDto Address { get; set; }

}
