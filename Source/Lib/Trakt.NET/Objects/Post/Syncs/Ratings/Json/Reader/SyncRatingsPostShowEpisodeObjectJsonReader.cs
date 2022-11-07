namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncRatingsPostShowEpisodeObjectJsonReader : AObjectJsonReader<ITraktSyncRatingsPostShowEpisode>
    {
        public override async Task<ITraktSyncRatingsPostShowEpisode> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSyncRatingsPostShowEpisode syncRatingsPostShowEpisode = new TraktSyncRatingsPostShowEpisode();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NUMBER:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncRatingsPostShowEpisode.Number = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_RATING:
                            {
                                Pair<bool, int> value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncRatingsPostShowEpisode.Rating = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_RATED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncRatingsPostShowEpisode.RatedAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncRatingsPostShowEpisode;
            }

            return await Task.FromResult(default(ITraktSyncRatingsPostShowEpisode));
        }
    }
}
