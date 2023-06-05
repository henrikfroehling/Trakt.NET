namespace TraktNet.Objects.Post.Basic.Responses
{
    using Objects.Post.Responses;
    using System.Collections.Generic;

    public interface ITraktListItemsReorderPostResponse
    {
        /// <summary>
        /// The number of updated list items.
        /// <para>Nullable</para>
        /// </summary>
        int? Updated { get; set; }

        /// <summary>
        /// A list of of updated list item ids.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<uint> SkippedIds { get; set; }

        /// <summary>
        /// Information about the updated list.
        /// <para>Nullable</para>
        /// </summary>
        ITraktPostResponseListData List { get; set; }
    }
}
