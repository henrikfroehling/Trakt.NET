namespace TraktApiSharp.Enums
{
    public sealed class TraktHiddenItemsSection : TraktEnumeration
    {
        public static TraktHiddenItemsSection Unspecified { get; } = new TraktHiddenItemsSection();
        public static TraktHiddenItemsSection Calendar { get; } = new TraktHiddenItemsSection(1, "calendar", "calendar", "Calendar");
        public static TraktHiddenItemsSection ProgressWatched { get; } = new TraktHiddenItemsSection(2, "progress_watched", "progress_watched", "Progress Watched");
        public static TraktHiddenItemsSection ProgressCollected { get; } = new TraktHiddenItemsSection(4, "progress_collected", "progress_collected", "Progress Collected");
        public static TraktHiddenItemsSection Recommendations { get; } = new TraktHiddenItemsSection(8, "recommendations", "recommendations", "Recommendations");

        public TraktHiddenItemsSection() : base() { }

        private TraktHiddenItemsSection(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
