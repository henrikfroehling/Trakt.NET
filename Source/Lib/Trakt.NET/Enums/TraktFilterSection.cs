namespace TraktNet.Enums
{
    /// <summary>Determines the filter section of saved filters.</summary>
    public sealed class TraktFilterSection : TraktEnumeration
    {
        /// <summary>An invalid filter section.</summary>
        public static TraktFilterSection Unspecified { get; } = new TraktFilterSection();

        /// <summary>The filter section for movies.</summary>
        public static TraktFilterSection Movies { get; } = new TraktFilterSection(1, "movies", "movies", "Movies");

        /// <summary>The filter section for shows.</summary>
        public static TraktFilterSection Shows { get; } = new TraktFilterSection(2, "shows", "shows", "Shows");

        /// <summary>The filter section for calendars.</summary>
        public static TraktFilterSection Calendars { get; } = new TraktFilterSection(4, "calendars ", "calendars ", "Calendars ");

        /// <summary>The filter section for search.</summary>
        public static TraktFilterSection Search { get; } = new TraktFilterSection(8, "search", "search", "Search");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktFilterSection" /> class.<para />
        /// The initialized <see cref="TraktFilterSection" /> is invalid.
        /// </summary>
        public TraktFilterSection()
        {
        }

        private TraktFilterSection(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
