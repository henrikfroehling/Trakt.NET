namespace TraktNet.Objects.Post.Responses.Json.Writer
{
    using Get.People.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PostResponseNotFoundPersonObjectJsonWriter : AObjectJsonWriter<ITraktPostResponseNotFoundPerson>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktPostResponseNotFoundPerson obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Ids != null)
            {
                var personIdsObjectJsonWriter = new PersonIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.POST_RESPONSE_NOT_FOUND_EPISODE_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await personIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
