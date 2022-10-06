namespace TraktNet.Objects.Post.Syncs.Ratings.Json.Writer
{
    using Extensions;
    using Get.Seasons.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostSeasonObjectJsonWriter : AObjectJsonWriter<ITraktSyncRatingsPostSeason>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncRatingsPostSeason obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Ids != null)
            {
                var seasonIdsObjectJsonWriter = new SeasonIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await seasonIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RATING, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken).ConfigureAwait(false);

            if (obj.RatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.RatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
