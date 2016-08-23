namespace TraktApiSharp.Enums
{
    /// <summary>Determines the audio channel type in a collection item's metadata.</summary>
    public sealed class TraktMediaAudioChannel : TraktEnumeration
    {
        /// <summary>An invalid audio channel type.</summary>
        public static TraktMediaAudioChannel Unspecified { get; } = new TraktMediaAudioChannel();

        /// <summary>The collection item has 1.0 audio channels.</summary>
        public static TraktMediaAudioChannel Channels_1_0 { get; } = new TraktMediaAudioChannel(1, "1.0", "1.0", "Channels 1.0");

        /// <summary>The collection item has 2.0 audio channels.</summary>
        public static TraktMediaAudioChannel Channels_2_0 { get; } = new TraktMediaAudioChannel(2, "2.0", "2.0", "Channels 2.0");

        /// <summary>The collection item has 2.1 audio channels.</summary>
        public static TraktMediaAudioChannel Channels_2_1 { get; } = new TraktMediaAudioChannel(4, "2.1", "2.1", "Channels 2.1");

        /// <summary>The collection item has 3.0 audio channels.</summary>
        public static TraktMediaAudioChannel Channels_3_0 { get; } = new TraktMediaAudioChannel(8, "3.0", "3.0", "Channels 3.0");

        /// <summary>The collection item has 3.1 audio channels.</summary>
        public static TraktMediaAudioChannel Channels_3_1 { get; } = new TraktMediaAudioChannel(16, "3.1", "3.1", "Channels 3.1");

        /// <summary>The collection item has 4.0 audio channels.</summary>
        public static TraktMediaAudioChannel Channels_4_0 { get; } = new TraktMediaAudioChannel(32, "4.0", "4.0", "Channels 4.0");

        /// <summary>The collection item has 4.1 audio channels.</summary>
        public static TraktMediaAudioChannel Channels_4_1 { get; } = new TraktMediaAudioChannel(64, "4.1", "4.1", "Channels 4.1");

        /// <summary>The collection item has 5.0 audio channels.</summary>
        public static TraktMediaAudioChannel Channels_5_0 { get; } = new TraktMediaAudioChannel(128, "5.0", "5.0", "Channels 5.0");

        /// <summary>The collection item has 5.1 audio channels.</summary>
        public static TraktMediaAudioChannel Channels_5_1 { get; } = new TraktMediaAudioChannel(256, "5.1", "5.1", "Channels 5.1");

        /// <summary>The collection item has 6.1 audio channels.</summary>
        public static TraktMediaAudioChannel Channels_6_1 { get; } = new TraktMediaAudioChannel(512, "6.1", "6.1", "Channels 6.1");

        /// <summary>The collection item has 7.1 audio channels.</summary>
        public static TraktMediaAudioChannel Channels_7_1 { get; } = new TraktMediaAudioChannel(1024, "7.1", "7.1", "Channels 7.1");

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktMediaAudioChannel" /> class.<para />
        /// The initialized <see cref="TraktMediaAudioChannel" /> is invalid.
        /// </summary>
        public TraktMediaAudioChannel() : base() { }

        private TraktMediaAudioChannel(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }
}
