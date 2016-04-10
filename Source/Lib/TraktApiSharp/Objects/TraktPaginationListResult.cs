namespace TraktApiSharp.Objects
{
    public class TraktPaginationListResult<ListItem> : TraktListResult<ListItem>
    {
        public int Page { get; set; }

        public int Limit { get; set; }

        public int PageCount { get; set; }

        public int ItemCount { get; set; }
    }
}
