namespace TraktApiSharp.Objects.Post.Syncs.Collection.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncCollectionPostObjectJsonWriter : AObjectJsonWriter<ITraktSyncCollectionPost>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncCollectionPost obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies != null)
            {
                var syncCollectionPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktSyncCollectionPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await syncCollectionPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var syncCollectionPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktSyncCollectionPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await syncCollectionPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var syncCollectionPostEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktSyncCollectionPostEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_COLLECTION_POST_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncCollectionPostEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
