namespace TraktApiSharp.Experimental.Responses
{
    public interface ITraktPaginationResponseHeaders
    {
        int? Page { get; set; }

        int? Limit { get; set; }

        int? PageCount { get; set; }

        int? ItemCount { get; set; }
    }
}
