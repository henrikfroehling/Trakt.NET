namespace TraktNet.Objects.Post.Syncs.Lists
{
    using Enums;
    using Requests.Interfaces;

    /// <summary>A Trakt list update post.</summary>
    public interface ITraktUpdateListPost : IRequestBody
    {
        /// <summary>The description for the list.</summary>
        string Description { get; set; }

        /// <summary>The sort by value for the list.</summary>
        TraktSortBy SortBy { get; set; }

        /// <summary>The sort how value for the list.</summary>
        TraktSortHow SortHow { get; set; }
    }
}
