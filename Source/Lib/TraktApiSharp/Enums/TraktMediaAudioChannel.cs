namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public enum TraktMediaAudioChannel
    {
        Unspecified,
        Channels_1_0,
        Channels_2_0,
        Channels_2_1,
        Channels_3_0,
        Channels_3_1,
        Channels_4_0,
        Channels_4_1,
        Channels_5_0,
        Channels_5_1,
        Channels_6_1,
        Channels_7_1
    }

    public static class TraktMediaAudioChannelExtensions
    {
        public static string AsString(this TraktMediaAudioChannel mediaAudioChannel)
        {
            switch (mediaAudioChannel)
            {
                case TraktMediaAudioChannel.Channels_1_0: return "1.0";
                case TraktMediaAudioChannel.Channels_2_0: return "2.0";
                case TraktMediaAudioChannel.Channels_2_1: return "2.1";
                case TraktMediaAudioChannel.Channels_3_0: return "3.0";
                case TraktMediaAudioChannel.Channels_3_1: return "3.1";
                case TraktMediaAudioChannel.Channels_4_0: return "4.0";
                case TraktMediaAudioChannel.Channels_4_1: return "4.1";
                case TraktMediaAudioChannel.Channels_5_0: return "5.0";
                case TraktMediaAudioChannel.Channels_5_1: return "5.1";
                case TraktMediaAudioChannel.Channels_6_1: return "6.1";
                case TraktMediaAudioChannel.Channels_7_1: return "7.1";
                case TraktMediaAudioChannel.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(mediaAudioChannel.ToString());
            }
        }
    }

    public class TraktMediaAudioChannelConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;

            if (string.IsNullOrEmpty(enumString))
                return TraktMediaAudioChannel.Unspecified;
            else if (enumString.Equals(TraktMediaAudioChannel.Channels_1_0.AsString()))
                return TraktMediaAudioChannel.Channels_1_0;
            else if (enumString.Equals(TraktMediaAudioChannel.Channels_2_0.AsString()))
                return TraktMediaAudioChannel.Channels_2_0;
            else if (enumString.Equals(TraktMediaAudioChannel.Channels_2_1.AsString()))
                return TraktMediaAudioChannel.Channels_2_1;
            else if (enumString.Equals(TraktMediaAudioChannel.Channels_3_0.AsString()))
                return TraktMediaAudioChannel.Channels_3_0;
            else if (enumString.Equals(TraktMediaAudioChannel.Channels_3_1.AsString()))
                return TraktMediaAudioChannel.Channels_3_1;
            else if (enumString.Equals(TraktMediaAudioChannel.Channels_4_0.AsString()))
                return TraktMediaAudioChannel.Channels_4_0;
            else if (enumString.Equals(TraktMediaAudioChannel.Channels_4_1.AsString()))
                return TraktMediaAudioChannel.Channels_4_1;
            else if (enumString.Equals(TraktMediaAudioChannel.Channels_5_0.AsString()))
                return TraktMediaAudioChannel.Channels_5_0;
            else if (enumString.Equals(TraktMediaAudioChannel.Channels_5_1.AsString()))
                return TraktMediaAudioChannel.Channels_5_1;
            else if (enumString.Equals(TraktMediaAudioChannel.Channels_6_1.AsString()))
                return TraktMediaAudioChannel.Channels_6_1;
            else if (enumString.Equals(TraktMediaAudioChannel.Channels_7_1.AsString()))
                return TraktMediaAudioChannel.Channels_7_1;

            return TraktMediaAudioChannel.Unspecified;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mediaAudioChannel = (TraktMediaAudioChannel)value;
            writer.WriteValue(mediaAudioChannel.AsString());
        }
    }
}
