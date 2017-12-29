namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class StatisticsObjectJsonWriter : IObjectJsonWriter<ITraktStatistics>
    {
        public Task<string> WriteObjectAsync(ITraktStatistics obj, CancellationToken cancellationToken = default)
        {
            using (var writer = new StringWriter())
            {
                return WriteObjectAsync(writer, obj, cancellationToken);
            }
        }

        public async Task<string> WriteObjectAsync(StringWriter writer, ITraktStatistics obj, CancellationToken cancellationToken = default)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            using (var jsonWriter = new JsonTextWriter(writer))
            {
                await WriteObjectAsync(jsonWriter, obj, cancellationToken);
            }

            return writer.ToString();
        }

        public async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktStatistics obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (obj.Watchers.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_WATCHERS, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Watchers, cancellationToken);
            }

            if (obj.Plays.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_PLAYS, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Plays, cancellationToken);
            }

            if (obj.Collectors.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_COLLECTORS, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Collectors, cancellationToken);
            }

            if (obj.CollectedEpisodes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_COLLECTED_EPISODES, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.CollectedEpisodes, cancellationToken);
            }

            if (obj.Comments.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_COMMENTS, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Comments, cancellationToken);
            }

            if (obj.Lists.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_LISTS, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Lists, cancellationToken);
            }

            if (obj.Votes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.STATISTICS_PROPERTY_NAME_VOTES, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Votes, cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
