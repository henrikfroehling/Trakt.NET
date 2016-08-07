namespace TraktApiSharp.Enums
{
    public sealed class TraktCommentSortOrder : TraktEnumeration
    {
        public static TraktCommentSortOrder Unspecified { get; } = new TraktCommentSortOrder();
        public static TraktCommentSortOrder Newest { get; } = new TraktCommentSortOrder(1, "newest", "newest", "Newest");
        public static TraktCommentSortOrder Oldest { get; } = new TraktCommentSortOrder(2, "oldest", "oldest", "Oldest");
        public static TraktCommentSortOrder Likes { get; } = new TraktCommentSortOrder(4, "likes", "likes", "Likes");
        public static TraktCommentSortOrder Replies { get; } = new TraktCommentSortOrder(8, "replies", "replies", "Replies");

        public TraktCommentSortOrder() : base() { }

        private TraktCommentSortOrder(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
