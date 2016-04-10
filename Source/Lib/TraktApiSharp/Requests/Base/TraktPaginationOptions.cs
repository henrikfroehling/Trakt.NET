namespace TraktApiSharp.Requests
{
    internal struct TraktPaginationOptions
    {
        public TraktPaginationOptions(int? page, int? limit)
        {
            Page = page;
            Limit = limit;
        }

        public int? Page { get; set; }

        public int? Limit { get; set; }
    }
}
