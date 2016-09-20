namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using TraktApiSharp.Requests;

    internal interface ITraktPagination
    {
        TraktPaginationOptions PaginationOptions { get; set; }

        bool SupportsOnlyPaginationParameters { get; }
    }
}
