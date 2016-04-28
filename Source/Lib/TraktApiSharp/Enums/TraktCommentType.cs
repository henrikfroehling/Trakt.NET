namespace TraktApiSharp.Enums
{
    using System;

    public enum TraktCommentType
    {
        Unspecified,
        Review,
        Shout,
        All
    }

    public static class TraktCommentTypeExtensions
    {
        public static string AsStringUriParameter(this TraktCommentType commentType)
        {
            switch (commentType)
            {
                case TraktCommentType.Review: return "reviews";
                case TraktCommentType.Shout: return "shouts";
                case TraktCommentType.All: return "all";
                case TraktCommentType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(commentType.ToString());
            }
        }
    }
}
