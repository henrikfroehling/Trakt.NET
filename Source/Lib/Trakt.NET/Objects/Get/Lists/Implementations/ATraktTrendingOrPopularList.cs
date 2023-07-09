namespace TraktNet.Objects.Get.Lists
{
    public abstract class ATraktTrendingOrPopularList : ITraktTrendingOrPopularList
    {
        /// <summary>Gets or sets the list like count.</summary>
        public int? LikeCount { get; set; }

        /// <summary>Gets or sets the list comment count.</summary>
        public int? CommentCount { get; set; }

        /// <summary>
        /// Gets or sets the actual list.
        /// See also <seealso cref="ITraktList" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktList List { get; set; }
    }
}
