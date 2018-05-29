namespace TraktApiSharp.Objects.Post.Responses.Json.Reader
{
    using Get.Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundMovieObjectJsonReader : AObjectJsonReader<ITraktPostResponseNotFoundMovie>
    {
        public override async Task<ITraktPostResponseNotFoundMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPostResponseNotFoundMovie));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieIdsReader = new MovieIdsObjectJsonReader();
                ITraktPostResponseNotFoundMovie postResponseNotFoundMovie = new TraktPostResponseNotFoundMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.POST_RESPONSE_NOT_FOUND_MOVIE_PROPERTY_NAME_IDS:
                            postResponseNotFoundMovie.Ids = await movieIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return postResponseNotFoundMovie;
            }

            return await Task.FromResult(default(ITraktPostResponseNotFoundMovie));
        }
    }
}
