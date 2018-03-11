namespace TraktApiSharp.Objects.Get.Movies.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedMovieObjectJsonWriter : AObjectJsonWriter<ITraktRecentlyUpdatedMovie>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktRecentlyUpdatedMovie obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.RecentlyUpdatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RECENTLY_UPDATED_MOVIE_PROPERTY_NAME_UPDATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.RecentlyUpdatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RECENTLY_UPDATED_MOVIE_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
