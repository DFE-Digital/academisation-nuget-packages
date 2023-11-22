namespace Dfe.Academies.Contracts.V4.Trusts;

using Dfe.Academies.Contracts.V4.Establishments;

[Serializable]
public class TrustDto
{
    public string Name { get; set; }

    public string Ukprn { get; set; }
    public NameAndCodeDto Type { get; set; }

    public string CompaniesHouseNumber { get; set; }

    public string ReferenceNumber { get; set; }

    public AddressDto Address { get; set; }

}
