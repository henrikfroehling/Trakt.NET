namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostResponseGroupObjectJsonReader : IObjectJsonReader<ITraktUserCustomListItemsPostResponseGroup>
    {
        public Task<ITraktUserCustomListItemsPostResponseGroup> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserCustomListItemsPostResponseGroup));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserCustomListItemsPostResponseGroup> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserCustomListItemsPostResponseGroup));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserCustomListItemsPostResponseGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
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
