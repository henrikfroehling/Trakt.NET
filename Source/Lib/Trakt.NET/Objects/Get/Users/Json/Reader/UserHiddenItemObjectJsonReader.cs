namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Enums;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Reader;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemObjectJsonReader : AObjectJsonReader<ITraktUserHiddenItem>
    {
        public override async Task<ITraktUserHiddenItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserHiddenItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieReader = new MovieObjectJsonReader();
                var showReader = new ShowObjectJsonReader();
                var seasonReader = new SeasonObjectJsonReader();
                ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_HIDDEN_ITEM_PROPERTY_NAME_HIDDEN_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserHiddenItem.HiddenAt = value.Second;

                                break;
                            }
                        case JsonProperties.USER_HIDDEN_ITEM_PROPERTY_NAME_TYPE:
                            traktUserHiddenItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktHiddenItemType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_HIDDEN_ITEM_PROPERTY_NAME_MOVIE:
                            traktUserHiddenItem.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_HIDDEN_ITEM_PROPERTY_NAME_SHOW:
                            traktUserHiddenItem.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_HIDDEN_ITEM_PROPERTY_NAME_SEASON:
                            traktUserHiddenItem.Season = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktUserHiddenItem;
            }

            return await Task.FromResult(default(ITraktUserHiddenItem));
        }
    }
}
