namespace TraktNet.Enums
{
    /// <summary>Determines the type of an object in a favorite item.</summary>
    public sealed class TraktFavoriteObjectType : TraktEnumeration
    {
        /// <summary>An invalid object type.</summary>
        public static TraktFavoriteObjectType Unspecified { get; } = new TraktFavoriteObjectType();

        /// <summary>The recommendation contains a movie.</summary>
        public static TraktFavoriteObjectType Movie { get; } = new TraktFavoriteObjectType(1, "movie", "movies", "Movie");

        /// <summary>The recommendation contains a show.</summary>
        public static TraktFavoriteObjectType Show { get; } = new TraktFavoriteObjectType(2, "show", "shows", "Show");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktFavoriteObjectType" /> class.<para />
        /// The initialized <see cref="TraktFavoriteObjectType" /> is invalid.
        /// </summary>
        public TraktFavoriteObjectType()
        {
        }

        private TraktFavoriteObjectType(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
