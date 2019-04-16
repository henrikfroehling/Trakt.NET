﻿namespace TraktNet.Enums
{
    /// <summary>Determines the audio type in a collection item's metadata.</summary>
    public sealed class TraktMediaAudio : TraktEnumeration
    {
        /// <summary>An invalid audio type.</summary>
        public static TraktMediaAudio Unspecified { get; } = new TraktMediaAudio();

        /// <summary>The collection item has LPCM audio.</summary>
        public static TraktMediaAudio LPCM { get; } = new TraktMediaAudio(1, "lpcm", "lpcm", "LPCM");

        /// <summary>The collection item has MP3 audio.</summary>
        public static TraktMediaAudio MP3 { get; } = new TraktMediaAudio(2, "mp3", "mp3", "MP3");

        /// <summary>The collection item has AAC audio.</summary>
        public static TraktMediaAudio AAC { get; } = new TraktMediaAudio(4, "aac", "aac", "AAC");

        /// <summary>The collection item has OGG audio.</summary>
        public static TraktMediaAudio OGG { get; } = new TraktMediaAudio(8, "ogg", "ogg", "OGG");

        /// <summary>The collection item has WMA audio.</summary>
        public static TraktMediaAudio WMA { get; } = new TraktMediaAudio(16, "wma", "wma", "WMA");

        /// <summary>The collection item has DTS audio.</summary>
        public static TraktMediaAudio DTS { get; } = new TraktMediaAudio(32, "dts", "dts", "DTS");

        /// <summary>The collection item has DTS Master Audio.</summary>
        public static TraktMediaAudio DTS_MA { get; } = new TraktMediaAudio(64, "dts_ma", "dts_ma", "DTS Master Audio");

        /// <summary>The collection item has DTS X Audio.</summary>
        public static TraktMediaAudio DTS_X { get; } = new TraktMediaAudio(128, "dts_x", "dts_x", "DTS X");

        /// <summary>The collection item has Dolby Prologic audio.</summary>
        public static TraktMediaAudio DolbyPrologic { get; } = new TraktMediaAudio(256, "dolby_prologic", "dolby_prologic", "Dolby Prologic");

        /// <summary>The collection item has Dolby Digital audio.</summary>
        public static TraktMediaAudio DolbyDigital { get; } = new TraktMediaAudio(512, "dolby_digital", "dolby_digital", "Dolby Digital");

        /// <summary>The collection item has Dolby Digital Plus audio.</summary>
        public static TraktMediaAudio DolbyDigitalPlus { get; } = new TraktMediaAudio(1024, "dolby_digital_plus", "dolby_digital_plus", "Dolby Digital Plus");

        /// <summary>The collection item has Dolby True HD audio.</summary>
        public static TraktMediaAudio DolbyTrueHD { get; } = new TraktMediaAudio(2048, "dolby_truehd", "dolby_truehd", "Dolby True HD");

        /// <summary>The collection item has Dolby Atmos audio.</summary>
        public static TraktMediaAudio DolbyAtmos { get; } = new TraktMediaAudio(4096, "dolby_atmos", "dolby_atmos", "Dolby Atmos");

        /// <summary>The collection item has DTS HR audio.</summary>
        public static TraktMediaAudio DTS_HR { get; } = new TraktMediaAudio(8192, "dts_hr", "dts_hr", "DTS HR");

        /// <summary>The collection item has AURO 3D audio.</summary>
        public static TraktMediaAudio AURO_3D { get; } = new TraktMediaAudio(16384, "auro_3d", "auro_3d", "AURO 3D");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktMediaAudio" /> class.<para />
        /// The initialized <see cref="TraktMediaAudio" /> is invalid.
        /// </summary>
        public TraktMediaAudio()
        {
        }

        private TraktMediaAudio(int value, string objectName, string uriName, string displayName) : base(value, objectName, uriName, displayName)
        {
        }
    }
}
