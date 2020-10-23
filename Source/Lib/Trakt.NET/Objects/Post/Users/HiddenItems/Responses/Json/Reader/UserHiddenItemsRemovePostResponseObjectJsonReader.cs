namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsRemovePostResponseObjectJsonReader : AObjectJsonReader<ITraktUserHiddenItemsRemovePostResponse>
    {
        public override async Task<ITraktUserHiddenItemsRemovePostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var responseGroupReader = new UserHiddenItemsPostResponseGroupObjectJsonReader();
                var responseNotFoundGroupReader = new UserHiddenItemsPostResponseNotFoundGroupObjectJsonReader();
                ITraktUserHiddenItemsRemovePostResponse hiddenItemsRemovePostResponse = new TraktUserHiddenItemsRemovePostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_DELETED:
                            hiddenItemsRemovePostResponse.Deleted = await responseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOT_FOUND:
                            hiddenItemsRemovePostResponse.NotFound = await responseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return hiddenItemsRemovePostResponse;
            }

            return await Task.FromResult(default(ITraktUserHiddenItemsRemovePostResponse));
        }
    }
}
