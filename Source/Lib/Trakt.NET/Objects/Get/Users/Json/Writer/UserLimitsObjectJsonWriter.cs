namespace TraktNet.Objects.Get.Users.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserLimitsObjectJsonWriter : AObjectJsonWriter<ITraktUserLimits>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserLimits obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.List != null)
            {
                var userListLimitsJsonWriter = new UserListLimitsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_LIST, cancellationToken).ConfigureAwait(false);
                await userListLimitsJsonWriter.WriteObjectAsync(jsonWriter, obj.List, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Watchlist != null)
            {
                var userWatchlistLimitsJsonWriter = new UserWatchlistLimitsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_WATCHLIST, cancellationToken).ConfigureAwait(false);
                await userWatchlistLimitsJsonWriter.WriteObjectAsync(jsonWriter, obj.Watchlist, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Recommendations != null)
            {
                var userRecommendationsLimitsJsonWriter = new UserRecommendationsLimitsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_RECOMMENDATIONS, cancellationToken).ConfigureAwait(false);
                await userRecommendationsLimitsJsonWriter.WriteObjectAsync(jsonWriter, obj.Recommendations, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Favorites != null)
            {
                var userFavoritesLimitsJsonWriter = new UserFavoritesLimitsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_FAVORITES, cancellationToken).ConfigureAwait(false);
                await userFavoritesLimitsJsonWriter.WriteObjectAsync(jsonWriter, obj.Favorites, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
