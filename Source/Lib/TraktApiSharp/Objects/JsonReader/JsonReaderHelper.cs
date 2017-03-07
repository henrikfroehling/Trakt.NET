namespace TraktApiSharp.Objects.JsonReader
{
    using Enums;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    internal static class JsonReaderHelper
    {
        internal static IEnumerable<string> ReadStringArray(JsonTextReader jsonReader)
        {
            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
            {
                var values = new List<string>();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.String)
                {
                    var value = (string)jsonReader.Value;

                    if (!string.IsNullOrEmpty(value))
                        values.Add(value);
                }

                return values;
            }

            return null;
        }

        internal static bool ReadDateTimeValue(JsonTextReader jsonReader, out DateTime dateTime)
        {
            if (jsonReader.Read())
            {
                if (jsonReader.ValueType == typeof(DateTime))
                {
                    dateTime = (DateTime)jsonReader.Value;
                    return true;
                }
                else if (jsonReader.ValueType == typeof(string))
                {
                    dateTime = DateTime.Parse(jsonReader.Value.ToString());
                    return true;
                }
            }

            dateTime = default(DateTime);
            return false;
        }

        internal static void ReadEnumerationValue<TEnumeration>(JsonTextReader jsonReader, out TEnumeration enumeration) where TEnumeration : TraktEnumeration, new()
        {
            var value = jsonReader.ReadAsString();

            if (!string.IsNullOrEmpty(value))
            {
                enumeration = TraktEnumeration.FromObjectName<TEnumeration>(value);
                return;
            }

            enumeration = default(TEnumeration);
        }

        internal static void OverreadInvalidContent(JsonTextReader jsonReader)
        {
            jsonReader.Read(); // read unmatched property value

            if (jsonReader.TokenType == JsonToken.StartArray)
                OverreadInvalidContentWithStartArrayToken(jsonReader);
            else if (jsonReader.TokenType == JsonToken.StartObject)
                OverreadInvalidContentWithStartObjectToken(jsonReader);
        }

        internal static void OverreadInvalidContentWithStartArrayToken(JsonTextReader jsonReader)
            => OverreadInvalidContent(jsonReader, true, false);

        internal static void OverreadInvalidContentWithStartObjectToken(JsonTextReader jsonReader)
            => OverreadInvalidContent(jsonReader, false, true);

        private static void OverreadInvalidContent(JsonTextReader jsonReader, bool startWithOpenBracket, bool startWithOpenBrace)
        {
            var arrayBracketPairCount = startWithOpenBracket ? 1 : 0;
            var objectBracePairCount = startWithOpenBrace ? 1 : 0;
            var steppedOverAllArrays = false;
            var steppedOverAllObjects = false;

            while (true)
            {
                if (steppedOverAllArrays && !steppedOverAllObjects && objectBracePairCount == 0)
                    break;
                else if (steppedOverAllObjects && !steppedOverAllArrays && arrayBracketPairCount == 0)
                    break;
                else if (steppedOverAllArrays && steppedOverAllObjects)
                    break;

                if (jsonReader.Read())
                {
                    switch (jsonReader.TokenType)
                    {
                        case JsonToken.StartArray:
                            arrayBracketPairCount++;

                            if (arrayBracketPairCount != 0)
                                steppedOverAllArrays = false;

                            break;
                        case JsonToken.EndArray:
                            arrayBracketPairCount--;

                            if (arrayBracketPairCount == 0)
                                steppedOverAllArrays = true;

                            break;
                        case JsonToken.StartObject:
                            objectBracePairCount++;

                            if (objectBracePairCount != 0)
                                steppedOverAllObjects = false;

                            break;
                        case JsonToken.EndObject:
                            objectBracePairCount--;

                            if (objectBracePairCount == 0)
                                steppedOverAllObjects = true;

                            break;
                        default:
                            continue;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
