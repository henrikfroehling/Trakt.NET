namespace TraktApiSharp.Enums
{
    /// <summary>Determines the genre type of movie and show genres.</summary>
    public sealed class TraktGenreType : TraktEnumeration
    {
        /// <summary>An invalid genre type.</summary>
        public static TraktGenreType Unspecified { get; } = new TraktGenreType();

        /// <summary>The genre type for shows.</summary>
        public static TraktGenreType Shows { get; } = new TraktGenreType(1, "shows", "shows", "Shows");

        /// <summary>The genre type for movies.</summary>
        public static TraktGenreType Movies { get; } = new TraktGenreType(2, "movies", "movies", "Movies");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktGenreType" /> class.<para />
        /// The initialized <see cref="TraktGenreType" /> is invalid.
        /// </summary>
        public TraktGenreType() : base() { }

        private TraktGenreType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
