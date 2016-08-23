namespace TraktApiSharp.Enums
{
    /// <summary>Determines the type of an object in a comment.</summary>
    public sealed class TraktObjectType : TraktEnumeration
    {
        /// <summary>An invalid object type.</summary>
        public static TraktObjectType Unspecified { get; } = new TraktObjectType();

        /// <summary>The comment contains a movie.</summary>
        public static TraktObjectType Movie { get; } = new TraktObjectType(1, "movie", "movies", "Movie");

        /// <summary>The comment contains a show.</summary>
        public static TraktObjectType Show { get; } = new TraktObjectType(2, "show", "shows", "Show");

        /// <summary>The comment contains a season.</summary>
        public static TraktObjectType Season { get; } = new TraktObjectType(4, "season", "seasons", "Season");

        /// <summary>The comment contains an episode.</summary>
        public static TraktObjectType Episode { get; } = new TraktObjectType(8, "episode", "episodes", "Episode");

        /// <summary>The comment contains a list.</summary>
        public static TraktObjectType List { get; } = new TraktObjectType(16, "list", "lists", "List");

        /// <summary>The comment contains a movie, show, season, list or an episode.</summary>
        public static TraktObjectType All { get; } = new TraktObjectType(32, "all", "all", "All");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktObjectType" /> class.<para />
        /// The initialized <see cref="TraktObjectType" /> is invalid.
        /// </summary>
        public TraktObjectType() : base() { }

        private TraktObjectType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
