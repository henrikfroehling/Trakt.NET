namespace TraktApiSharp.Enums
{
    /// <summary>Determines the action type of an history item.</summary>
    public sealed class TraktHistoryActionType : TraktEnumeration
    {
        /// <summary>An invalid action type.</summary>
        public static TraktHistoryActionType Unspecified { get; } = new TraktHistoryActionType();

        /// <summary>The history item is / was scrobbled.</summary>
        public static TraktHistoryActionType Scrobble { get; } = new TraktHistoryActionType(1, "scrobble", "scrobble", "Scrobble");

        /// <summary>The history item is / was checked in.</summary>
        public static TraktHistoryActionType Checkin { get; } = new TraktHistoryActionType(2, "checkin", "checkin", "Checkin");

        /// <summary>The history item is / was watched.</summary>
        public static TraktHistoryActionType Watch { get; } = new TraktHistoryActionType(4, "watch", "watch", "Watch");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktHistoryActionType" /> class.<para />
        /// The initialized <see cref="TraktHistoryActionType" /> is invalid.
        /// </summary>
        public TraktHistoryActionType() : base() { }

        private TraktHistoryActionType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
