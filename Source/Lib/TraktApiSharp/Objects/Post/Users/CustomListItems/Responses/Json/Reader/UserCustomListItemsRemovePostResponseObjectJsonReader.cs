namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsRemovePostResponseObjectJsonReader : AObjectJsonReader<ITraktUserCustomListItemsRemovePostResponse>
    {
        public override async Task<ITraktUserCustomListItemsRemovePostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserCustomListItemsRemovePostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var responseGroupReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();
                var responseNotFoundGroupReader = new UserCustomListItemsPostResponseNotFoundGroupObjectJsonReader();
                ITraktUserCustomListItemsRemovePostResponse customListItemsRemovePostResponse = new TraktUserCustomListItemsRemovePostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_REMOVE_POST_RESPONSE_PROPERTY_NAME_DELETED:
                            customListItemsRemovePostResponse.Deleted = await responseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_REMOVE_POST_RESPONSE_PROPERTY_NAME_NOT_FOUND:
                            customListItemsRemovePostResponse.NotFound = await responseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsRemovePostResponse;
            }

            return await Task.FromResult(default(ITraktUserCustomListItemsRemovePostResponse));
        }
    }
}
