namespace Dfe.Academies.Contracts.Establishments;

using Dfe.Academies.Contracts.Trusts;

[Serializable]
public class EstablishmentDto
{

    public string Urn { get; set; }
    public string Name { get; set; }
    public string LocalAuthorityCode { get; set; }
    public string LocalAuthorityName { get; set; }
    public string OfstedRating { get; set; }
    public string OfstedLastInspection { get; set; }
    public string StatutoryLowAge { get; set; }
    public string StatutoryHighAge { get; set; }
    public string SchoolCapacity { get; set; }
    public string Pfi { get; set; }
    public string EstablishmentNumber { get; set; }
    public NameAndCodeDto Diocese { get; set; }
    public NameAndCodeDto EstablishmentType { get; set; }
    public NameAndCodeDto Gor { get; set; }
    public NameAndCodeDto PhaseOfEducation { get; set; }
    public NameAndCodeDto ReligiousCharacter { get; set; }
    public NameAndCodeDto ParliamentaryConstituency { get; set; }
    public CensusDto Census { get; set; }
    public MisEstablishmentDto MISEstablishment { get; set; }
    public AddressDto Address { get; set; }
}

[Serializable]
public class NameAndCodeDto
{
    public string Name { get; set; }
    public string Code { get; set; }
}


[Serializable]
public class MisEstablishmentDto
{
    public string DateOfLatestSection8Inspection { get; set; }
    public string InspectionEndDate { get; set; }

    public string OverallEffectiveness { get; set; }
    public string QualityOfEducation { get; set; }
    public string BehaviourAndAttitudes { get; set; }
    public string PersonalDevelopment { get; set; }
    public string EffectivenessOfLeadershipAndManagement { get; set; }

    public string EarlyYearsProvision { get; set; }
    public string SixthFormProvision { get; set; }
    public string Weblink { get; set; }
}

[Serializable]
public class CensusDto
{
    public string NumberOfPupils { get; set; }
    public string PercentageFsm { get; set; }
}
