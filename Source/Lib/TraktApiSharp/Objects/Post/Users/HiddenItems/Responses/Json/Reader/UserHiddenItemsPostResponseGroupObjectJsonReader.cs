namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostResponseGroupObjectJsonReader : AObjectJsonReader<ITraktUserHiddenItemsPostResponseGroup>
    {
        public override async Task<ITraktUserHiddenItemsPostResponseGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserHiddenItemsPostResponseGroup));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserHiddenItemsPostResponseGroup hiddenItemsPostResponseGroup = new TraktUserHiddenItemsPostResponseGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_HIDDEN_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_MOVIES:
                            hiddenItemsPostResponseGroup.Movies = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_HIDDEN_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_SHOWS:
                            hiddenItemsPostResponseGroup.Shows = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.USER_HIDDEN_ITEMS_POST_RESPONSE_GROUP_PROPERTY_NAME_SEASONS:
                            hiddenItemsPostResponseGroup.Seasons = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return hiddenItemsPostResponseGroup;
            }

            return await Task.FromResult(default(ITraktUserHiddenItemsPostResponseGroup));
        }
    }
}
