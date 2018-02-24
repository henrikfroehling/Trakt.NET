namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.Json.Writer
{
    using Get.Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieScrobblePostResponseObjectJsonWriter : AScrobblePostResponseObjectJsonWriter<ITraktMovieScrobblePostResponse>
    {
        protected override async Task WriteScrobbleResponseObjectAsync(JsonTextWriter jsonWriter, ITraktMovieScrobblePostResponse obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_SCROBBLE_POST_RESPONSE_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
