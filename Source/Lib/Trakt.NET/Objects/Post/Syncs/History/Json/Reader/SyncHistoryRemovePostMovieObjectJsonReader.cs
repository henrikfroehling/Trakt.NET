namespace TraktNet.Objects.Post.Syncs.History.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Movies.Json.Reader;
    using TraktNet.Objects.Json;

    internal class SyncHistoryRemovePostMovieObjectJsonReader : AObjectJsonReader<ITraktSyncHistoryRemovePostMovie>
    {
        public override async Task<ITraktSyncHistoryRemovePostMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieIdsReader = new MovieIdsObjectJsonReader();
                ITraktSyncHistoryRemovePostMovie syncHistoryRemovePostMovie = new TraktSyncHistoryRemovePostMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_TITLE:
                            syncHistoryRemovePostMovie.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_YEAR:
                            syncHistoryRemovePostMovie.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_IDS:
                            syncHistoryRemovePostMovie.Ids = await movieIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return syncHistoryRemovePostMovie;
            }

            return await Task.FromResult(default(ITraktSyncHistoryRemovePostMovie));
        }
    }
}
