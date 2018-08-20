namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Get.Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class SyncHistoryPostMovieObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryPostMovie>
    {
        public override async Task<ITraktSyncHistoryPostMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSyncHistoryPostMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieIdsReader = new MovieIdsObjectJsonReader();
                ITraktSyncHistoryPostMovie syncHistoryPostMovie = new TraktSyncHistoryPostMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SYNC_HISTORY_POST_MOVIE_PROPERTY_NAME_WATCHED_AT:
                            {
                                Pair<bool, DateTime> value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    syncHistoryPostMovie.WatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.SYNC_HISTORY_POST_MOVIE_PROPERTY_NAME_TITLE:
                            syncHistoryPostMovie.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SYNC_HISTORY_POST_MOVIE_PROPERTY_NAME_YEAR:
                            syncHistoryPostMovie.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.SYNC_HISTORY_POST_MOVIE_PROPERTY_NAME_IDS:
                            syncHistoryPostMovie.Ids = await movieIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryPostMovie;
            }

            return await Task.FromResult(default(ITraktSyncHistoryPostMovie));
        }
    }
}
