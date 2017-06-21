namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.JsonReader
{
    using Basic.JsonReader;
    using Enums;
    using Get.Movies.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktMovieScrobblePostResponseObjectJsonReader : ITraktObjectJsonReader<ITraktMovieScrobblePostResponse>
    {
        private const string PROPERTY_NAME_ID = "id";
        private const string PROPERTY_NAME_ACTION = "action";
        private const string PROPERTY_NAME_PROGRESS = "progress";
        private const string PROPERTY_NAME_SHARING = "sharing";
        private const string PROPERTY_NAME_MOVIE = "movie";

        public Task<ITraktMovieScrobblePostResponse> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktMovieScrobblePostResponse));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktMovieScrobblePostResponse> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktMovieScrobblePostResponse));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktMovieScrobblePostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktMovieScrobblePostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var sharingReader = new TraktSharingObjectJsonReader();
                var movieReader = new TraktMovieObjectJsonReader();
                ITraktMovieScrobblePostResponse movieScrobbleResponse = new TraktMovieScrobblePostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongIntegerAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    movieScrobbleResponse.Id = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_ACTION:
                            movieScrobbleResponse.Action = await JsonReaderHelper.ReadEnumerationValueAsync<TraktScrobbleActionType>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_PROGRESS:
                            {
                                var value = await JsonReaderHelper.ReadFloatValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    movieScrobbleResponse.Progress = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_SHARING:
                            movieScrobbleResponse.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_MOVIE:
                            movieScrobbleResponse.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return movieScrobbleResponse;
            }

            return await Task.FromResult(default(ITraktMovieScrobblePostResponse));
        }
    }
}
