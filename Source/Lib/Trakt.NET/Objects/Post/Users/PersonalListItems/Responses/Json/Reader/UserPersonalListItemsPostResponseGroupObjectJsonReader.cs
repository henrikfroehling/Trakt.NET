namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListItemsPostResponseGroupObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListItemsPostResponseGroup>
    {
        public override async Task<ITraktUserPersonalListItemsPostResponseGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserPersonalListItemsPostResponseGroup customListItemsPostResponseGroup = new TraktUserPersonalListItemsPostResponseGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            customListItemsPostResponseGroup.Movies = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            customListItemsPostResponseGroup.Shows = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            customListItemsPostResponseGroup.Seasons = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            customListItemsPostResponseGroup.Episodes = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PEOPLE:
                            customListItemsPostResponseGroup.People = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostResponseGroup;
            }

            return await Task.FromResult(default(ITraktUserPersonalListItemsPostResponseGroup));
        }
    }
}
