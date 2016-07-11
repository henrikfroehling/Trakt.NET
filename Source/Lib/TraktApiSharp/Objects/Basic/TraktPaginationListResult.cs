namespace TraktApiSharp.Objects.Basic
{
    using System.Collections.Generic;

    public class TraktPaginationListResult<ListItem>
    {
        public IEnumerable<ListItem> Items { get; set; }

        public int? Page { get; set; }

        public int? Limit { get; set; }

        public int? PageCount { get; set; }

        public int? ItemCount { get; set; }

        public int? UserCount { get; set; }
    }
}
