namespace TraktNet.Objects.Post.Syncs.Collection.Json.Writer
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;

    internal class ASyncCollectionPostObjectJsonWriter<TSyncCollectionPost> : AObjectJsonWriter<TSyncCollectionPost>
        where TSyncCollectionPost : ITraktSyncCollectionPost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TSyncCollectionPost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteCollectionPostObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteCollectionPostObjectAsync(JsonTextWriter jsonWriter, TSyncCollectionPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movies != null)
            {
                var syncCollectionPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktSyncCollectionPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await syncCollectionPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var syncCollectionPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktSyncCollectionPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await syncCollectionPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var syncCollectionPostSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktSyncCollectionPostSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await syncCollectionPostSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var syncCollectionPostEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktSyncCollectionPostEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncCollectionPostEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
