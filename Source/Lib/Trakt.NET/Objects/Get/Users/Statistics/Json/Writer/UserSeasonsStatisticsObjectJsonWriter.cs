namespace TraktNet.Objects.Get.Users.Statistics.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserSeasonsStatisticsObjectJsonWriter : AObjectJsonWriter<ITraktUserSeasonsStatistics>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserSeasonsStatistics obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Ratings.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RATINGS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Ratings, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Comments.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COMMENTS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Comments, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
