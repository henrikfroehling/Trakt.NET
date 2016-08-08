namespace TraktApiSharp.Enums
{
    public sealed class TraktGenreType : TraktEnumeration
    {
        public static TraktGenreType Unspecified { get; } = new TraktGenreType();
        public static TraktGenreType Shows { get; } = new TraktGenreType(1, "shows", "shows", "Shows");
        public static TraktGenreType Movies { get; } = new TraktGenreType(2, "movies", "movies", "Movies");

        public TraktGenreType() : base() { }

        private TraktGenreType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
