namespace TraktApiSharp.Objects.Get.Users.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AccountSettingsObjectJsonWriter : AObjectJsonWriter<ITraktAccountSettings>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktAccountSettings obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.TimeZoneId))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.ACCOUNT_SETTINGS_PROPERTY_NAME_TIMEZONE_ID, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.TimeZoneId, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Time24Hr.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.ACCOUNT_SETTINGS_PROPERTY_NAME_TIME_24HR, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Time24Hr, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.CoverImage))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.ACCOUNT_SETTINGS_PROPERTY_NAME_COVER_IMAGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CoverImage, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
