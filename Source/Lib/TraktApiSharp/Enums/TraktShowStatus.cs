namespace TraktApiSharp.Enums
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

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktShowStatus" /> class.<para />
        /// The initialized <see cref="TraktShowStatus" /> is invalid.
        /// </summary>
        public TraktShowStatus() : base() { }

        private TraktShowStatus(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
