namespace TraktNet.Objects.Get.Users.Lists.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Users.Json.Writer;

    internal class ListLikeObjectJsonWriter : AObjectJsonWriter<ITraktListLike>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktListLike obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.LikedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LIKED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.LikedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
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
