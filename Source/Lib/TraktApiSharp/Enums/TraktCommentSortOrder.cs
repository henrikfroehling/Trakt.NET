namespace TraktApiSharp.Enums
{
    using System;

    public enum TraktCommentSortOrder
    {
        Unspecified,
        Newest,
        Oldest,
        Likes,
        Replies
    }

    public static class TraktCommentSortOrderExtensions
    {
        public static string AsString(this TraktCommentSortOrder commentSortOrder)
        {
            switch (commentSortOrder)
            {
                case TraktCommentSortOrder.Newest: return "newest";
                case TraktCommentSortOrder.Oldest: return "oldest";
                case TraktCommentSortOrder.Likes: return "likes";
                case TraktCommentSortOrder.Replies: return "replies";
                case TraktCommentSortOrder.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(commentSortOrder.ToString());
            }
        }
    }
}
