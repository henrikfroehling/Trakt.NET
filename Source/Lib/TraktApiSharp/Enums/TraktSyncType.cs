namespace TraktApiSharp.Enums
{
    /// <summary>Determines the type of an object in a playback progress item.</summary>
    public sealed class TraktSyncType : TraktEnumeration
    {
        /// <summary>An invalid object type.</summary>
        public static TraktSyncType Unspecified { get; } = new TraktSyncType();

        /// <summary>The playback progress item contains a movie.</summary>
        public static TraktSyncType Movie { get; } = new TraktSyncType(1, "movie", "movies", "Movie");

        /// <summary>The playback progress item contains an episode.</summary>
        public static TraktSyncType Episode { get; } = new TraktSyncType(2, "episode", "episodes", "Episode");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktSyncType" /> class.<para />
        /// The initialized <see cref="TraktSyncType" /> is invalid.
        /// </summary>
        public TraktSyncType() : base() { }

        private TraktSyncType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
