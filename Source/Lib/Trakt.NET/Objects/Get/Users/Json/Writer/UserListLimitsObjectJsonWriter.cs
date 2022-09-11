namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserListLimitsObjectJsonWriter : AObjectJsonWriter<ITraktUserListLimits>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserListLimits obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Count.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Count, cancellationToken).ConfigureAwait(false);
            }

            if (obj.ItemCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_ITEM_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ItemCount, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
