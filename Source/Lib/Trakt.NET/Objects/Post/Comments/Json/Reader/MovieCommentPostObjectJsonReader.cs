namespace TraktNet.Objects.Post.Comments.Json.Reader
{
    using Get.Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Basic.Json.Reader;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieCommentPostObjectJsonReader : AObjectJsonReader<ITraktMovieCommentPost>
    {
        public override async Task<ITraktMovieCommentPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var sharingReader = new SharingObjectJsonReader();
                var movieReader = new MovieObjectJsonReader();
                ITraktMovieCommentPost movieCommentPost = new TraktMovieCommentPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_COMMENT:
                            movieCommentPost.Comment = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SPOILER:
                            {
                                bool? value = await jsonReader.ReadAsBooleanAsync(cancellationToken);

                                if (value.HasValue)
                                    movieCommentPost.Spoiler = value.Value;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SHARING:
                            movieCommentPost.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            movieCommentPost.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return movieCommentPost;
            }

            return await Task.FromResult(default(ITraktMovieCommentPost));
        }
    }
}
