namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public enum TraktShowStatus
    {
        Unspecified,
        ReturningSeries,
        InProduction,
        Canceled,
        Ended
    }

    public static class TraktShowStatusExtensions
    {
        public static string AsString(this TraktShowStatus scope)
        {
            switch (scope)
            {
                case TraktShowStatus.ReturningSeries: return "returning series";
                case TraktShowStatus.InProduction: return "in production";
                case TraktShowStatus.Canceled: return "canceled";
                case TraktShowStatus.Ended: return "ended";
                case TraktShowStatus.Unspecified: return "";
                default:
                    throw new ArgumentOutOfRangeException("ShowStatus");
            }
        }
    }

    public class TraktShowStatusConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;
            enumString = enumString.ToLower();

            if (enumString.Equals(TraktShowStatus.ReturningSeries.AsString()))
                return TraktShowStatus.ReturningSeries;
            else if (enumString.Equals(TraktShowStatus.InProduction.AsString()))
                return TraktShowStatus.InProduction;
            else if (enumString.Equals(TraktShowStatus.Canceled.AsString()))
                return TraktShowStatus.Canceled;
            else if (enumString.Equals(TraktShowStatus.Ended.AsString()))
                return TraktShowStatus.Ended;

            return TraktShowStatus.Unspecified;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var showStatus = (TraktShowStatus)value;
            writer.WriteValue(showStatus.AsString());
        }
    }
}
