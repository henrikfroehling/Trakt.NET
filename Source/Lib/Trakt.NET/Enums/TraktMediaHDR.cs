namespace TraktNet.Enums
{
    /// <summary>Determines the HDR type in a collection item's metadata.</summary>
    public sealed class TraktMediaHDR : TraktEnumeration
    {
        /// <summary>An invalid HDR type.</summary>
        public static TraktMediaHDR Unspecified { get; } = new TraktMediaHDR();

        /// <summary>The collection item supports DolbyVision.</summary>
        public static TraktMediaHDR DolbyVision { get; } = new TraktMediaHDR(1, "dolby_vision", "dolby_vision", "Dolby Vision");

        /// <summary>The collection item supports HDR10.</summary>
        public static TraktMediaHDR HDR_10 { get; } = new TraktMediaHDR(2, "hdr10", "hdr10", "HDR10");

        /// <summary>The collection item supports HDR10 Plus.</summary>
        public static TraktMediaHDR HDR_10_Plus { get; } = new TraktMediaHDR(4, "hdr10_plus", "hdr10_plus", "HDR10 Plus");

        /// <summary>The collection item supports HLG.</summary>
        public static TraktMediaHDR HLG { get; } = new TraktMediaHDR(8, "hlg", "hlg", "HLG");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktMediaHDR" /> class.<para />
        /// The initialized <see cref="TraktMediaHDR" /> is invalid.
        /// </summary>
        public TraktMediaHDR()
        {
        }

        private TraktMediaHDR(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
