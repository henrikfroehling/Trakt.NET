namespace TraktNet.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowAirsObjectJsonWriter : AObjectJsonWriter<ITraktShowAirs>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktShowAirs obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Day))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_DAY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Day, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Time))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TIME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Time, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.TimeZoneId))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TIMEZONE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.TimeZoneId, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
