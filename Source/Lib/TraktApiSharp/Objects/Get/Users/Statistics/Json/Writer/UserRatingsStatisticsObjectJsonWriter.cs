namespace TraktApiSharp.Objects.Get.Users.Statistics.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserRatingsStatisticsObjectJsonWriter : AObjectJsonWriter<ITraktUserRatingsStatistics>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserRatingsStatistics obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

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
