namespace TraktApiSharp.Objects.Post.Scrobbles.Json.Writer
{
    using Get.Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieScrobblePostObjectJsonWriter : AScrobblePostObjectJsonWriter<ITraktMovieScrobblePost>
    {
        protected override async Task WriteScrobbleObjectAsync(JsonTextWriter jsonWriter, ITraktMovieScrobblePost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_SCROBBLE_POST_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
