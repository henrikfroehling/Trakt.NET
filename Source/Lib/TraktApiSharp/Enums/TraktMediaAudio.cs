namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktMediaAudio : TraktEnumeration
    {
        public static TraktMediaAudio Unspecified { get; } = new TraktMediaAudio();
        public static TraktMediaAudio LPCM { get; } = new TraktMediaAudio(1, "lpcm", "lpcm", "LPCM");
        public static TraktMediaAudio MP3 { get; } = new TraktMediaAudio(2, "mp3", "mp3", "MP3");
        public static TraktMediaAudio AAC { get; } = new TraktMediaAudio(4, "aac", "aac", "AAC");
        public static TraktMediaAudio OGG { get; } = new TraktMediaAudio(8, "ogg", "ogg", "OGG");
        public static TraktMediaAudio WMA { get; } = new TraktMediaAudio(16, "wma", "wma", "WMA");
        public static TraktMediaAudio DTS { get; } = new TraktMediaAudio(32, "dts", "dts", "DTS");
        public static TraktMediaAudio DTS_MA { get; } = new TraktMediaAudio(64, "dts_ma", "dts_ma", "DTS Master Audio");
        public static TraktMediaAudio DolbyPrologic { get; } = new TraktMediaAudio(128, "dolby_prologic", "dolby_prologic", "Dolby Prologic");
        public static TraktMediaAudio DolbyDigital { get; } = new TraktMediaAudio(256, "dolby_digital", "dolby_digital", "Dolby Digital");
        public static TraktMediaAudio DolbyDigitalPlus { get; } = new TraktMediaAudio(512, "dolby_digital_plus", "dolby_digital_plus", "Dolby Digital Plus");
        public static TraktMediaAudio DolbyTrueHD { get; } = new TraktMediaAudio(1024, "dolby_truehd", "dolby_truehd", "Dolby True HD");

        public TraktMediaAudio() : base() { }

        private TraktMediaAudio(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktMediaAudioConverter : JsonConverter
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
                return TraktMediaAudio.Unspecified;

            return TraktEnumeration.FromObjectName<TraktMediaAudio>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mediaAudio = (TraktMediaAudio)value;
            writer.WriteValue(mediaAudio.ObjectName);
        }
    }
}
