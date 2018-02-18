namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Get.People.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CrewMemberObjectJsonWriter : AObjectJsonWriter<ITraktCrewMember>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCrewMember obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Job))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_MEMBER_PROPERTY_NAME_JOB, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Job, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Person != null)
            {
                var personObjectJsonWriter = new PersonObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_MEMBER_PROPERTY_NAME_PERSON, cancellationToken).ConfigureAwait(false);
                await personObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Person, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
