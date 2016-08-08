namespace TraktApiSharp.Enums
{
    public sealed class TraktMediaResolution : TraktEnumeration
    {
        public static TraktMediaResolution Unspecified { get; } = new TraktMediaResolution();
        public static TraktMediaResolution UHD_4k { get; } = new TraktMediaResolution(1, "uhd_4k", "uhd_4k", "UHD 4k");
        public static TraktMediaResolution HD_1080p { get; } = new TraktMediaResolution(2, "hd_1080p", "hd_1080p", "HD 1080p");
        public static TraktMediaResolution HD_1080i { get; } = new TraktMediaResolution(4, "hd_1080i", "hd_1080i", "HD 1080i");
        public static TraktMediaResolution HD_720p { get; } = new TraktMediaResolution(8, "hd_720p", "hd_720p", "HD 720p");
        public static TraktMediaResolution SD_480p { get; } = new TraktMediaResolution(16, "sd_480p", "sd_480p", "SD 480p");
        public static TraktMediaResolution SD_480i { get; } = new TraktMediaResolution(32, "sd_480i", "sd_480i", "SD 480i");
        public static TraktMediaResolution SD_576p { get; } = new TraktMediaResolution(64, "sd_576p", "sd_576p", "SD 576p");
        public static TraktMediaResolution SD_576i { get; } = new TraktMediaResolution(128, "sd_576i", "sd_576i", "SD 576i");

        public TraktMediaResolution() : base() { }

        private TraktMediaResolution(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
