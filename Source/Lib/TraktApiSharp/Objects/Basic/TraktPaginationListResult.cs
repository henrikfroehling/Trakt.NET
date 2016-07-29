namespace TraktApiSharp.Objects.Basic
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Represents results of requests supporting pagination.<para />
    /// Contains the current page, the item limitation per page, the total page count, the total item count
    /// and can also contain the total user count (e.g. in trending shows and movies requests).
    /// </summary>
    /// <typeparam name="ListItem">The underlying item type of the list results.</typeparam>
    public class TraktPaginationListResult<ListItem> : IEnumerable<ListItem>
    {
        /// <summary>Gets or sets the actual list results.</summary>
        public IEnumerable<ListItem> Items { get; set; }

        /// <summary>Gets or sets the current page number.</summary>
        public int? Page { get; set; }

        /// <summary>Gets or sets the item limitation per page.</summary>
        public int? Limit { get; set; }

        /// <summary>Gets or sets the total page count.</summary>
        public int? PageCount { get; set; }

        /// <summary>Gets or sets the total item results count.</summary>
        public int? ItemCount { get; set; }

        /// <summary>
        /// Gets or sets the total user count.
        /// <para>
        /// May be only supported for trending shows and movies requests.
        /// </para>
        /// </summary>
        public int? UserCount { get; set; }

        public IEnumerator<ListItem> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
