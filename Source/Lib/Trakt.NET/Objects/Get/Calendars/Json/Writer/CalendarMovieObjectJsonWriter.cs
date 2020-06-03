namespace TraktNet.Objects.Get.Calendars.Json.Writer
{
    using Extensions;
    using Movies.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CalendarMovieObjectJsonWriter : AObjectJsonWriter<ITraktCalendarMovie>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCalendarMovie obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.CalendarRelease.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CALENDAR_MOVIE_PROPERTY_NAME_RELEASED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CalendarRelease.Value.ToTraktDateString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CALENDAR_MOVIE_PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
