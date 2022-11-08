namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Writer
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;

    internal abstract class ASyncRatingsPostObjectJsonWriter<TSyncRatingsPost> : AObjectJsonWriter<TSyncRatingsPost>
        where TSyncRatingsPost : ITraktSyncRatingsPost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TSyncRatingsPost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteRatingsPostObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteRatingsPostObjectAsync(JsonTextWriter jsonWriter, TSyncRatingsPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movies != null)
            {
                var syncRatingsPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var syncRatingsPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var syncRatingsPostSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var syncRatingsPostEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
