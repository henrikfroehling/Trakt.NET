namespace TraktNet.Objects.Post.Comments.Json.Writer
{
    using Get.Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieCommentPostObjectJsonWriter : ACommentPostObjectJsonWriter<ITraktMovieCommentPost>
    {
        protected override async Task WriteCommentObjectAsync(JsonTextWriter jsonWriter, ITraktMovieCommentPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_COMMENT_POST_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
