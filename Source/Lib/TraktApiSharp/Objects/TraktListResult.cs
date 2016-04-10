namespace TraktApiSharp.Objects
{
    using System.Collections.Generic;

    public class TraktListResult<ListItem>
    {
        public IEnumerable<ListItem> Items { get; set; }
    }
}
