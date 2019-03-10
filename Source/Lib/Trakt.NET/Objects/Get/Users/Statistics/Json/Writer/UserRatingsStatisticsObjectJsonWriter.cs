namespace TraktNet.Objects.Get.Users.Statistics.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserRatingsStatisticsObjectJsonWriter : AObjectJsonWriter<ITraktUserRatingsStatistics>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserRatingsStatistics obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Total.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_RATINGS_STATISTICS_PROPERTY_NAME_TOTAL, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Total, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Distribution != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_RATINGS_STATISTICS_PROPERTY_NAME_DISTRIBUTION, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteDistributionAsync(jsonWriter, obj.Distribution, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
