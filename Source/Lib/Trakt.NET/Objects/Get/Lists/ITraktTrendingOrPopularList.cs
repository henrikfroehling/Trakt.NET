namespace TraktNet.Objects.Get.Lists
{
    public interface ITraktTrendingOrPopularList
    {
        /// <summary>Gets or sets the list like count.</summary>
        int? LikeCount { get; set; }

        /// <summary>Gets or sets the list comment count.</summary>
        int? CommentCount { get; set; }

        /// <summary>
        /// Gets or sets the actual list.
        /// See also <seealso cref="ITraktList" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktList List { get; set; }
    }
}
