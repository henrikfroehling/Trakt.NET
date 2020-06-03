namespace TraktNet.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Get.People.Json.Writer;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCastMemberObjectJsonWriter : AObjectJsonWriter<ITraktShowCastMember>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktShowCastMember obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Character))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CAST_MEMBER_PROPERTY_NAME_CHARACTER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Character, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Characters != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CAST_MEMBER_PROPERTY_NAME_CHARACTERS, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.Characters, cancellationToken).ConfigureAwait(false);
            }

            if (obj.EpisodeCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_CAST_MEMBER_PROPERTY_NAME_EPISODE_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.EpisodeCount.Value, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Person != null)
            {
                var personObjectJsonWriter = new PersonObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CAST_MEMBER_PROPERTY_NAME_PERSON, cancellationToken).ConfigureAwait(false);
                await personObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Person, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
