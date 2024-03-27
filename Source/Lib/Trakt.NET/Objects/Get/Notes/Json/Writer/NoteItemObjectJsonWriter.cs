namespace TraktNet.Objects.Get.Notes.Json.Writer
{
    using Get.Episodes.Json.Writer;
    using Get.Movies.Json.Writer;
    using Get.People.Json.Writer;
    using Get.Seasons.Json.Writer;
    using Get.Shows.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class NoteItemObjectJsonWriter : AObjectJsonWriter<ITraktNoteItem>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktNoteItem obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.AttachedTo != null)
            {
                var attachedToObjectWriter = new NoteAttachedToObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ATTACHED_TO, cancellationToken).ConfigureAwait(false);
                await attachedToObjectWriter.WriteObjectAsync(obj.AttachedTo, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Type != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Type.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectWriter.WriteObjectAsync(obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectWriter.WriteObjectAsync(obj.Show, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Season != null)
            {
                var seasonObjectWriter = new SeasonObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASON, cancellationToken).ConfigureAwait(false);
                await seasonObjectWriter.WriteObjectAsync(obj.Season, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episode != null)
            {
                var episodeObjectWriter = new EpisodeObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODE, cancellationToken).ConfigureAwait(false);
                await episodeObjectWriter.WriteObjectAsync(obj.Episode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Person != null)
            {
                var personObjectWriter = new PersonObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PERSON, cancellationToken).ConfigureAwait(false);
                await personObjectWriter.WriteObjectAsync(obj.Person, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Note != null)
            {
                var userNoteObjectWriter = new NoteObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NOTE, cancellationToken).ConfigureAwait(false);
                await userNoteObjectWriter.WriteObjectAsync(obj.Note, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
