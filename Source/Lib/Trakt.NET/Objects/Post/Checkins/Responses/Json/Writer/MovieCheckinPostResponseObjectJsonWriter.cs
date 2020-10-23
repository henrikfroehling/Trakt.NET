namespace TraktNet.Objects.Post.Checkins.Responses.Json.Writer
{
    using Get.Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieCheckinPostResponseObjectJsonWriter : ACheckinPostResponstObjectJsonWriter<ITraktMovieCheckinPostResponse>
    {
        protected override async Task WriteCheckinResponseObjectAsync(JsonTextWriter jsonWriter, ITraktMovieCheckinPostResponse obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
