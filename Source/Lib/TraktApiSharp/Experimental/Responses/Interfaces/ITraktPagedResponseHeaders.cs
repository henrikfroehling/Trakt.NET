namespace TraktApiSharp.Experimental.Responses.Interfaces.Base
{
    public interface ITraktPagedResponseHeaders
    {
        int? Page { get; set; }

        int? Limit { get; set; }

        int? PageCount { get; set; }

        int? ItemCount { get; set; }
    }
}
