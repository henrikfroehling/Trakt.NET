namespace TraktNet.Objects.Post.Checkins.Responses.Json.Reader
{
    using Basic.Json.Reader;
    using Get.Episodes.Json.Reader;
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeCheckinPostResponseObjectJsonReader : AObjectJsonReader<ITraktEpisodeCheckinPostResponse>
    {
        public override async Task<ITraktEpisodeCheckinPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktEpisodeCheckinPostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var sharingReader = new SharingObjectJsonReader();
                var episodeReader = new EpisodeObjectJsonReader();
                var showReader = new ShowObjectJsonReader();
                ITraktEpisodeCheckinPostResponse checkinEpisodeResponse = new TraktEpisodeCheckinPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.CHECKIN_POST_RESPONSE_PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    checkinEpisodeResponse.Id = value.Second;

                                break;
                            }
                        case JsonProperties.CHECKIN_POST_RESPONSE_PROPERTY_NAME_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    checkinEpisodeResponse.WatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.CHECKIN_POST_RESPONSE_PROPERTY_NAME_SHARING:
                            checkinEpisodeResponse.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.EPISODE_CHECKIN_POST_RESPONSE_PROPERTY_NAME_EPISODE:
                            checkinEpisodeResponse.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.EPISODE_CHECKIN_POST_RESPONSE_PROPERTY_NAME_SHOW:
                            checkinEpisodeResponse.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return checkinEpisodeResponse;
            }

            return await Task.FromResult(default(ITraktEpisodeCheckinPostResponse));
        }
    }
}
