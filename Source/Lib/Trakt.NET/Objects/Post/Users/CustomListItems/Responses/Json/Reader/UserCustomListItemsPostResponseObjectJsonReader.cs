namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostResponseObjectJsonReader : AObjectJsonReader<ITraktUserCustomListItemsPostResponse>
    {
        public override async Task<ITraktUserCustomListItemsPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserCustomListItemsPostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var responseGroupReader = new UserCustomListItemsPostResponseGroupObjectJsonReader();
                var responseNotFoundGroupReader = new UserCustomListItemsPostResponseNotFoundGroupObjectJsonReader();
                ITraktUserCustomListItemsPostResponse customListItemsPostResponse = new TraktUserCustomListItemsPostResponse();

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
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostResponse;
            }

            return await Task.FromResult(default(ITraktUserCustomListItemsPostResponse));
        }
    }
}
