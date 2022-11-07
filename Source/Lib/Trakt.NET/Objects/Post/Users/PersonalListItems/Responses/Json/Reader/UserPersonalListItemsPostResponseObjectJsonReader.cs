namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Objects.Post.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListItemsPostResponseObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListItemsPostResponse>
    {
        public override async Task<ITraktUserPersonalListItemsPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var responseGroupReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();
                var responseNotFoundGroupReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();
                var listDataReader = new PostResponseListDataObjectJsonReader();
                ITraktUserPersonalListItemsPostResponse listItemsPostResponse = new TraktUserPersonalListItemsPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ADDED:
                            listItemsPostResponse.Added = await responseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EXISTING:
                            listItemsPostResponse.Existing = await responseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOT_FOUND:
                            listItemsPostResponse.NotFound = await responseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIST:
                            listItemsPostResponse.List = await listDataReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return listItemsPostResponse;
            }

            return await Task.FromResult(default(ITraktUserPersonalListItemsPostResponse));
        }
    }
}
