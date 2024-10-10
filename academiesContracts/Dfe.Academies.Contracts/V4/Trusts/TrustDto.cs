namespace Dfe.Academies.Contracts.V4.Trusts;

using Dfe.Academies.Contracts.V4.Establishments;

#pragma warning disable S1133
[Obsolete("This package is deprecated. Please use https://github.com/DFE-Digital/rsd-core-libs/pkgs/nuget/DfE.CoreLibs.Contracts instead.")]
#pragma warning restore S1133
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
