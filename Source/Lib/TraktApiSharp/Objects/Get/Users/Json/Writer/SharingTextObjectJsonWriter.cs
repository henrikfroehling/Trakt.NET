namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SharingTextObjectJsonWriter : AObjectJsonWriter<ITraktSharingText>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSharingText obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Watching))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_TEXT_PROPERTY_NAME_WATCHING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Watching, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Watched))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHARING_TEXT_PROPERTY_NAME_WATCHED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Watched, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
