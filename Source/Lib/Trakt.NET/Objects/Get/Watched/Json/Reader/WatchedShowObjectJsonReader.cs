namespace TraktNet.Objects.Get.Watched.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class WatchedShowObjectJsonReader : AObjectJsonReader<ITraktWatchedShow>
    {
        public override async Task<ITraktWatchedShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ShowObjectJsonReader();
                var showSeasonsArrayReader = new ArrayJsonReader<ITraktWatchedShowSeason>();

                ITraktWatchedShow traktWatchedShow = new TraktWatchedShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_PLAYS:
                            traktWatchedShow.Plays = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LAST_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktWatchedShow.LastWatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_LAST_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktWatchedShow.LastUpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_RESET_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktWatchedShow.ResetAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            traktWatchedShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            traktWatchedShow.WatchedSeasons = await showSeasonsArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktWatchedShow;
            }

            return await Task.FromResult(default(ITraktWatchedShow));
        }
    }
}
