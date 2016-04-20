namespace TraktApiSharp.Enums
{
    using Extensions;
    using Newtonsoft.Json;
    using System;

    public enum TraktScrobbleActionType
    {
        Unspecified,
        Start,
        Pause,
        Stop
    }

    public static class TraktScrobbleActionTypeExtensions
    {
        public static string AsString(this TraktScrobbleActionType scrobbleActionType)
        {
            switch (scrobbleActionType)
            {
                case TraktScrobbleActionType.Unspecified: return string.Empty;
                case TraktScrobbleActionType.Start: return "start";
                case TraktScrobbleActionType.Pause: return "pause";
                case TraktScrobbleActionType.Stop: return "scrobble";
                default:
                    throw new NotSupportedException(scrobbleActionType.ToString());
            }
        }
    }

    public class TraktScrobbleActionTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = reader.Value as string;

            if (enumString.Equals(TraktScrobbleActionType.Stop.AsString()))
                return TraktScrobbleActionType.Stop;

            enumString = enumString.FirstToUpper();
            return Enum.Parse(typeof(TraktScrobbleActionType), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var scrobbleActionType = (TraktScrobbleActionType)value;
            writer.WriteValue(scrobbleActionType.AsString());
        }
    }
}
