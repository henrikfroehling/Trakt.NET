namespace TraktApiSharp.Enums
{
    public sealed class TraktSearchField : TraktEnumeration
    {
        public static TraktSearchField Unspecified { get; } = new TraktSearchField();

        public static TraktSearchField Title { get; } = new TraktSearchField(1, "title", "title", "Title");

        public static TraktSearchField Tagline { get; } = new TraktSearchField(2, "tagline", "tagline", "Tagline");

        public static TraktSearchField Overview { get; } = new TraktSearchField(4, "overview", "overview", "Overview");

        public static TraktSearchField People { get; } = new TraktSearchField(8, "people", "people", "People");

        public static TraktSearchField Translations { get; } = new TraktSearchField(16, "translations", "translations", "Translations");

        public static TraktSearchField Aliases { get; } = new TraktSearchField(32, "aliases", "aliases", "Aliases");

        public static TraktSearchField Name { get; } = new TraktSearchField(64, "name", "name", "Name");

        public static TraktSearchField Biography { get; } = new TraktSearchField(128, "biography", "biography", "Biography");

        public static TraktSearchField Description { get; } = new TraktSearchField(256, "description", "description", "Description");

        public TraktSearchField() : base() { }

        private TraktSearchField(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }

        public static TraktSearchField operator |(TraktSearchField first, TraktSearchField second)
        {
            if (first == null || second == null)
                return null;

            if (first == Unspecified || second == Unspecified)
                return Unspecified;

            var newValue = first.Value | second.Value;
            var newObjectName = string.Join(",", first.ObjectName, second.ObjectName);
            var newUriName = string.Join(",", first.UriName, second.UriName);
            var newDisplayName = string.Join(", ", first.DisplayName, second.DisplayName);

            return new TraktSearchField(newValue, newObjectName, newUriName, newDisplayName);
        }
    }
}
