namespace TraktNet.Objects.Get.Calendars.Json.Writer
{
    using Episodes.Json.Writer;
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Writer;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CalendarShowObjectJsonWriter : AObjectJsonWriter<ITraktCalendarShow>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCalendarShow obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.FirstAiredInCalendar.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CALENDAR_SHOW_PROPERTY_NAME_FIRST_AIRED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.FirstAiredInCalendar.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CALENDAR_SHOW_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episode != null)
            {
                var episodeObjectJsonWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CALENDAR_SHOW_PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
