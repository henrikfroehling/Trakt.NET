namespace TraktNet.Objects.Post.Notes.Json.Writer
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Episodes.Json.Writer;
    using TraktNet.Objects.Get.Movies.Json.Writer;
    using TraktNet.Objects.Get.Notes.Json.Writer;
    using TraktNet.Objects.Get.People.Json.Writer;
    using TraktNet.Objects.Get.Seasons.Json.Writer;
    using TraktNet.Objects.Get.Shows.Json.Writer;
    using TraktNet.Objects.Json;

    internal sealed class NotePostObjectJsonWriter : AObjectJsonWriter<ITraktNotePost>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktNotePost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.AttachedTo != null)
            {
                var noteAttachedToWriter = new NoteAttachedToObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ATTACHED_TO, cancellationToken).ConfigureAwait(false);
                await noteAttachedToWriter.WriteObjectAsync(jsonWriter, obj.AttachedTo, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Spoiler.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SPOILER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Spoiler.Value, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Privacy != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PRIVACY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Privacy.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Notes))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Notes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Season != null)
            {
                var seasonWriter = new SeasonObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASON, cancellationToken).ConfigureAwait(false);
                await seasonWriter.WriteObjectAsync(jsonWriter, obj.Season, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episode != null)
            {
                var episodeWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeWriter.WriteObjectAsync(jsonWriter, obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Person != null)
            {
                var personWriter = new PersonObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PERSON, cancellationToken).ConfigureAwait(false);
                await personWriter.WriteObjectAsync(jsonWriter, obj.Person, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
