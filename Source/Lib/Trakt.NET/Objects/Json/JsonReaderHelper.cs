namespace TraktNet.Objects.Json
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
        internal static async Task<IEnumerable<string>> ReadStringArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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

            return default;
        }

        internal static async Task<IEnumerable<ulong>> ReadUnsignedLongArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var values = new List<ulong>();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.Integer)
                {
                    if (ulong.TryParse(jsonReader.Value.ToString(), out ulong value))
                        values.Add(value);
                }

                return values;
            }

            return default;
        }

        internal static async Task<Pair<bool, DateTime>> ReadDateTimeValueAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
                        return new Pair<bool, DateTime>(false, default);
                    }
                }
            }

            return new Pair<bool, DateTime>(false, default);
        }

        internal static async Task<Pair<bool, float>> ReadFloatValueAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (await jsonReader.ReadAsync(cancellationToken))
            {
                if (jsonReader.TokenType == JsonToken.Float || jsonReader.TokenType == JsonToken.Integer)
                {
                    if (float.TryParse(jsonReader.Value.ToString(), out float value))
                        return new Pair<bool, float>(true, value);
                }
            }

            return new Pair<bool, float>(false, default);
        }

        internal static async Task<Pair<bool, int>> ReadIntegerValueAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (await jsonReader.ReadAsync(cancellationToken))
            {
                if (jsonReader.TokenType == JsonToken.Integer)
                {
                    if (int.TryParse(jsonReader.Value.ToString(), out int value))
                        return new Pair<bool, int>(true, value);
                }
            }

            return new Pair<bool, int>(false, default);
        }

        internal static async Task<Pair<bool, uint>> ReadUnsignedIntegerValueAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (await jsonReader.ReadAsync(cancellationToken))
            {
                if (jsonReader.TokenType == JsonToken.Integer)
                {
                    if (uint.TryParse(jsonReader.Value.ToString(), out uint value))
                        return new Pair<bool, uint>(true, value);
                }
            }

            return new Pair<bool, uint>(false, default);
        }

        internal static async Task<Pair<bool, ulong>> ReadUnsignedLongIntegerAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (await jsonReader.ReadAsync(cancellationToken))
            {
                if (jsonReader.TokenType == JsonToken.Integer)
                {
                    if (ulong.TryParse(jsonReader.Value.ToString(), out ulong value))
                        return new Pair<bool, ulong>(true, value);
                }
            }

            return new Pair<bool, ulong>(false, default);
        }

        internal static async Task<TEnumeration> ReadEnumerationValueAsync<TEnumeration>(JsonTextReader jsonReader, CancellationToken cancellationToken = default) where TEnumeration : TraktEnumeration, new()
        {
            var value = await jsonReader.ReadAsStringAsync(cancellationToken);

            if (!string.IsNullOrEmpty(value))
                return TraktEnumeration.FromObjectName<TEnumeration>(value);

            return default;
        }

        internal static async Task<IDictionary<string, int>> ReadDistributionAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            const string nr1 = "1";
            const string nr2 = "2";
            const string nr3 = "3";
            const string nr4 = "4";
            const string nr5 = "5";
            const string nr6 = "6";
            const string nr7 = "7";
            const string nr8 = "8";
            const string nr9 = "9";
            const string nr10 = "10";

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var distribution = new Dictionary<string, int>
                {
                    [nr1] = 0,
                    [nr2] = 0,
                    [nr3] = 0,
                    [nr4] = 0,
                    [nr5] = 0,
                    [nr6] = 0,
                    [nr7] = 0,
                    [nr8] = 0,
                    [nr9] = 0,
                    [nr10] = 0
                };

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var numberProperty = jsonReader.Value.ToString();

                    switch (numberProperty)
                    {
                        case nr1:
                            distribution[nr1] = (int)await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case nr2:
                            distribution[nr2] = (int)await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case nr3:
                            distribution[nr3] = (int)await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case nr4:
                            distribution[nr4] = (int)await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case nr5:
                            distribution[nr5] = (int)await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case nr6:
                            distribution[nr6] = (int)await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case nr7:
                            distribution[nr7] = (int)await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case nr8:
                            distribution[nr8] = (int)await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case nr9:
                            distribution[nr9] = (int)await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case nr10:
                            distribution[nr10] = (int)await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            continue;
                    }
                }

                return distribution;
            }

            return await Task.FromResult(default(IDictionary<string, int>));
        }

        internal static async Task ReadAndIgnoreInvalidContentAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            await jsonReader.ReadAsync(cancellationToken); // read unmatched property value

            if (jsonReader.TokenType == JsonToken.StartArray)
                await ReadAndIgnoreInvalidContentWithStartArrayTokenAsync(jsonReader, cancellationToken);
            else if (jsonReader.TokenType == JsonToken.StartObject)
                await ReadAndIgnoreInvalidContentWithStartObjectTokenAsync(jsonReader, cancellationToken);
        }

        internal static Task ReadAndIgnoreInvalidContentWithStartArrayTokenAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
            => ReadAndIgnoreInvalidContentAsync(jsonReader, true, false, cancellationToken);

        internal static Task ReadAndIgnoreInvalidContentWithStartObjectTokenAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
            => ReadAndIgnoreInvalidContentAsync(jsonReader, false, true, cancellationToken);

        private static async Task ReadAndIgnoreInvalidContentAsync(JsonTextReader jsonReader, bool startWithOpenBracket, bool startWithOpenBrace, CancellationToken cancellationToken = default)
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
