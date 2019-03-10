﻿namespace TraktNet.Objects.Get.Users.Statistics.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserEpisodesStatisticsObjectJsonWriter : AObjectJsonWriter<ITraktUserEpisodesStatistics>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserEpisodesStatistics obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Plays.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_PLAYS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Plays, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Watched.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_WATCHED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Watched, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Minutes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_MINUTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Minutes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Collected.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_COLLECTED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Collected, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ratings.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_RATINGS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Ratings, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Comments.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_EPISODES_STATISTICS_PROPERTY_NAME_COMMENTS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Comments, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
