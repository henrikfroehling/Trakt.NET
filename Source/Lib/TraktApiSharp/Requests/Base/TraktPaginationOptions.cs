namespace TraktApiSharp.Requests
{
    internal struct TraktPaginationOptions
    {
        internal TraktPaginationOptions(int? page, int? limit)
        {
            Page = page;
            Limit = limit;
        }

        internal int? Page { get; }

        internal int? Limit { get; }
    }
}
