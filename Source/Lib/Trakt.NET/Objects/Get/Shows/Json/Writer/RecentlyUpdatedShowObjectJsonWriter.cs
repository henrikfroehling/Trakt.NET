namespace TraktNet.Objects.Get.Shows.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedShowObjectJsonWriter : AObjectJsonWriter<ITraktRecentlyUpdatedShow>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktRecentlyUpdatedShow obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.RecentlyUpdatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RECENTLY_UPDATED_SHOW_PROPERTY_NAME_UPDATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.RecentlyUpdatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.RECENTLY_UPDATED_SHOW_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
