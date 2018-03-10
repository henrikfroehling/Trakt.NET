namespace TraktApiSharp.Objects.Post.Syncs.History.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ASyncHistoryPostObjectJsonWriter<TSyncHistoryObjectType> : AObjectJsonWriter<TSyncHistoryObjectType> where TSyncHistoryObjectType : ITraktSyncHistoryPost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TSyncHistoryObjectType obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteSyncHistoryObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteSyncHistoryObjectAsync(JsonTextWriter jsonWriter, TSyncHistoryObjectType obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movies != null)
            {
                var syncHistoryPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktSyncHistoryPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_POST_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await syncHistoryPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var syncHistoryPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktSyncHistoryPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_POST_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await syncHistoryPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var syncHistoryPostEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktSyncHistoryPostEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_HISTORY_POST_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncHistoryPostEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
