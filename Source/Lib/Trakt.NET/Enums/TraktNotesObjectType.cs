namespace TraktNet.Enums
{
    /// <summary>Determines the type of an media object to which a note is attached.</summary>
    public sealed class TraktNotesObjectType : TraktEnumeration
    {
        /// <summary>An invalid media object type.</summary>
        public static TraktNotesObjectType Unspecified { get; } = new TraktNotesObjectType();

        /// <summary>A note is attached to any kind of media object.</summary>
        public static TraktNotesObjectType All { get; } = new TraktNotesObjectType(1, "all", "all", "All");

        /// <summary>A note is attached to a movie.</summary>
        public static TraktNotesObjectType Movie { get; } = new TraktNotesObjectType(2, "movie", "movie", "Movie");

        /// <summary>A note is attached to a show.</summary>
        public static TraktNotesObjectType Show { get; } = new TraktNotesObjectType(4, "show", "show", "Show");

        /// <summary>A note is attached to a season.</summary>
        public static TraktNotesObjectType Season { get; } = new TraktNotesObjectType(8, "season", "season", "Season");

        /// <summary>A note is attached to an episode.</summary>
        public static TraktNotesObjectType Episode { get; } = new TraktNotesObjectType(16, "episode", "episode", "Episode");

        /// <summary>A note is attached to a person.</summary>
        public static TraktNotesObjectType Person { get; } = new TraktNotesObjectType(32, "person", "person", "Person");

        /// <summary>A note is attached to an history item.</summary>
        public static TraktNotesObjectType History { get; } = new TraktNotesObjectType(64, "history", "history", "History");

        /// <summary>A note is attached to a collection.</summary>
        public static TraktNotesObjectType Collection { get; } = new TraktNotesObjectType(128, "collection", "collection", "Collection");

        /// <summary>A note is attached to a rating.</summary>
        public static TraktNotesObjectType Rating { get; } = new TraktNotesObjectType(256, "rating", "rating", "Rating");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktNotesObjectType" /> class.<para />
        /// The initialized <see cref="TraktNotesObjectType" /> is invalid.
        /// </summary>
        public TraktNotesObjectType()
        {
        }

        internal static string ToPlural(TraktNotesObjectType notesObjectType)
        {
            if (notesObjectType == All)
                return All.ObjectName;
            else if (notesObjectType == Movie)
                return "movies";
            else if (notesObjectType == Show)
                return "shows";
            else if (notesObjectType == Season)
                return "seasons";
            else if (notesObjectType == Episode)
                return "episodes";
            else if (notesObjectType == Person)
                return "people";
            else if (notesObjectType == History)
                return History.ObjectName;
            else if (notesObjectType == Collection)
                return Collection.ObjectName;
            else if (notesObjectType == Rating)
                return "ratings";

            return "";
        }

        private TraktNotesObjectType(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
