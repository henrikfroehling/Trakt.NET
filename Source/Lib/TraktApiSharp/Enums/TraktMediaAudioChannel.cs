namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktMediaAudioChannel : TraktEnumeration
    {
        public static TraktMediaAudioChannel Unspecified { get; } = new TraktMediaAudioChannel();
        public static TraktMediaAudioChannel Channels_1_0 { get; } = new TraktMediaAudioChannel(1, "1.0", "1.0", "Channels 1.0");
        public static TraktMediaAudioChannel Channels_2_0 { get; } = new TraktMediaAudioChannel(2, "2.0", "2.0", "Channels 2.0");
        public static TraktMediaAudioChannel Channels_2_1 { get; } = new TraktMediaAudioChannel(4, "2.1", "2.1", "Channels 2.1");
        public static TraktMediaAudioChannel Channels_3_0 { get; } = new TraktMediaAudioChannel(8, "3.0", "3.0", "Channels 3.0");
        public static TraktMediaAudioChannel Channels_3_1 { get; } = new TraktMediaAudioChannel(16, "3.1", "3.1", "Channels 3.1");
        public static TraktMediaAudioChannel Channels_4_0 { get; } = new TraktMediaAudioChannel(32, "4.0", "4.0", "Channels 4.0");
        public static TraktMediaAudioChannel Channels_4_1 { get; } = new TraktMediaAudioChannel(64, "4.1", "4.1", "Channels 4.1");
        public static TraktMediaAudioChannel Channels_5_0 { get; } = new TraktMediaAudioChannel(128, "5.0", "5.0", "Channels 5.0");
        public static TraktMediaAudioChannel Channels_5_1 { get; } = new TraktMediaAudioChannel(256, "5.1", "5.1", "Channels 5.1");
        public static TraktMediaAudioChannel Channels_6_1 { get; } = new TraktMediaAudioChannel(512, "6.1", "6.1", "Channels 6.1");
        public static TraktMediaAudioChannel Channels_7_1 { get; } = new TraktMediaAudioChannel(1024, "7.1", "7.1", "Channels 7.1");

        public TraktMediaAudioChannel() : base() { }

        private TraktMediaAudioChannel(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktMediaAudioChannelConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return null;

            var enumString = reader.Value as string;

            if (string.IsNullOrEmpty(enumString))
                return TraktMediaAudioChannel.Unspecified;

            return TraktEnumeration.FromObjectName<TraktMediaAudioChannel>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mediaAudioChannel = (TraktMediaAudioChannel)value;
            writer.WriteValue(mediaAudioChannel.ObjectName);
        }
    }
}
