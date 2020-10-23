namespace TraktNet.Enums
{
    /// <summary>Determines the status of a movie.</summary>
    public sealed class TraktMovieStatus : TraktEnumeration
    {
        /// <summary>An invalid status.</summary>
        public static TraktMovieStatus Unspecified { get; } = new TraktMovieStatus();

        /// <summary>The status for a movie, which is released.</summary>
        public static TraktMovieStatus Released { get; } = new TraktMovieStatus(1, "released", "released", "Released");

        /// <summary>The status for a movie, which is in production.</summary>
        public static TraktMovieStatus InProduction { get; } = new TraktMovieStatus(2, "in production", "in production", "In Production");

        /// <summary>The status for a movie, which is in post production.</summary>
        public static TraktMovieStatus PostProduction { get; } = new TraktMovieStatus(4, "post production", "post production", "Post Production");

        /// <summary>The status for a movie, which is planned.</summary>
        public static TraktMovieStatus Planned { get; } = new TraktMovieStatus(8, "planned", "planned", "Planned");

        /// <summary>The status for a movie, which is rumored.</summary>
        public static TraktMovieStatus Rumored { get; } = new TraktMovieStatus(16, "rumored", "rumored", "Rumored");

        /// <summary>The status for a movie, which is canceled.</summary>
        public static TraktMovieStatus Canceled { get; } = new TraktMovieStatus(32, "canceled", "canceled", "Canceled");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktMovieStatus" /> class.<para />
        /// The initialized <see cref="TraktMovieStatus" /> is invalid.
        /// </summary>
        public TraktMovieStatus()
        {
        }

        private TraktMovieStatus(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
