namespace TraktApiSharp.Objects.Get.Users.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserFriendObjectJsonWriter : AObjectJsonWriter<ITraktUserFriend>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserFriend obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.FriendsAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_FRIEND_PROPERTY_NAME_FRIENDS_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.FriendsAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.User != null)
            {
                var userObjectJsonWriter = new UserObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_FRIEND_PROPERTY_NAME_USER, cancellationToken).ConfigureAwait(false);
                await userObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.User, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
