namespace TraktNet.Enums
{
    /// <summary>Determines the sort order for comments.</summary>
    public sealed class TraktShowsCommentSortOrder : TraktEnumeration
    {
        /// <summary>An invalid sort order.</summary>
        public static TraktShowsCommentSortOrder Unspecified { get; } = new TraktShowsCommentSortOrder();

        /// <summary>Comments will be sorted by newest comments first.</summary>
        public static TraktShowsCommentSortOrder Newest { get; } = new TraktShowsCommentSortOrder(1, "newest", "newest", "Newest");

        /// <summary>Comments will be sorted by oldest comments first.</summary>
        public static TraktShowsCommentSortOrder Oldest { get; } = new TraktShowsCommentSortOrder(2, "oldest", "oldest", "Oldest");

        /// <summary>Comments will be sorted by the number of likes first.</summary>
        public static TraktShowsCommentSortOrder Likes { get; } = new TraktShowsCommentSortOrder(4, "likes", "likes", "Likes");

        /// <summary>Comments will be sorted by the number of replies first.</summary>
        public static TraktShowsCommentSortOrder Replies { get; } = new TraktShowsCommentSortOrder(8, "replies", "replies", "Replies");

        /// <summary>Comments will be sorted by highest comments first.</summary>
        public static TraktShowsCommentSortOrder Highest { get; } = new TraktShowsCommentSortOrder(16, "highest", "highest", "Highest");

        /// <summary>Comments will be sorted by lowest comments first.</summary>
        public static TraktShowsCommentSortOrder Lowest { get; } = new TraktShowsCommentSortOrder(32, "lowest", "lowest", "Lowest");

        /// <summary>Comments will be sorted by the number of plays first.</summary>
        public static TraktShowsCommentSortOrder Plays { get; } = new TraktShowsCommentSortOrder(64, "plays", "plays", "Plays");

        /// <summary>Comments will be sorted by most watched first.</summary>
        public static TraktShowsCommentSortOrder Watched { get; } = new TraktShowsCommentSortOrder(128, "watched", "watched", "Watched");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktShowsCommentSortOrder" /> class.<para />
        /// The initialized <see cref="TraktShowsCommentSortOrder" /> is invalid.
        /// </summary>
        public TraktShowsCommentSortOrder()
        {
        }

        public TraktShowsCommentSortOrder(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
