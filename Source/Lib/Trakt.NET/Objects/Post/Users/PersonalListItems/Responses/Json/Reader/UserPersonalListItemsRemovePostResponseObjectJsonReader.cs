namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListItemsRemovePostResponseObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListItemsRemovePostResponse>
    {
        public override async Task<ITraktUserPersonalListItemsRemovePostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var responseGroupReader = new UserPersonalListItemsPostResponseGroupObjectJsonReader();
                var responseNotFoundGroupReader = new UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader();
                ITraktUserPersonalListItemsRemovePostResponse customListItemsRemovePostResponse = new TraktUserPersonalListItemsRemovePostResponse();

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

            return await Task.FromResult(default(ITraktUserPersonalListItemsRemovePostResponse));
        }
    }
}
