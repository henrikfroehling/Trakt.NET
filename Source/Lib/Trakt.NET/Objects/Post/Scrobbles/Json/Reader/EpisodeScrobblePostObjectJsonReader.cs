namespace TraktNet.Objects.Post.Scrobbles.Json.Reader
{
    using Get.Episodes.Json.Reader;
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class EpisodeScrobblePostObjectJsonReader : AObjectJsonReader<ITraktEpisodeScrobblePost>
    {
        public override async Task<ITraktEpisodeScrobblePost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktEpisodeScrobblePost));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var episodeReader = new EpisodeObjectJsonReader();
                var showReader = new ShowObjectJsonReader();
                ITraktEpisodeScrobblePost episodeScrobblePost = new TraktEpisodeScrobblePost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SCROBBLE_POST_PROPERTY_NAME_PROGRESS:
                            {
                                Pair<bool, float> value = await JsonReaderHelper.ReadFloatValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    episodeScrobblePost.Progress = value.Second;

                                break;
                            }
                        case JsonProperties.SCROBBLE_POST_PROPERTY_NAME_APP_VERSION:
                            episodeScrobblePost.AppVersion = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SCROBBLE_POST_PROPERTY_NAME_APP_DATE:
                            episodeScrobblePost.AppDate = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.EPISODE_SCROBBLE_POST_PROPERTY_NAME_SHOW:
                            episodeScrobblePost.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.EPISODE_SCROBBLE_POST_PROPERTY_NAME_EPISODE:
                            episodeScrobblePost.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return episodeScrobblePost;
            }

            return await Task.FromResult(default(ITraktEpisodeScrobblePost));
        }
    }
}
