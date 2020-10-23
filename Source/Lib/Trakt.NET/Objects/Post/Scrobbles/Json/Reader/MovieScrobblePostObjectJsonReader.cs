namespace TraktNet.Objects.Post.Scrobbles.Json.Reader
{
    using Get.Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal class MovieScrobblePostObjectJsonReader : AObjectJsonReader<ITraktMovieScrobblePost>
    {
        public override async Task<ITraktMovieScrobblePost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieReader = new MovieObjectJsonReader();
                ITraktMovieScrobblePost movieScrobblePost = new TraktMovieScrobblePost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_PROGRESS:
                            {
                                Pair<bool, float> value = await JsonReaderHelper.ReadFloatValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    movieScrobblePost.Progress = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_APP_VERSION:
                            movieScrobblePost.AppVersion = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_APP_DATE:
                            movieScrobblePost.AppDate = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            movieScrobblePost.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return movieScrobblePost;
            }

            return await Task.FromResult(default(ITraktMovieScrobblePost));
        }
    }
}
