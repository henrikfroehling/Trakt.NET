namespace TraktNet.Objects.Get.Users.Statistics.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserNetworkStatisticsObjectJsonWriter : AObjectJsonWriter<ITraktUserNetworkStatistics>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserNetworkStatistics obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Friends.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_FRIENDS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Friends, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Followers.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_FOLLOWERS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Followers, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Following.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_FOLLOWING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Following, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
