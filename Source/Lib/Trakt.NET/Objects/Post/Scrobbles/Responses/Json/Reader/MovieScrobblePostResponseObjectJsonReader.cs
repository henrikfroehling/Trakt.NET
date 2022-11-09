namespace TraktNet.Objects.Post.Scrobbles.Responses.Json.Reader
{
    using Enums;
    using Get.Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieScrobblePostResponseObjectJsonReader : AObjectJsonReader<ITraktMovieScrobblePostResponse>
    {
        public override async Task<ITraktMovieScrobblePostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var sharingReader = new ConnectionsObjectJsonReader();
                var movieReader = new MovieObjectJsonReader();
                ITraktMovieScrobblePostResponse movieScrobbleResponse = new TraktMovieScrobblePostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    movieScrobbleResponse.Id = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_ACTION:
                            movieScrobbleResponse.Action = await JsonReaderHelper.ReadEnumerationValueAsync<TraktScrobbleActionType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PROGRESS:
                            {
                                var value = await JsonReaderHelper.ReadFloatValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    movieScrobbleResponse.Progress = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SHARING:
                            movieScrobbleResponse.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
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
