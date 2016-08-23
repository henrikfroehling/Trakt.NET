namespace TraktApiSharp.Enums
{
    /// <summary>Determines the type of an object in an user like item.</summary>
    public sealed class TraktUserLikeType : TraktEnumeration
    {
        /// <summary>An invalid object type.</summary>
        public static TraktUserLikeType Unspecified { get; } = new TraktUserLikeType();

        /// <summary>The user like item contains a comment.</summary>
        public static TraktUserLikeType Comment { get; } = new TraktUserLikeType(1, "comment", "comments", "Comment");

        /// <summary>The user like item contains a list.</summary>
        public static TraktUserLikeType List { get; } = new TraktUserLikeType(2, "list", "lists", "List");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktUserLikeType" /> class.<para />
        /// The initialized <see cref="TraktUserLikeType" /> is invalid.
        /// </summary>
        public TraktUserLikeType() : base() { }

        private TraktUserLikeType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
