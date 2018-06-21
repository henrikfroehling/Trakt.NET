namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserObjectJsonWriter : AObjectJsonWriter<ITraktUser>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUser obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Username))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_USERNAME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Username, cancellationToken).ConfigureAwait(false);
            }

            if (obj.IsPrivate.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_IS_PRIVATE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.IsPrivate, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var userIdsObjectJsonWriter = new UserIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await userIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Name))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_NAME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Name, cancellationToken).ConfigureAwait(false);
            }

            if (obj.IsVIP.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_IS_VIP, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.IsVIP, cancellationToken).ConfigureAwait(false);
            }

            if (obj.IsVIP_EP.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_IS_VIP_EP, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.IsVIP_EP, cancellationToken).ConfigureAwait(false);
            }

            if (obj.JoinedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_JOINED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.JoinedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Location))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_LOCATION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Location, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.About))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_ABOUT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.About, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Gender))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_GENDER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Gender, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Age.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_AGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Age, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Images != null)
            {
                var userImagesObjectJsonWriter = new UserImagesObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_PROPERTY_NAME_IMAGES, cancellationToken).ConfigureAwait(false);
                await userImagesObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Images, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
