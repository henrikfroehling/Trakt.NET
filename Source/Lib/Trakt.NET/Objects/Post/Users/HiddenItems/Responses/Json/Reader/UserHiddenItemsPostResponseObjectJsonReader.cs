namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostResponseObjectJsonReader : AObjectJsonReader<ITraktUserHiddenItemsPostResponse>
    {
        public override async Task<ITraktUserHiddenItemsPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var responseGroupReader = new UserHiddenItemsPostResponseGroupObjectJsonReader();
                var responseNotFoundGroupReader = new UserHiddenItemsPostResponseNotFoundGroupObjectJsonReader();
                ITraktUserHiddenItemsPostResponse hiddenItemsPostResponse = new TraktUserHiddenItemsPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_ADDED:
                            hiddenItemsPostResponse.Added = await responseGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_NOT_FOUND:
                            hiddenItemsPostResponse.NotFound = await responseNotFoundGroupReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return hiddenItemsPostResponse;
            }

            return await Task.FromResult(default(ITraktUserHiddenItemsPostResponse));
        }
    }
}
