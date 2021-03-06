﻿namespace TraktNet.Objects.Basic.Json.Writer
{
    using Get.People.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CastMemberObjectJsonWriter : AObjectJsonWriter<ITraktCastMember>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCastMember obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Characters != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_CHARACTERS, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.Characters, cancellationToken).ConfigureAwait(false);
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
