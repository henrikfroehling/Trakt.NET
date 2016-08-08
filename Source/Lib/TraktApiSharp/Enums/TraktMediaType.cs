namespace TraktApiSharp.Enums
{
    public sealed class TraktMediaType : TraktEnumeration
    {
        public static TraktMediaType Unspecified { get; } = new TraktMediaType();
        public static TraktMediaType Digital { get; } = new TraktMediaType(1, "digital", "digital", "Digital");
        public static TraktMediaType Bluray { get; } = new TraktMediaType(2, "bluray", "bluray", "Bluray");
        public static TraktMediaType HD_DVD { get; } = new TraktMediaType(4, "hddvd", "hddvd", "HD DVD");
        public static TraktMediaType DVD { get; } = new TraktMediaType(8, "dvd", "dvd", "DVD");
        public static TraktMediaType VCD { get; } = new TraktMediaType(16, "vcd", "vcd", "VCD");
        public static TraktMediaType VHS { get; } = new TraktMediaType(32, "vhs", "vhs", "VHS");
        public static TraktMediaType BetaMax { get; } = new TraktMediaType(64, "betamax", "betamax", "BetaMax");
        public static TraktMediaType LaserDisc { get; } = new TraktMediaType(128, "laserdisc", "laserdisc", "LaserDisc");

        public TraktMediaType() : base() { }

        private TraktMediaType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
