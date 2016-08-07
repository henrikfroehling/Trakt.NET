namespace TraktApiSharp.Enums
{
    using Newtonsoft.Json;
    using System;

    public sealed class TraktScrobbleActionType : TraktEnumeration
    {
        public static TraktScrobbleActionType Unspecified { get; } = new TraktScrobbleActionType();
        public static TraktScrobbleActionType Start { get; } = new TraktScrobbleActionType(1, "start", "start", "Start");
        public static TraktScrobbleActionType Pause { get; } = new TraktScrobbleActionType(2, "pause", "pause", "Pause");
        public static TraktScrobbleActionType Stop { get; } = new TraktScrobbleActionType(4, "scrobble", "scrobble", "Stop");

        public TraktScrobbleActionType() : base() { }

        private TraktScrobbleActionType(int value, string objectName, string uriName, string displayName)
            : base(value, objectName, uriName, displayName) { }
    }

    public class TraktScrobbleActionTypeConverter : JsonConverter
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
                return TraktScrobbleActionType.Unspecified;

            return TraktEnumeration.FromObjectName<TraktScrobbleActionType>(enumString);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var scrobbleActionType = (TraktScrobbleActionType)value;
            writer.WriteValue(scrobbleActionType.ObjectName);
        }
    }
}
