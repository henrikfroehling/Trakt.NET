namespace TraktApiSharp.Enums
{
    /// <summary>Determines the sort order for comments lists.</summary>
    public sealed class TraktCommentSortOrder : TraktEnumeration
    {
        /// <summary>An invalid sort order.</summary>
        public static TraktCommentSortOrder Unspecified { get; } = new TraktCommentSortOrder();

        /// <summary>Comments will be sorted by newest comments first.</summary>
        public static TraktCommentSortOrder Newest { get; } = new TraktCommentSortOrder(1, "newest", "newest", "Newest");

        /// <summary>Comments will be sorted by oldest comments first.</summary>
        public static TraktCommentSortOrder Oldest { get; } = new TraktCommentSortOrder(2, "oldest", "oldest", "Oldest");

        /// <summary>Comments will be sorted by the number of likes first.</summary>
        public static TraktCommentSortOrder Likes { get; } = new TraktCommentSortOrder(4, "likes", "likes", "Likes");

        /// <summary>Comments will be sorted by the number of replies first.</summary>
        public static TraktCommentSortOrder Replies { get; } = new TraktCommentSortOrder(8, "replies", "replies", "Replies");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktCommentSortOrder" /> class.<para />
        /// The initialized <see cref="TraktCommentSortOrder" /> is invalid.
        /// </summary>
        public TraktCommentSortOrder() : base() { }

        private TraktCommentSortOrder(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
