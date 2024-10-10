namespace Dfe.Academies.Contracts.V4;
using System.Collections.Generic;

#pragma warning disable S1133
[Obsolete("This package is deprecated. Please use https://github.com/DFE-Digital/rsd-core-libs/pkgs/nuget/DfE.CoreLibs.Contracts instead.")]
#pragma warning restore S1133
[Serializable]
public class PagedDataResponse<TResponse> where TResponse : class
{

    public IEnumerable<TResponse> Data { get; set; }
    public PagingResponse Paging { get; set; }

    public PagedDataResponse() => Data = new List<TResponse>();

    public PagedDataResponse(IEnumerable<TResponse> data, PagingResponse pagingResponse)
    {
        Data = data;
        Paging = pagingResponse;
    }

    public PagedDataResponse(TResponse data) => Data = new List<TResponse> { data };

}

[Serializable]
public class PagingResponse
{
    public int Page { get; set; }
    public int RecordCount { get; set; }
    public string NextPageUrl { get; set; }
}
