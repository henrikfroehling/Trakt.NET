namespace TraktApiSharp.Requests.Base
{
    internal interface ITraktResponseHeaders
    {
        int? UserCount { get; set; }

        string SortBy { get; set; }

        string SortHow { get; set; }
    }
}
