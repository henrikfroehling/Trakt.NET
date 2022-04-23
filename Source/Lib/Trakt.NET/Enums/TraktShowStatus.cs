namespace TraktNet.Enums
{
    /// <summary>Determines the status of a show.</summary>
    public sealed class TraktShowStatus : TraktEnumeration
    {
        /// <summary>An invalid status.</summary>
        public static TraktShowStatus Unspecified { get; } = new TraktShowStatus();

        /// <summary>The status for a show, which continues.</summary>
        public static TraktShowStatus ReturningSeries { get; } = new TraktShowStatus(1, "returning series", "returning series", "Returning Series");

        /// <summary>The status for a show, which is in production.</summary>
        public static TraktShowStatus InProduction { get; } = new TraktShowStatus(2, "in production", "in production", "In Production");

        /// <summary>The status for a show, which was canceled.</summary>
        public static TraktShowStatus Canceled { get; } = new TraktShowStatus(4, "canceled", "canceled", "Canceled");

        /// <summary>The status for a show, which has ended.</summary>
        public static TraktShowStatus Ended { get; } = new TraktShowStatus(8, "ended", "ended", "Ended");

        /// <summary>The status for a show, which is upcoming.</summary>
        public static TraktShowStatus Upcoming { get; } = new TraktShowStatus(16, "upcoming", "upcoming", "Upcoming");

        /// <summary>The status for a show, which is planned.</summary>
        public static TraktShowStatus Planned { get; } = new TraktShowStatus(32, "planned", "planned", "Planned");

        /// <summary>The status for a show, which is upcoming.</summary>
        public static TraktShowStatus Continuing { get; } = new TraktShowStatus(64, "continuing", "continuing", "Continuing");

        /// <summary>The status for a show, which is planned.</summary>
        public static TraktShowStatus Pilot { get; } = new TraktShowStatus(128, "pilot", "pilot", "Pilot");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktShowStatus" /> class.<para />
        /// The initialized <see cref="TraktShowStatus" /> is invalid.
        /// </summary>
        public TraktShowStatus()
        {
        }

        private TraktShowStatus(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
