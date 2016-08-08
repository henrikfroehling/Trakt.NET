namespace TraktApiSharp.Enums
{
    public sealed class TraktHiddenItemType : TraktEnumeration
    {
        public static TraktHiddenItemType Unspecified { get; } = new TraktHiddenItemType();
        public static TraktHiddenItemType Movie { get; } = new TraktHiddenItemType(1, "movie", "movie", "Movie");
        public static TraktHiddenItemType Show { get; } = new TraktHiddenItemType(2, "show", "show", "Show");
        public static TraktHiddenItemType Season { get; } = new TraktHiddenItemType(4, "season", "season", "Season");

        public TraktHiddenItemType() : base() { }

        private TraktHiddenItemType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
