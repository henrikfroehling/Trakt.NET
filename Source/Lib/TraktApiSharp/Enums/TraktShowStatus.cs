namespace TraktApiSharp.Enums
{
    public sealed class TraktShowStatus : TraktEnumeration
    {
        public static TraktShowStatus Unspecified { get; } = new TraktShowStatus();
        public static TraktShowStatus ReturningSeries { get; } = new TraktShowStatus(1, "returning series", "returning series", "Returning Series");
        public static TraktShowStatus InProduction { get; } = new TraktShowStatus(2, "in production", "in production", "In Production");
        public static TraktShowStatus Canceled { get; } = new TraktShowStatus(4, "canceled", "canceled", "Canceled");
        public static TraktShowStatus Ended { get; } = new TraktShowStatus(8, "ended", "ended", "Ended");

        public TraktShowStatus() : base() { }

        private TraktShowStatus(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
