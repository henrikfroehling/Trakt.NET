namespace TraktNet.Enums
{
    /// <summary>Determines the sort order for comments.</summary>
    public sealed class TraktExtendedCommentSortOrder : TraktEnumeration
    {
        /// <summary>An invalid sort order.</summary>
        public static TraktExtendedCommentSortOrder Unspecified { get; } = new TraktExtendedCommentSortOrder();

        /// <summary>Comments will be sorted by newest comments first.</summary>
        public static TraktExtendedCommentSortOrder Newest { get; } = new TraktExtendedCommentSortOrder(1, "newest", "newest", "Newest");

        /// <summary>Comments will be sorted by oldest comments first.</summary>
        public static TraktExtendedCommentSortOrder Oldest { get; } = new TraktExtendedCommentSortOrder(2, "oldest", "oldest", "Oldest");

        /// <summary>Comments will be sorted by the number of likes first.</summary>
        public static TraktExtendedCommentSortOrder Likes { get; } = new TraktExtendedCommentSortOrder(4, "likes", "likes", "Likes");

        /// <summary>Comments will be sorted by the number of replies first.</summary>
        public static TraktExtendedCommentSortOrder Replies { get; } = new TraktExtendedCommentSortOrder(8, "replies", "replies", "Replies");

        /// <summary>Comments will be sorted by highest comments first.</summary>
        public static TraktExtendedCommentSortOrder Highest { get; } = new TraktExtendedCommentSortOrder(16, "highest", "highest", "Highest");

        /// <summary>Comments will be sorted by lowest comments first.</summary>
        public static TraktExtendedCommentSortOrder Lowest { get; } = new TraktExtendedCommentSortOrder(32, "lowest", "lowest", "Lowest");

        /// <summary>Comments will be sorted by the number of plays first.</summary>
        public static TraktExtendedCommentSortOrder Plays { get; } = new TraktExtendedCommentSortOrder(64, "plays", "plays", "Plays");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktExtendedCommentSortOrder" /> class.<para />
        /// The initialized <see cref="TraktExtendedCommentSortOrder" /> is invalid.
        /// </summary>
        public TraktExtendedCommentSortOrder()
        {
        }

        public TraktExtendedCommentSortOrder(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
