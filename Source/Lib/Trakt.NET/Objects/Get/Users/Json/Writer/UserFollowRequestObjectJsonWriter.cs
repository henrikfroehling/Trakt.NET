namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFollowRequestObjectJsonWriter : AObjectJsonWriter<ITraktUserFollowRequest>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserFollowRequest obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ID, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Id, cancellationToken).ConfigureAwait(false);

            if (obj.RequestedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_REQUESTED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.RequestedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.User != null)
            {
                var userObjectJsonWriter = new UserObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_USER, cancellationToken).ConfigureAwait(false);
                await userObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.User, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
