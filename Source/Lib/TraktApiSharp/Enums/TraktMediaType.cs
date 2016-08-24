namespace TraktApiSharp.Enums
{
    /// <summary>Determines the media type in a collection item's metadata.</summary>
    public sealed class TraktMediaType : TraktEnumeration
    {
        /// <summary>An invalid media type.</summary>
        public static TraktMediaType Unspecified { get; } = new TraktMediaType();

        /// <summary>The collection item has Digital media.</summary>
        public static TraktMediaType Digital { get; } = new TraktMediaType(1, "digital", "digital", "Digital");

        /// <summary>The collection item has Bluray media.</summary>
        public static TraktMediaType Bluray { get; } = new TraktMediaType(2, "bluray", "bluray", "Bluray");

        /// <summary>The collection item has HD DVD media.</summary>
        public static TraktMediaType HD_DVD { get; } = new TraktMediaType(4, "hddvd", "hddvd", "HD DVD");

        /// <summary>The collection item has DVD media.</summary>
        public static TraktMediaType DVD { get; } = new TraktMediaType(8, "dvd", "dvd", "DVD");

        /// <summary>The collection item has VCD media.</summary>
        public static TraktMediaType VCD { get; } = new TraktMediaType(16, "vcd", "vcd", "VCD");

        /// <summary>The collection item has VHS media.</summary>
        public static TraktMediaType VHS { get; } = new TraktMediaType(32, "vhs", "vhs", "VHS");

        /// <summary>The collection item has Betamax media.</summary>
        public static TraktMediaType BetaMax { get; } = new TraktMediaType(64, "betamax", "betamax", "BetaMax");

        /// <summary>The collection item has Laserdisc media.</summary>
        public static TraktMediaType LaserDisc { get; } = new TraktMediaType(128, "laserdisc", "laserdisc", "LaserDisc");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktMediaType" /> class.<para />
        /// The initialized <see cref="TraktMediaType" /> is invalid.
        /// </summary>
        public TraktMediaType() : base() { }

        private TraktMediaType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
