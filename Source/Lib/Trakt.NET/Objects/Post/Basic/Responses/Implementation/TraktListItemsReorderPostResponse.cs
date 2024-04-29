namespace TraktNet.Objects.Post.Basic.Responses
{
    using Objects.Post.Responses;
    using System.Collections.Generic;

    public class TraktListItemsReorderPostResponse : ITraktListItemsReorderPostResponse
    {
        /// <summary>
        /// The number of updated list items.
        /// <para>Nullable</para>
        /// </summary>
        public int? Updated { get; set; }

        /// <summary>
        /// A list of of updated list item ids.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<uint> SkippedIds { get; set; }

        /// <summary>
        /// Information about the updated list.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktPostResponseListData List { get; set; }
    }
}
