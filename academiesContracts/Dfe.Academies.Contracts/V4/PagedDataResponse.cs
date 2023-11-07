namespace Dfe.Academies.Contracts.V4;
using System.Collections.Generic;

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
public class PagingResponse
{
    public int Page { get; set; }
    public int RecordCount { get; set; }
    public string NextPageUrl { get; set; }
}
