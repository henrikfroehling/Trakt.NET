namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostObjectJsonWriter : AObjectJsonWriter<ITraktSyncRatingsPost>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncRatingsPost obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies != null)
            {
                var syncRatingsPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_RATINGS_POST_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var syncRatingsPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_RATINGS_POST_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var syncRatingsPostEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_RATINGS_POST_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
