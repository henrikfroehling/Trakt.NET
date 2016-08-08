namespace TraktApiSharp.Enums
{
    public sealed class TraktHistoryActionType : TraktEnumeration
    {
        public static TraktHistoryActionType Unspecified { get; } = new TraktHistoryActionType();
        public static TraktHistoryActionType Scrobble { get; } = new TraktHistoryActionType(1, "scrobble", "scrobble", "Scrobble");
        public static TraktHistoryActionType Checkin { get; } = new TraktHistoryActionType(2, "checkin", "checkin", "Checkin");
        public static TraktHistoryActionType Watch { get; } = new TraktHistoryActionType(4, "watch", "watch", "Watch");

        public TraktHistoryActionType() : base() { }

        private TraktHistoryActionType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
