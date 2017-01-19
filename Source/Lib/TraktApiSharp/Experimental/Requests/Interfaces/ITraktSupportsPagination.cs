namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    internal interface ITraktSupportsPagination
    {
        int? Page { get; set; }

        int? Limit { get; set; }
    }
}
