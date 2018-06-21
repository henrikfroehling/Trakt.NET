namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Basic.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserSettingsObjectJsonWriter : AObjectJsonWriter<ITraktUserSettings>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserSettings obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.User != null)
            {
                var userObjectJsonWriter = new UserObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_SETTINGS_PROPERTY_NAME_USER, cancellationToken).ConfigureAwait(false);
                await userObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.User, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Account != null)
            {
                var accountSettingsObjectJsonWriter = new AccountSettingsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_SETTINGS_PROPERTY_NAME_ACCOUNT, cancellationToken).ConfigureAwait(false);
                await accountSettingsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Account, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Connections != null)
            {
                var sharingObjectJsonWriter = new SharingObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_SETTINGS_PROPERTY_NAME_CONNECTIONS, cancellationToken).ConfigureAwait(false);
                await sharingObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Connections, cancellationToken).ConfigureAwait(false);
            }

            if (obj.SharingText != null)
            {
                var sharingTextObjectJsonWriter = new SharingTextObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_SETTINGS_PROPERTY_NAME_SHARING_TEXT, cancellationToken).ConfigureAwait(false);
                await sharingTextObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.SharingText, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
