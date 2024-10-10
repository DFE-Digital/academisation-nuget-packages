namespace Dfe.Academies.Contracts.V4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable S1133
[Obsolete("This package is deprecated. Please use https://github.com/DFE-Digital/rsd-core-libs instead.")]
#pragma warning restore S1133
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