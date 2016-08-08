namespace TraktApiSharp.Enums
{
    public sealed class TraktTimePeriod : TraktEnumeration
    {
        public static TraktTimePeriod Unspecified { get; } = new TraktTimePeriod();
        public static TraktTimePeriod Weekly { get; } = new TraktTimePeriod(1, "weekly", "weekly", "Weekly");
        public static TraktTimePeriod Monthly { get; } = new TraktTimePeriod(2, "monthly", "monthly", "Monthly");
        public static TraktTimePeriod Yearly { get; } = new TraktTimePeriod(4, "yearly", "yearly", "Yearly");
        public static TraktTimePeriod All { get; } = new TraktTimePeriod(8, "all", "all", "All");

        public TraktTimePeriod() : base() { }

        private TraktTimePeriod(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
