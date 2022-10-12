namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
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
                var listDataReader = new UserPersonalListItemsPostResponseListDataObjectJsonReader();
                ITraktUserPersonalListItemsPostResponse customListItemsPostResponse = new TraktUserPersonalListItemsPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ADDED:
                            customListItemsPostResponse.Added = await responseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EXISTING:
                            customListItemsPostResponse.Existing = await responseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOT_FOUND:
                            customListItemsPostResponse.NotFound = await responseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIST:
                            customListItemsPostResponse.List = await listDataReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostResponse;
            }

            return await Task.FromResult(default(ITraktUserPersonalListItemsPostResponse));
        }
    }
}
