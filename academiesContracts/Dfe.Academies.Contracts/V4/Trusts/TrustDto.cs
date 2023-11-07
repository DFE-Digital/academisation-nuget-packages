namespace Dfe.Academies.Contracts.Trusts;

[Serializable]
public class TrustDto
{
    public string Name { get; set; }

    public string Ukprn { get; set; }

    public string CompaniesHouseNumber { get; set; }

    public string ReferenceNumber { get; set; }

    public AddressDto Address { get; set; }

}

[Serializable]
public class AddressDto
{
    public string Street { get; set; }

    public string Town { get; set; }

    public string County { get; set; }

    public string Postcode { get; set; }

    public string Locality { get; set; }

    public string Additional { get; set; }
}
