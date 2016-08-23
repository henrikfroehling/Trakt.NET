namespace TraktApiSharp.Enums
{
    /// <summary>Determines the type of an object in an hidden item.</summary>
    public sealed class TraktHiddenItemType : TraktEnumeration
    {
        /// <summary>An invalid object type.</summary>
        public static TraktHiddenItemType Unspecified { get; } = new TraktHiddenItemType();

        /// <summary>The hidden item contains a movie.</summary>
        public static TraktHiddenItemType Movie { get; } = new TraktHiddenItemType(1, "movie", "movie", "Movie");

        /// <summary>The listhidden item contains a show.</summary>
        public static TraktHiddenItemType Show { get; } = new TraktHiddenItemType(2, "show", "show", "Show");

        /// <summary>The hidden item contains a season.</summary>
        public static TraktHiddenItemType Season { get; } = new TraktHiddenItemType(4, "season", "season", "Season");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktHiddenItemType" /> class.<para />
        /// The initialized <see cref="TraktHiddenItemType" /> is invalid.
        /// </summary>
        public TraktHiddenItemType() : base() { }

        private TraktHiddenItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
