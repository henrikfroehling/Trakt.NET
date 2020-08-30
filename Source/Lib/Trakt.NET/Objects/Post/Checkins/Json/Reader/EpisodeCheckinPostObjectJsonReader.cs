namespace TraktNet.Objects.Post.Checkins.Json.Reader
{
    using Basic.Json.Reader;
    using Get.Episodes.Json.Reader;
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCheckinPostObjectJsonReader : AObjectJsonReader<ITraktEpisodeCheckinPost>
    {
        public override async Task<ITraktEpisodeCheckinPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var sharingReader = new SharingObjectJsonReader();
                var episodeReader = new EpisodeObjectJsonReader();
                var showReader = new ShowObjectJsonReader();
                ITraktEpisodeCheckinPost episodeCheckinPost = new TraktEpisodeCheckinPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_SHARING:
                            episodeCheckinPost.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MESSAGE:
                            episodeCheckinPost.Message = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_APP_VERSION:
                            episodeCheckinPost.AppVersion = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_APP_DATE:
                            episodeCheckinPost.AppDate = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_VENUE_ID:
                            episodeCheckinPost.FoursquareVenueId = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_VENUE_NAME:
                            episodeCheckinPost.FoursquareVenueName = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            episodeCheckinPost.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE:
                            episodeCheckinPost.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return episodeCheckinPost;
            }

            return await Task.FromResult(default(ITraktEpisodeCheckinPost));
        }
    }
}
