namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostShowSeasonObjectJsonWriter : AObjectJsonWriter<ITraktSyncRatingsPostShowSeason>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncRatingsPostShowSeason obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.RatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.RatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RATING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);

            if (obj.Episodes != null)
            {
                var syncRatingsPostShowEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktSyncRatingsPostShowEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await syncRatingsPostShowEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
