namespace TraktNet.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class StatisticsObjectJsonWriter : AObjectJsonWriter<ITraktStatistics>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktStatistics obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Watchers.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_WATCHERS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Watchers, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Plays.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_PLAYS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Plays, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Collectors.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_COLLECTORS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Collectors, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CollectedEpisodes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_COLLECTED_EPISODES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectedEpisodes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Comments.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_COMMENTS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Comments, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Lists.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_LISTS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Lists, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Votes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_VOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Votes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
