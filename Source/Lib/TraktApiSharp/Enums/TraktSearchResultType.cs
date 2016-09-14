namespace TraktApiSharp.Enums
{
    /// <summary>Determines the type of an object in a search result.</summary>
    public sealed class TraktSearchResultType : TraktEnumeration
    {
        /// <summary>An invalid object type.</summary>
        public static TraktSearchResultType Unspecified { get; } = new TraktSearchResultType();

        /// <summary>The search result contains a movie.</summary>
        public static TraktSearchResultType Movie { get; } = new TraktSearchResultType(1, "movie", "movie", "Movie");

        /// <summary>The search result contains a show.</summary>
        public static TraktSearchResultType Show { get; } = new TraktSearchResultType(2, "show", "show", "Show");

        /// <summary>The search result contains an episode.</summary>
        public static TraktSearchResultType Episode { get; } = new TraktSearchResultType(4, "episode", "episode", "Episode");

        /// <summary>The search result contains a person.</summary>
        public static TraktSearchResultType Person { get; } = new TraktSearchResultType(8, "person", "person", "Person");

        /// <summary>The search result contains a list.</summary>
        public static TraktSearchResultType List { get; } = new TraktSearchResultType(16, "list", "list", "List");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktSearchResultType" /> class.<para />
        /// The initialized <see cref="TraktSearchResultType" /> is invalid.
        /// </summary>
        public TraktSearchResultType() : base() { }

        private TraktSearchResultType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }

        /// <summary>
        /// Combines two <see cref="TraktSearchResultType" /> enumerations to one enumeration.
        /// <para>
        /// Usage: TraktSearchResultType.Movie | TraktSearchResultType.Show
        /// </para>
        /// </summary>
        /// <param name="first">The first enumeration.</param>
        /// <param name="second">The second enumeration.</param>
        /// <returns>
        /// A binary combination of both given enumerations or null,
        /// if at least on of the given enumerations is null or unspecified.
        /// </returns>
        public static TraktSearchResultType operator |(TraktSearchResultType first, TraktSearchResultType second)
        {
            if (first == null || second == null)
                return null;

            if (first == Unspecified || second == Unspecified)
                return Unspecified;

            var newValue = first.Value | second.Value;
            var newObjectName = string.Join(",", first.ObjectName, second.ObjectName);
            var newUriName = string.Join(",", first.UriName, second.UriName);
            var newDisplayName = string.Join(", ", first.DisplayName, second.DisplayName);

            return new TraktSearchResultType(newValue, newObjectName, newUriName, newDisplayName);
        }
    }
}
