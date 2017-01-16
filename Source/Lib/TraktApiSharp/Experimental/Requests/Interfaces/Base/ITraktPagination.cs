namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    internal interface ITraktPagination
    {
        int? Page { get; set; }

        int? Limit { get; set; }
    }
}
