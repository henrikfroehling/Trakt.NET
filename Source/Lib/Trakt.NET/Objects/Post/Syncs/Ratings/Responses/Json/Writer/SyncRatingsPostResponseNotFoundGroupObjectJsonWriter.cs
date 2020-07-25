namespace TraktNet.Objects.Post.Syncs.Ratings.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundGroupObjectJsonWriter : AObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundGroup>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncRatingsPostResponseNotFoundGroup obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies != null)
            {
                var syncRatingsPostResponseNotFoundMovieArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostResponseNotFoundMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostResponseNotFoundMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var syncRatingsPostResponseNotFoundShowArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostResponseNotFoundShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostResponseNotFoundShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var syncRatingsPostResponseNotFoundSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostResponseNotFoundSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostResponseNotFoundSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var syncRatingsPostResponseNotFoundEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostResponseNotFoundEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostResponseNotFoundEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
