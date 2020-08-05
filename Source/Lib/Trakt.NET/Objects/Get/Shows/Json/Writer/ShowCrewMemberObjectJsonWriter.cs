namespace TraktNet.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Get.People.Json.Writer;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCrewMemberObjectJsonWriter : AObjectJsonWriter<ITraktShowCrewMember>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktShowCrewMember obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Jobs != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_JOBS, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.Jobs, cancellationToken).ConfigureAwait(false);
            }

            if (obj.EpisodeCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODE_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.EpisodeCount.Value, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Person != null)
            {
                var personObjectJsonWriter = new PersonObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PERSON, cancellationToken).ConfigureAwait(false);
                await personObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Person, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
