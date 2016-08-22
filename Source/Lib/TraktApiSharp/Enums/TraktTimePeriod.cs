namespace TraktApiSharp.Enums
{
    /// <summary>Determines the time period for most played, most watched and most collected movie and show requests.</summary>
    public sealed class TraktTimePeriod : TraktEnumeration
    {
        /// <summary>An invalid time period.</summary>
        public static TraktTimePeriod Unspecified { get; } = new TraktTimePeriod();

        /// <summary>A weekly time period.</summary>
        public static TraktTimePeriod Weekly { get; } = new TraktTimePeriod(1, "weekly", "weekly", "Weekly");

        /// <summary>A monthly time period.</summary>
        public static TraktTimePeriod Monthly { get; } = new TraktTimePeriod(2, "monthly", "monthly", "Monthly");

        /// <summary>An yearly time period.</summary>
        public static TraktTimePeriod Yearly { get; } = new TraktTimePeriod(4, "yearly", "yearly", "Yearly");

        /// <summary>An overall time period.</summary>
        public static TraktTimePeriod All { get; } = new TraktTimePeriod(8, "all", "all", "All");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktTimePeriod" /> class.<para />
        /// The initialized <see cref="TraktTimePeriod" /> is invalid.
        /// </summary>
        public TraktTimePeriod() : base() { }

        private TraktTimePeriod(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
