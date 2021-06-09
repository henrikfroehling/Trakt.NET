namespace TraktNet.Objects.Basic.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RateLimitInfoObjectJsonWriter : AObjectJsonWriter<ITraktRateLimitInfo>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktRateLimitInfo obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Name))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NAME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Name, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Period.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PERIOD, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Period, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Limit.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LIMIT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Limit, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Remaining.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_REMAINING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Remaining, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Until.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_UNTIL, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Until.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
