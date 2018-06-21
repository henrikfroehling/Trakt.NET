namespace TraktNet.Objects.Basic.Json.Writer
{
    using Get.People.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CastMemberObjectJsonWriter : AObjectJsonWriter<ITraktCastMember>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCastMember obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Character))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CAST_MEMBER_PROPERTY_NAME_CHARACTER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Character, cancellationToken).ConfigureAwait(false);
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
