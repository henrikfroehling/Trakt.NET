namespace TraktApiSharp.Objects.JsonReader
{
    using Enums;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal static class JsonReaderHelper
    {
        internal static async Task<IEnumerable<string>> ReadStringArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var values = new List<string>();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.String)
                {
                    var value = (string)jsonReader.Value;

                    if (!string.IsNullOrEmpty(value))
                        values.Add(value);
                }

                return values;
            }

            return null;
        }

        internal static async Task<Pair<bool, DateTime>> ReadDateTimeValueAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (await jsonReader.ReadAsync(cancellationToken))
            {
                if (jsonReader.ValueType == typeof(DateTime))
                {
                    var dateTime = (DateTime)jsonReader.Value;
                    return new Pair<bool, DateTime>(true, dateTime);
                }
                else if (jsonReader.ValueType == typeof(string))
                {
                    try
                    {
                        var dateTime = DateTime.Parse(jsonReader.Value.ToString());
                        return new Pair<bool, DateTime>(true, dateTime);
                    }
                    catch(Exception)
                    {
                        return new Pair<bool, DateTime>(false, default(DateTime));
                    }
                }
            }

            return new Pair<bool, DateTime>(false, default(DateTime));
        }

        internal static async Task<Pair<bool, uint>> ReadUnsignedIntegerValueAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            int? value = await jsonReader.ReadAsInt32Async(cancellationToken);

            if (value.HasValue)
            {
                var propertyValue = (uint)value;
                return new Pair<bool, uint>(true, propertyValue);
            }

            return new Pair<bool, uint>(false, 0);
        }

        internal static async Task<TEnumeration> ReadEnumerationValueAsync<TEnumeration>(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken)) where TEnumeration : TraktEnumeration, new()
        {
            var value = await jsonReader.ReadAsStringAsync(cancellationToken);

            if (!string.IsNullOrEmpty(value))
                return TraktEnumeration.FromObjectName<TEnumeration>(value);

            return default(TEnumeration);
        }

        internal static async Task ReadAndIgnoreInvalidContentAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            await jsonReader.ReadAsync(cancellationToken); // read unmatched property value

            if (jsonReader.TokenType == JsonToken.StartArray)
                await ReadAndIgnoreInvalidContentWithStartArrayTokenAsync(jsonReader, cancellationToken);
            else if (jsonReader.TokenType == JsonToken.StartObject)
                await ReadAndIgnoreInvalidContentWithStartObjectTokenAsync(jsonReader, cancellationToken);
        }

        internal static Task ReadAndIgnoreInvalidContentWithStartArrayTokenAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
            => ReadAndIgnoreInvalidContentAsync(jsonReader, true, false, cancellationToken);

        internal static Task ReadAndIgnoreInvalidContentWithStartObjectTokenAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
            => ReadAndIgnoreInvalidContentAsync(jsonReader, false, true, cancellationToken);

        private static async Task ReadAndIgnoreInvalidContentAsync(JsonTextReader jsonReader, bool startWithOpenBracket, bool startWithOpenBrace, CancellationToken cancellationToken = default(CancellationToken))
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

                if (await jsonReader.ReadAsync(cancellationToken))
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
