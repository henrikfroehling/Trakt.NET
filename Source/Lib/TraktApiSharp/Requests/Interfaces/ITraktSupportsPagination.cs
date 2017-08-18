namespace TraktApiSharp.Requests.Interfaces
{
    internal interface ITraktSupportsPagination
    {
        uint? Page { get; set; }

        uint? Limit { get; set; }
    }
}
