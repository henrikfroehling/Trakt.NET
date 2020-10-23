namespace TraktNet.Objects.Basic.Json.Writer
{
    using Get.People.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CrewMemberObjectJsonWriter : AObjectJsonWriter<ITraktCrewMember>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCrewMember obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Jobs != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_JOBS, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.Jobs, cancellationToken).ConfigureAwait(false);
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
