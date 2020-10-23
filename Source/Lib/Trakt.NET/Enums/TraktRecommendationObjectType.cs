namespace TraktNet.Enums
{
    /// <summary>Determines the type of an object in a recommendation.</summary>
    public sealed class TraktRecommendationObjectType : TraktEnumeration
    {
        /// <summary>An invalid object type.</summary>
        public static TraktRecommendationObjectType Unspecified { get; } = new TraktRecommendationObjectType();

        /// <summary>The recommendation contains a movie.</summary>
        public static TraktRecommendationObjectType Movie { get; } = new TraktRecommendationObjectType(1, "movie", "movies", "Movie");

        /// <summary>The recommendation contains a show.</summary>
        public static TraktRecommendationObjectType Show { get; } = new TraktRecommendationObjectType(2, "show", "shows", "Show");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktRecommendationObjectType" /> class.<para />
        /// The initialized <see cref="TraktRecommendationObjectType" /> is invalid.
        /// </summary>
        public TraktRecommendationObjectType()
        {
        }

        private TraktRecommendationObjectType(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
