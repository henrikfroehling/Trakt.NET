namespace TraktNet.Objects.Authentication.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class DeviceObjectJsonWriter : AObjectJsonWriter<ITraktDevice>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktDevice obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.DeviceCode))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_DEVICE_CODE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.DeviceCode, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.UserCode))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_USER_CODE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.UserCode, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.VerificationUrl))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_VERIFICATION_URL, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.VerificationUrl, cancellationToken).ConfigureAwait(false);
            }

            if (obj.ExpiresInSeconds > 0)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EXPIRES_IN, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ExpiresInSeconds, cancellationToken).ConfigureAwait(false);
            }

            if (obj.IntervalInSeconds > 0)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_INTERVAL, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.IntervalInSeconds, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
