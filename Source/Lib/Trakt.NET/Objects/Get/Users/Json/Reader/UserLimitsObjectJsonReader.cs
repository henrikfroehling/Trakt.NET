namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserLimitsObjectJsonReader : AObjectJsonReader<ITraktUserLimits>
    {
        public override async Task<ITraktUserLimits> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var userListLimitsReader = new UserListLimitsObjectJsonReader();
                var userWatchlistLimitsReader = new UserWatchlistLimitsObjectJsonReader();
                var userRecommendationsLimitsReader = new UserRecommendationsLimitsObjectJsonReader();
                var userFavoritesLimitsReader = new UserFavoritesLimitsObjectJsonReader();

                ITraktUserLimits userLimits = new TraktUserLimits();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_LIST:
                            userLimits.List = await userListLimitsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_WATCHLIST:
                            userLimits.Watchlist = await userWatchlistLimitsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_RECOMMENDATIONS:
                            userLimits.Recommendations = await userRecommendationsLimitsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_FAVORITES:
                            userLimits.Favorites = await userFavoritesLimitsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userLimits;
            }

            return await Task.FromResult(default(ITraktUserLimits));
        }
    }
}
