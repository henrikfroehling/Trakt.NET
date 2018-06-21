namespace TraktNet.Objects.Post.Checkins.Responses.Json.Reader
{
    using Basic.Json.Reader;
    using Get.Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieCheckinPostResponseObjectJsonReader : AObjectJsonReader<ITraktMovieCheckinPostResponse>
    {
        public override async Task<ITraktMovieCheckinPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktMovieCheckinPostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var sharingReader = new SharingObjectJsonReader();
                var movieReader = new MovieObjectJsonReader();
                ITraktMovieCheckinPostResponse checkinMovieResponse = new TraktMovieCheckinPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.CHECKIN_POST_RESPONSE_PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongIntegerAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    checkinMovieResponse.Id = value.Second;

                                break;
                            }
                        case JsonProperties.CHECKIN_POST_RESPONSE_PROPERTY_NAME_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    checkinMovieResponse.WatchedAt = value.Second;

                                break;
                            }
                        case JsonProperties.CHECKIN_POST_RESPONSE_PROPERTY_NAME_SHARING:
                            checkinMovieResponse.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.MOVIE_CHECKIN_POST_RESPONSE_PROPERTY_NAME_MOVIE:
                            checkinMovieResponse.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return checkinMovieResponse;
            }

            return await Task.FromResult(default(ITraktMovieCheckinPostResponse));
        }
    }
}
