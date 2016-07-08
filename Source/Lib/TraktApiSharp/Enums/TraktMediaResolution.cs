namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public enum TraktMediaResolution
    {
        Unspecified,
        UHD_4k,
        HD_1080p,
        HD_1080i,
        HD_720p,
        SD_480p,
        SD_480i,
        SD_576p,
        SD_576i
    }

    public static class TraktMediaResolutionExtensions
    {
        public static string AsString(this TraktMediaResolution mediaResolution)
        {
            switch (mediaResolution)
            {
                case TraktMediaResolution.UHD_4k: return "uhd_4k";
                case TraktMediaResolution.HD_1080p: return "hd_1080p";
                case TraktMediaResolution.HD_1080i: return "hd_1080i";
                case TraktMediaResolution.HD_720p: return "hd_720p";
                case TraktMediaResolution.SD_480p: return "sd_480p";
                case TraktMediaResolution.SD_480i: return "sd_480i";
                case TraktMediaResolution.SD_576p: return "sd_576p";
                case TraktMediaResolution.SD_576i: return "sd_576i";
                case TraktMediaResolution.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(mediaResolution.ToString());
            }
        }
    }

    public class TraktMediaResolutionConverter : JsonConverter
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
                return TraktMediaResolution.Unspecified;
            else if (enumString.Equals(TraktMediaResolution.UHD_4k.AsString()))
                return TraktMediaResolution.UHD_4k;
            else if (enumString.Equals(TraktMediaResolution.HD_1080p.AsString()))
                return TraktMediaResolution.HD_1080p;
            else if (enumString.Equals(TraktMediaResolution.HD_1080i.AsString()))
                return TraktMediaResolution.HD_1080i;
            else if (enumString.Equals(TraktMediaResolution.HD_720p.AsString()))
                return TraktMediaResolution.HD_720p;
            else if (enumString.Equals(TraktMediaResolution.SD_480p.AsString()))
                return TraktMediaResolution.SD_480p;
            else if (enumString.Equals(TraktMediaResolution.SD_480i.AsString()))
                return TraktMediaResolution.SD_480i;
            else if (enumString.Equals(TraktMediaResolution.SD_576p.AsString()))
                return TraktMediaResolution.SD_576p;
            else if (enumString.Equals(TraktMediaResolution.SD_576i.AsString()))
                return TraktMediaResolution.SD_576i;

            return TraktMediaResolution.Unspecified;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mediaResolution = (TraktMediaResolution)value;
            writer.WriteValue(mediaResolution.AsString());
        }
    }
}
