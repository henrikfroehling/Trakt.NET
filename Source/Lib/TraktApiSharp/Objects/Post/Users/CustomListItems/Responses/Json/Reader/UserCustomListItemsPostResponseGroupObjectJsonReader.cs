namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostResponseGroupObjectJsonReader : AObjectJsonReader<ITraktUserCustomListItemsPostResponseGroup>
    {
        public override async Task<ITraktUserCustomListItemsPostResponseGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserCustomListItemsPostResponseGroup));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserCustomListItemsPostResponseGroup customListItemsPostResponseGroup = new TraktUserCustomListItemsPostResponseGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_MOVIES:
                            customListItemsPostResponseGroup.Movies = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_SHOWS:
                            customListItemsPostResponseGroup.Shows = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_SEASONS:
                            customListItemsPostResponseGroup.Seasons = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_EPISODES:
                            customListItemsPostResponseGroup.Episodes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_PEOPLE:
                            customListItemsPostResponseGroup.People = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostResponseGroup;
            }

            return await Task.FromResult(default(ITraktUserCustomListItemsPostResponseGroup));
        }
    }
}
