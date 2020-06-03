namespace TraktNet.Objects.Get.Users.Statistics.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserShowsStatisticsObjectJsonWriter : AObjectJsonWriter<ITraktUserShowsStatistics>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserShowsStatistics obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Watched.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_SHOWS_STATISTICS_PROPERTY_NAME_WATCHED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Watched, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Collected.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_SHOWS_STATISTICS_PROPERTY_NAME_COLLECTED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Collected, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ratings.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_SHOWS_STATISTICS_PROPERTY_NAME_RATINGS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Ratings, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Comments.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_SHOWS_STATISTICS_PROPERTY_NAME_COMMENTS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Comments, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
