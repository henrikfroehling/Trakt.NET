namespace TraktApiSharp.Enums
{
    /// <summary>Determines the field hint in a search query.</summary>
    public sealed class TraktSearchField : TraktEnumeration
    {
        /// <summary>An invalid field hint.</summary>
        public static TraktSearchField Unspecified { get; } = new TraktSearchField();

        /// <summary>The hint to search in movie, show or episode titles.</summary>
        public static TraktSearchField Title { get; } = new TraktSearchField(1, "title", "title", "Title");

        /// <summary>The hint to search in movie taglines.</summary>
        public static TraktSearchField Tagline { get; } = new TraktSearchField(2, "tagline", "tagline", "Tagline");

        /// <summary>The hint to search in movie, show or episode overviews.</summary>
        public static TraktSearchField Overview { get; } = new TraktSearchField(4, "overview", "overview", "Overview");

        /// <summary>The hint to search in movie or show people.</summary>
        public static TraktSearchField People { get; } = new TraktSearchField(8, "people", "people", "People");

        /// <summary>The hint to search in movie or show translations.</summary>
        public static TraktSearchField Translations { get; } = new TraktSearchField(16, "translations", "translations", "Translations");

        /// <summary>The hint to search in movie or show aliases.</summary>
        public static TraktSearchField Aliases { get; } = new TraktSearchField(32, "aliases", "aliases", "Aliases");

        /// <summary>The hint to search in person or list names.</summary>
        public static TraktSearchField Name { get; } = new TraktSearchField(64, "name", "name", "Name");

        /// <summary>The hint to search in person biographies.</summary>
        public static TraktSearchField Biography { get; } = new TraktSearchField(128, "biography", "biography", "Biography");

        /// <summary>The hint to search in list descriptions.</summary>
        public static TraktSearchField Description { get; } = new TraktSearchField(256, "description", "description", "Description");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktSearchField" /> class.<para />
        /// The initialized <see cref="TraktSearchField" /> is invalid.
        /// </summary>
        public TraktSearchField() : base() { }

        private TraktSearchField(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }

        /// <summary>
        /// Combines two <see cref="TraktSearchField" /> enumerations to one enumeration.
        /// <para>
        /// Usage: TraktSearchField.Title | TraktSearchField.Tagline
        /// </para>
        /// </summary>
        /// <param name="first">The first enumeration.</param>
        /// <param name="second">The second enumeration.</param>
        /// <returns>
        /// A binary combination of both given enumerations or null,
        /// if at least on of the given enumerations is null or unspecified.
        /// </returns>
        public static TraktSearchField operator |(TraktSearchField first, TraktSearchField second)
        {
            if (first == null || second == null)
                return null;

            if (first == Unspecified || second == Unspecified)
                return Unspecified;

            var newValue = first.Value | second.Value;
            var newObjectName = string.Join(",", first.ObjectName, second.ObjectName);
            var newUriName = string.Join(",", first.UriName, second.UriName);
            var newDisplayName = string.Join(", ", first.DisplayName, second.DisplayName);

            return new TraktSearchField(newValue, newObjectName, newUriName, newDisplayName);
        }
    }
}
