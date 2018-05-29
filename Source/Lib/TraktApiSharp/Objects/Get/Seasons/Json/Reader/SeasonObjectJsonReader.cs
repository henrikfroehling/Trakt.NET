namespace TraktApiSharp.Objects.Get.Seasons.Json.Reader
{
    using Episodes.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonObjectJsonReader : AObjectJsonReader<ITraktSeason>
    {
        public override async Task<ITraktSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSeason));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsObjectReader = new SeasonIdsObjectJsonReader();
                var episodesArrayReader = new EpisodeArrayJsonReader();
                ITraktSeason traktSeason = new TraktSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SEASON_PROPERTY_NAME_NUMBER:
                            traktSeason.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SEASON_PROPERTY_NAME_TITLE:
                            traktSeason.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SEASON_PROPERTY_NAME_IDS:
                            traktSeason.Ids = await idsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.SEASON_PROPERTY_NAME_RATING:
                            traktSeason.Rating = (float?)await jsonReader.ReadAsDoubleAsync(cancellationToken);
                            break;
                        case JsonProperties.SEASON_PROPERTY_NAME_VOTES:
                            traktSeason.Votes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SEASON_PROPERTY_NAME_EPISODE_COUNT:
                            traktSeason.TotalEpisodesCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SEASON_PROPERTY_NAME_AIRED_EPISODES:
                            traktSeason.AiredEpisodesCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SEASON_PROPERTY_NAME_OVERVIEW:
                            traktSeason.Overview = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SEASON_PROPERTY_NAME_FIRST_AIRED:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktSeason.FirstAired = value.Second;

                                break;
                            }
                        case JsonProperties.SEASON_PROPERTY_NAME_NETWORK:
                            traktSeason.Network = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SEASON_PROPERTY_NAME_EPISODES:
                            traktSeason.Episodes = await episodesArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSeason;
            }

            return await Task.FromResult(default(ITraktSeason));
        }
    }
}
