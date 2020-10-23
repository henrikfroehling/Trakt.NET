namespace TraktNet.Objects.Post.Users.CustomListItems.Json.Reader
{
    using Get.People;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostObjectJsonReader : AObjectJsonReader<ITraktUserCustomListItemsPost>
    {
        public override async Task<ITraktUserCustomListItemsPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieArrayJsonReader = new ArrayJsonReader<ITraktUserCustomListItemsPostMovie>();
                var showArrayJsonReader = new ArrayJsonReader<ITraktUserCustomListItemsPostShow>();
                var personArrayJsonReader = new ArrayJsonReader<ITraktPerson>();
                ITraktUserCustomListItemsPost customListItemsPost = new TraktUserCustomListItemsPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            customListItemsPost.Movies = await movieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            customListItemsPost.Shows = await showArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PEOPLE:
                            customListItemsPost.People = await personArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPost;
            }

            return await Task.FromResult(default(ITraktUserCustomListItemsPost));
        }
    }
}
