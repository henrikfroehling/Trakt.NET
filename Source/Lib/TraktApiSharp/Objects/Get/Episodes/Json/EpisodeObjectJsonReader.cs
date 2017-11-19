namespace TraktApiSharp.Objects.Get.Episodes.Json
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeObjectJsonReader : IObjectJsonReader<ITraktEpisode>
    {
        public Task<ITraktEpisode> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktEpisode));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktEpisode> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktEpisode));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktEpisode));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsObjectReader = new EpisodeIdsObjectJsonReader();
                var translationArrayReader = new EpisodeTranslationArrayJsonReader();
                ITraktEpisode traktEpisode = new TraktEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.EPISODE_PROPERTY_NAME_SEASON_NUMBER:
                            traktEpisode.SeasonNumber = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_PROPERTY_NAME_NUMBER:
                            traktEpisode.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_PROPERTY_NAME_TITLE:
                            traktEpisode.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_PROPERTY_NAME_IDS:
                            traktEpisode.Ids = await idsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.EPISODE_PROPERTY_NAME_NUMBER_ABSOLUTE:
                            traktEpisode.NumberAbsolute = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_PROPERTY_NAME_OVERVIEW:
                            traktEpisode.Overview = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_PROPERTY_NAME_RUNTIME:
                            traktEpisode.Runtime = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_PROPERTY_NAME_RATING:
                            traktEpisode.Rating = (float?)await jsonReader.ReadAsDoubleAsync(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_PROPERTY_NAME_VOTES:
                            traktEpisode.Votes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_PROPERTY_NAME_FIRST_AIRED:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktEpisode.FirstAired = value.Second;

                                break;
                            }
                        case JsonProperties.EPISODE_PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktEpisode.UpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.EPISODE_PROPERTY_NAME_AVAILABLE_TRANSLATIONS:
                            traktEpisode.AvailableTranslationLanguageCodes = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.EPISODE_PROPERTY_NAME_TRANSLATIONS:
                            traktEpisode.Translations = await translationArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktEpisode;
            }

            return await Task.FromResult(default(ITraktEpisode));
        }
    }
}
