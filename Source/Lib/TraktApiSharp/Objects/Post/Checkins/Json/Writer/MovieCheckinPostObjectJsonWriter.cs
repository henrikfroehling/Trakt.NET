namespace TraktApiSharp.Objects.Post.Checkins.Json.Writer
{
    using Get.Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieCheckinPostObjectJsonWriter : ACheckinPostObjectJsonWriter<ITraktMovieCheckinPost>
    {
        protected override async Task WriteCheckinObjectAsync(JsonTextWriter jsonWriter, ITraktMovieCheckinPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_CHECKIN_POST_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
