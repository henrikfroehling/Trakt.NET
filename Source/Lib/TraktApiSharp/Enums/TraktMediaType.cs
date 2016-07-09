namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public enum TraktMediaType
    {
        Unspecified,
        Digital,
        Bluray,
        HD_DVD,
        DVD,
        VCD,
        VHS,
        BetaMax,
        LaserDisc
    }

    public static class TraktMediaTypeExtensions
    {
        public static string AsString(this TraktMediaType mediaType)
        {
            switch (mediaType)
            {
                case TraktMediaType.Digital: return "digital";
                case TraktMediaType.Bluray: return "bluray";
                case TraktMediaType.HD_DVD: return "hddvd";
                case TraktMediaType.DVD: return "dvd";
                case TraktMediaType.VCD: return "vcd";
                case TraktMediaType.VHS: return "vhs";
                case TraktMediaType.BetaMax: return "betamax";
                case TraktMediaType.LaserDisc: return "laserdisc";
                case TraktMediaType.Unspecified: return string.Empty;
                default:
                    throw new NotSupportedException(mediaType.ToString());
            }
        }
    }

    public class TraktMediaTypeConverter : JsonConverter
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
                return TraktMediaType.Unspecified;
            else if (enumString.Equals(TraktMediaType.Digital.AsString()))
                return TraktMediaType.Digital;
            else if (enumString.Equals(TraktMediaType.Bluray.AsString()))
                return TraktMediaType.Bluray;
            else if (enumString.Equals(TraktMediaType.HD_DVD.AsString()))
                return TraktMediaType.HD_DVD;
            else if (enumString.Equals(TraktMediaType.DVD.AsString()))
                return TraktMediaType.DVD;
            else if (enumString.Equals(TraktMediaType.VCD.AsString()))
                return TraktMediaType.VCD;
            else if (enumString.Equals(TraktMediaType.VHS.AsString()))
                return TraktMediaType.VHS;
            else if (enumString.Equals(TraktMediaType.BetaMax.AsString()))
                return TraktMediaType.BetaMax;
            else if (enumString.Equals(TraktMediaType.LaserDisc.AsString()))
                return TraktMediaType.LaserDisc;

            return TraktMediaType.Unspecified;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var mediaType = (TraktMediaType)value;
            writer.WriteValue(mediaType.AsString());
        }
    }
}
