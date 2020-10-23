namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AccountSettingsObjectJsonWriter : AObjectJsonWriter<ITraktAccountSettings>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktAccountSettings obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.TimeZoneId))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TIMEZONE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.TimeZoneId, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Time24Hr.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TIME_24HR, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Time24Hr, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.CoverImage))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COVER_IMAGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CoverImage, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Token))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TOKEN, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Token, cancellationToken).ConfigureAwait(false);
            }

            if (obj.DateFormat != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_DATE_FORMAT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.DateFormat.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
