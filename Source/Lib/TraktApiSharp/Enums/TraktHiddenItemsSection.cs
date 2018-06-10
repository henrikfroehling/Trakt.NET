namespace TraktApiSharp.Enums
{
    /// <summary>Determines the section, from which hidden items should be requested.</summary>
    public sealed class TraktHiddenItemsSection : TraktEnumeration
    {
        /// <summary>An invalid section.</summary>
        public static TraktHiddenItemsSection Unspecified { get; } = new TraktHiddenItemsSection();

        /// <summary>The section for calendars.</summary>
        public static TraktHiddenItemsSection Calendar { get; } = new TraktHiddenItemsSection(1, "calendar", "calendar", "Calendar");

        /// <summary>The section for watched progress.</summary>
        public static TraktHiddenItemsSection ProgressWatched { get; } = new TraktHiddenItemsSection(2, "progress_watched", "progress_watched", "Progress Watched");

        /// <summary>The section for collected progress.</summary>
        public static TraktHiddenItemsSection ProgressCollected { get; } = new TraktHiddenItemsSection(4, "progress_collected", "progress_collected", "Progress Collected");

        /// <summary>The section for recommendations.</summary>
        public static TraktHiddenItemsSection Recommendations { get; } = new TraktHiddenItemsSection(8, "recommendations", "recommendations", "Recommendations");

        /// <summary>The section for watched reset progress.</summary>
        public static TraktHiddenItemsSection ProgressWatchedReset { get; } = new TraktHiddenItemsSection(16, "progress_watched_reset", "progress_watched_reset", "Progress Watched Reset");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktHiddenItemsSection" /> class.<para />
        /// The initialized <see cref="TraktHiddenItemsSection" /> is invalid.
        /// </summary>
        public TraktHiddenItemsSection()
        {
        }

        private TraktHiddenItemsSection(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
