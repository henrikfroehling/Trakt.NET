namespace TraktNet.Objects.Get.Users.Statistics.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserStatisticsObjectJsonWriter : AObjectJsonWriter<ITraktUserStatistics>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserStatistics obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies != null)
            {
                var userMoviesStatisticsObjectJsonWriter = new UserMoviesStatisticsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_STATISTICS_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await userMoviesStatisticsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var userShowsStatisticsObjectJsonWriter = new UserShowsStatisticsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_STATISTICS_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await userShowsStatisticsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var userSeasonsStatisticsObjectJsonWriter = new UserSeasonsStatisticsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_STATISTICS_PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await userSeasonsStatisticsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var userEpisodesStatisticsObjectJsonWriter = new UserEpisodesStatisticsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_STATISTICS_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await userEpisodesStatisticsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Network != null)
            {
                var userNetworkStatisticsObjectJsonWriter = new UserNetworkStatisticsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_STATISTICS_PROPERTY_NAME_NETWORK, cancellationToken).ConfigureAwait(false);
                await userNetworkStatisticsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Network, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ratings != null)
            {
                var userRatingsStatisticsObjectJsonWriter = new UserRatingsStatisticsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_STATISTICS_PROPERTY_NAME_RATINGS, cancellationToken).ConfigureAwait(false);
                await userRatingsStatisticsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ratings, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
