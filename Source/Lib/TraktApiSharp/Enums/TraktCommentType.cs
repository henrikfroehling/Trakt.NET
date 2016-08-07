namespace TraktApiSharp.Enums
{
    using System.Collections.Generic;

    public sealed class TraktCommentType : TraktEnumeration
    {
        public static TraktCommentType Unspecified { get; } = new TraktCommentType();
        public static TraktCommentType Review { get; } = new TraktCommentType(1, "reviews", "reviews", "Review");
        public static TraktCommentType Shout { get; } = new TraktCommentType(1, "shouts", "shouts", "Shout");
        public static TraktCommentType All { get; } = new TraktCommentType(1, "all", "all", "All");

        public TraktCommentType() : base() { }

        private TraktCommentType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }

        public override IEnumerable<TraktEnumeration> AllEnumerations { get; } = new[] { Unspecified, Review, Shout, All };
    }
}
