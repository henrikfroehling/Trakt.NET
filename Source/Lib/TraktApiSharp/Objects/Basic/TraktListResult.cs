namespace TraktApiSharp.Objects.Basic
{
    using System.Collections.Generic;

    public class TraktListResult<ListItem>
    {
        public IEnumerable<ListItem> Items { get; set; }
    }
}
