namespace TraktNet.Objects.Get.Movies.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class BoxOfficeMovieObjectJsonWriter : AObjectJsonWriter<ITraktBoxOfficeMovie>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktBoxOfficeMovie obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Revenue.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.BOX_OFFICE_MOVIE_PROPERTY_NAME_REVENUE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Revenue, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.BOX_OFFICE_MOVIE_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
