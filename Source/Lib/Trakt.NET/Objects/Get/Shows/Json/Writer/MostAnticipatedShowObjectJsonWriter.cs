namespace TraktNet.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostAnticipatedShowObjectJsonWriter : AObjectJsonWriter<ITraktMostAnticipatedShow>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktMostAnticipatedShow obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.ListCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOST_ANTICIPATED_SHOW_PROPERTY_NAME_LIST_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ListCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var showObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOST_ANTICIPATED_SHOW_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await showObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
