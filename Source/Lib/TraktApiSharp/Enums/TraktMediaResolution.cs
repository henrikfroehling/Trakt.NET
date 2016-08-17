namespace TraktApiSharp.Enums
{
    /// <summary>Determines the video resolution type in a collection item's metadata.</summary>
    public sealed class TraktMediaResolution : TraktEnumeration
    {
        /// <summary>An invalid video resolution type.</summary>
        public static TraktMediaResolution Unspecified { get; } = new TraktMediaResolution();

        /// <summary>The collection item has UHD 4k video resolution.</summary>
        public static TraktMediaResolution UHD_4k { get; } = new TraktMediaResolution(1, "uhd_4k", "uhd_4k", "UHD 4k");

        /// <summary>The collection item has HD 1080p video resolution.</summary>
        public static TraktMediaResolution HD_1080p { get; } = new TraktMediaResolution(2, "hd_1080p", "hd_1080p", "HD 1080p");

        /// <summary>The collection item has HD 1080i video resolution.</summary>
        public static TraktMediaResolution HD_1080i { get; } = new TraktMediaResolution(4, "hd_1080i", "hd_1080i", "HD 1080i");

        /// <summary>The collection item has HD 720p video resolution.</summary>
        public static TraktMediaResolution HD_720p { get; } = new TraktMediaResolution(8, "hd_720p", "hd_720p", "HD 720p");

        /// <summary>The collection item has SD 480p video resolution.</summary>
        public static TraktMediaResolution SD_480p { get; } = new TraktMediaResolution(16, "sd_480p", "sd_480p", "SD 480p");

        /// <summary>The collection item has SD 480i video resolution.</summary>
        public static TraktMediaResolution SD_480i { get; } = new TraktMediaResolution(32, "sd_480i", "sd_480i", "SD 480i");

        /// <summary>The collection item has SD 576p video resolution.</summary>
        public static TraktMediaResolution SD_576p { get; } = new TraktMediaResolution(64, "sd_576p", "sd_576p", "SD 576p");

        /// <summary>The collection item has SD 576i video resolution.</summary>
        public static TraktMediaResolution SD_576i { get; } = new TraktMediaResolution(128, "sd_576i", "sd_576i", "SD 576i");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktMediaResolution" /> class.<para />
        /// The initialized <see cref="TraktMediaResolution" /> is invalid.
        /// </summary>
        public TraktMediaResolution() : base() { }

        private TraktMediaResolution(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
