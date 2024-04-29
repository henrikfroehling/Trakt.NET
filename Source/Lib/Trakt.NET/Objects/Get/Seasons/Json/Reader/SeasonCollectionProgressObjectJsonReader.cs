﻿namespace TraktNet.Objects.Get.Seasons.Json.Reader
{
    using Episodes;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonCollectionProgressObjectJsonReader : AObjectJsonReader<ITraktSeasonCollectionProgress>
    {
        public override async Task<ITraktSeasonCollectionProgress> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeCollectionProgressArrayReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();
                ITraktSeasonCollectionProgress traktSeasonCollectionProgress = new TraktSeasonCollectionProgress();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NUMBER:
                            traktSeasonCollectionProgress.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_TITLE:
                            traktSeasonCollectionProgress.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_AIRED:
                            traktSeasonCollectionProgress.Aired = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_COMPLETED:
                            traktSeasonCollectionProgress.Completed = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            traktSeasonCollectionProgress.Episodes = await episodeCollectionProgressArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSeasonCollectionProgress;
            }

            return await Task.FromResult(default(ITraktSeasonCollectionProgress));
        }
    }
}
