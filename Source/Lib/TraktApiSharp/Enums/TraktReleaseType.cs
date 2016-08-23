namespace TraktApiSharp.Enums
{
    /// <summary>Determines, how a movie was released.</summary>
    public sealed class TraktReleaseType : TraktEnumeration
    {
        /// <summary>An invalid release type.</summary>
        public static TraktReleaseType Unspecified { get; } = new TraktReleaseType();

        /// <summary>An unknown release type.</summary>
        public static TraktReleaseType Unknown { get; } = new TraktReleaseType(1, "unknown", "unknown", "Unknown");

        /// <summary>The release was a premiere.</summary>
        public static TraktReleaseType Premiere { get; } = new TraktReleaseType(2, "premiere", "premiere", "Premiere");

        /// <summary>The release was limited.</summary>
        public static TraktReleaseType Limited { get; } = new TraktReleaseType(4, "limited", "limited", "Limited");

        /// <summary>The release was theatrical.</summary>
        public static TraktReleaseType Theatrical { get; } = new TraktReleaseType(8, "theatrical", "theatrical", "Theatrical");

        /// <summary>The release was digital.</summary>
        public static TraktReleaseType Digital { get; } = new TraktReleaseType(16, "digital", "digital", "Digital");

        /// <summary>The release was physical.</summary>
        public static TraktReleaseType Physical { get; } = new TraktReleaseType(32, "physical", "physical", "Physical");

        /// <summary>The release was in TV.</summary>
        public static TraktReleaseType TV { get; } = new TraktReleaseType(64, "tv", "tv", "TV");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktReleaseType" /> class.<para />
        /// The initialized <see cref="TraktReleaseType" /> is invalid.
        /// </summary>
        public TraktReleaseType() : base() { }

        private TraktReleaseType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
