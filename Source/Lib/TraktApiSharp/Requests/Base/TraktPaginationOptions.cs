namespace TraktApiSharp.Requests
{
    internal struct TraktPaginationOptions
    {
        internal TraktPaginationOptions(int? page, int? limit)
        {
            Page = page;
            Limit = limit;
        }

        internal int? Page { get; set; }

        internal int? Limit { get; set; }
    }
}
