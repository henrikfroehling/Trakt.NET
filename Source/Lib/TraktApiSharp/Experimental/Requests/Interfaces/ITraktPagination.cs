namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    internal interface ITraktPagination
    {
        int? Page { get; set; }

        int? Limit { get; set; }
    }
}
