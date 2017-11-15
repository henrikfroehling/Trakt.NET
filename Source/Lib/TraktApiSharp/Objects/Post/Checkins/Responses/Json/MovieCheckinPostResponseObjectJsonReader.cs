namespace TraktApiSharp.Objects.Post.Checkins.Responses.Json
{
    using Basic.Json;
    using Get.Movies.Json;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieCheckinPostResponseObjectJsonReader : IObjectJsonReader<ITraktMovieCheckinPostResponse>
    {
        private const string PROPERTY_NAME_ID = "id";
        private const string PROPERTY_NAME_WATCHED_AT = "watched_at";
        private const string PROPERTY_NAME_SHARING = "sharing";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public Task<ITraktMovieCheckinPostResponse> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktMovieCheckinPostResponse));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktMovieCheckinPostResponse> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktMovieCheckinPostResponse));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktMovieCheckinPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
                        case PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongIntegerAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    checkinMovieResponse.Id = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    checkinMovieResponse.WatchedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_SHARING:
                            checkinMovieResponse.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_MOVIE:
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
