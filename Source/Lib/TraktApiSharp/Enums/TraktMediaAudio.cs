namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public enum TraktMediaAudio
    {
        Unspecified,
        LPCM,
        MP3,
        AAC,
        OGG,
        WMA,
        DTS,
        DTS_MA,
        DolbyPrologic,
        DolbyDigital,
        DolbyDigitalPlus,
        DolbyTrueHD
    }

    public static class TraktMediaAudioExtensions
    {
        public static string AsString(this TraktMediaAudio mediaAudio)
        {
            switch (mediaAudio)
            {
                case TraktMediaAudio.LPCM: return "lpcm";
                case TraktMediaAudio.MP3: return "mp3";
                case TraktMediaAudio.AAC: return "aac";
                case TraktMediaAudio.OGG: return "ogg";
                case TraktMediaAudio.WMA: return "wma";
                case TraktMediaAudio.DTS: return "dts";
                case TraktMediaAudio.DTS_MA: return "dts_ma";
                case TraktMediaAudio.DolbyPrologic: return "dolby_prologic";
                case TraktMediaAudio.DolbyDigital: return "dolby_digital";
                case TraktMediaAudio.DolbyDigitalPlus: return "dolby_digital_plus";
                case TraktMediaAudio.DolbyTrueHD: return "dolby_truehd";
                case TraktMediaAudio.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(mediaAudio.ToString());
            }
        }
    }

    public class TraktMediaAudioConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;

            if (string.IsNullOrEmpty(enumString))
                return TraktMediaAudio.Unspecified;
            else if (enumString.Equals(TraktMediaAudio.LPCM.AsString()))
                return TraktMediaAudio.LPCM;
            else if (enumString.Equals(TraktMediaAudio.MP3.AsString()))
                return TraktMediaAudio.MP3;
            else if (enumString.Equals(TraktMediaAudio.AAC.AsString()))
                return TraktMediaAudio.AAC;
            else if (enumString.Equals(TraktMediaAudio.OGG.AsString()))
                return TraktMediaAudio.OGG;
            else if (enumString.Equals(TraktMediaAudio.WMA.AsString()))
                return TraktMediaAudio.WMA;
            else if (enumString.Equals(TraktMediaAudio.DTS.AsString()))
                return TraktMediaAudio.DTS;
            else if (enumString.Equals(TraktMediaAudio.DTS_MA.AsString()))
                return TraktMediaAudio.DTS_MA;
            else if (enumString.Equals(TraktMediaAudio.DolbyPrologic.AsString()))
                return TraktMediaAudio.DolbyPrologic;
            else if (enumString.Equals(TraktMediaAudio.DolbyDigital.AsString()))
                return TraktMediaAudio.DolbyDigital;
            else if (enumString.Equals(TraktMediaAudio.DolbyDigitalPlus.AsString()))
                return TraktMediaAudio.DolbyDigitalPlus;
            else if (enumString.Equals(TraktMediaAudio.DolbyTrueHD.AsString()))
                return TraktMediaAudio.DolbyTrueHD;

            return TraktMediaAudio.Unspecified;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mediaAudio = (TraktMediaAudio)value;
            writer.WriteValue(mediaAudio.AsString());
        }
    }
}
