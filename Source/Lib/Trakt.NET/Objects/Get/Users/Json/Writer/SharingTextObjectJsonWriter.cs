﻿namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SharingTextObjectJsonWriter : AObjectJsonWriter<ITraktSharingText>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSharingText obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Watching))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_WATCHING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Watching, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Watched))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_WATCHED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Watched, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Rated))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RATED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rated, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
