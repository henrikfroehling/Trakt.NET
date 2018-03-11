namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses.Json.Writer
{
    using Get.Seasons.Json.Writer;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SyncRatingsPostResponseNotFoundSeasonObjectJsonWriter : AObjectJsonWriter<ITraktSyncRatingsPostResponseNotFoundSeason>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSyncRatingsPostResponseNotFoundSeason obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_SEASON_PROPERTY_NAME_RATING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var seasonIdsObjectJsonWriter = new SeasonIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_RATINGS_POST_RESPONSE_NOT_FOUND_SEASON_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await seasonIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
