namespace TraktApiSharp.Enums
{
    public sealed class TraktCommentType : TraktEnumeration
    {
        public static TraktCommentType Unspecified { get; } = new TraktCommentType();
        public static TraktCommentType Review { get; } = new TraktCommentType(1, "reviews", "reviews", "Review");
        public static TraktCommentType Shout { get; } = new TraktCommentType(2, "shouts", "shouts", "Shout");
        public static TraktCommentType All { get; } = new TraktCommentType(4, "all", "all", "All");

        public TraktCommentType() : base() { }

        private TraktCommentType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
