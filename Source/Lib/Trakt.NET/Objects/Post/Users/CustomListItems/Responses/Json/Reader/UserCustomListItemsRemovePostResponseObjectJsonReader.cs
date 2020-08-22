namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsRemovePostResponseObjectJsonReader : AObjectJsonReader<ITraktUserCustomListItemsRemovePostResponse>
    {
        public override async Task<ITraktUserCustomListItemsRemovePostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

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
                        case JsonProperties.PROPERTY_NAME_DELETED:
                            customListItemsRemovePostResponse.Deleted = await responseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOT_FOUND:
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
