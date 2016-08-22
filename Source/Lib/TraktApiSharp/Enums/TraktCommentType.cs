namespace TraktApiSharp.Enums
{
    /// <summary>Determines the comment type.</summary>
    public sealed class TraktCommentType : TraktEnumeration
    {
        /// <summary>An invalid comment type.</summary>
        public static TraktCommentType Unspecified { get; } = new TraktCommentType();

        /// <summary>The comment type for reviews.</summary>
        public static TraktCommentType Review { get; } = new TraktCommentType(1, "reviews", "reviews", "Review");

        /// <summary>The comment type for shouts.</summary>
        public static TraktCommentType Shout { get; } = new TraktCommentType(2, "shouts", "shouts", "Shout");

        /// <summary>The comment type for both reviews and shouts.</summary>
        public static TraktCommentType All { get; } = new TraktCommentType(4, "all", "all", "All");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktCommentType" /> class.<para />
        /// The initialized <see cref="TraktCommentType" /> is invalid.
        /// </summary>
        public TraktCommentType() : base() { }

        private TraktCommentType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
