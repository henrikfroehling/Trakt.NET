namespace TraktApiSharp.Experimental.Responses
{
    internal interface ITraktPaginationResponseHeaders
    {
        int? Page { get; set; }

        int? Limit { get; set; }

        int? PageCount { get; set; }

        int? ItemCount { get; set; }
    }
}
