namespace TraktApiSharp.Enums
{
    /// <summary>Determines the type of an object in a list item.</summary>
    public sealed class TraktListItemType : TraktEnumeration
    {
        /// <summary>An invalid object type.</summary>
        public static TraktListItemType Unspecified { get; } = new TraktListItemType();

        /// <summary>The list item contains a movie.</summary>
        public static TraktListItemType Movie { get; } = new TraktListItemType(1, "movie", "movies", "Movie");

        /// <summary>The list item contains a show.</summary>
        public static TraktListItemType Show { get; } = new TraktListItemType(2, "show", "shows", "Show");

        /// <summary>The list item contains a season.</summary>
        public static TraktListItemType Season { get; } = new TraktListItemType(4, "season", "seasons", "Season");

        /// <summary>The list item contains an episode.</summary>
        public static TraktListItemType Episode { get; } = new TraktListItemType(8, "episode", "episodes", "Episode");

        /// <summary>The list item contains a person.</summary>
        public static TraktListItemType Person { get; } = new TraktListItemType(16, "person", "people", "Person");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktListItemType" /> class.<para />
        /// The initialized <see cref="TraktListItemType" /> is invalid.
        /// </summary>
        public TraktListItemType() : base() { }

        private TraktListItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
