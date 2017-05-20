namespace TraktApiSharp.Objects.Basic.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktRatingObjectJsonReader : ITraktObjectJsonReader<ITraktRating>
    {
        private const string PROPERTY_NAME_RATING = "rating";
        private const string PROPERTY_NAME_VOTES = "votes";
        private const string PROPERTY_NAME_DISTRIBUTION = "distribution";

        public Task<ITraktRating> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktRating));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktRating> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktRating));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktRating> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktRating));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktRating traktRating = new TraktRating();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_RATING:
                            traktRating.Rating = (float?)await jsonReader.ReadAsDoubleAsync(cancellationToken);
                            break;
                        case PROPERTY_NAME_VOTES:
                            traktRating.Votes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_DISTRIBUTION:
                            await ReadDistributionAsync(jsonReader, traktRating, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktRating;
            }

            return await Task.FromResult(default(ITraktRating));
        }

        private static async Task ReadDistributionAsync(JsonTextReader jsonReader, ITraktRating traktRating, CancellationToken cancellationToken = default(CancellationToken))
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
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            continue;
                    }
                }

                traktRating.Distribution = distribution;
            }
        }
    }
}
