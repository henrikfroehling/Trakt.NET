namespace TraktNet.Objects.Post.Users.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListsReorderPostResponseObjectJsonReader : AObjectJsonReader<ITraktUserCustomListsReorderPostResponse>
    {
        public override async Task<ITraktUserCustomListsReorderPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserCustomListsReorderPostResponse userCustomListsReorderPostResponse = new TraktUserCustomListsReorderPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_UPDATED:
                            userCustomListsReorderPostResponse.Updated = await jsonReader.ReadAsInt32Async(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_SKIPPED_IDS:
                            userCustomListsReorderPostResponse.SkippedIds = await JsonReaderHelper.ReadUnsignedIntegerArrayAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return userCustomListsReorderPostResponse;
            }

            return await Task.FromResult(default(ITraktUserCustomListsReorderPostResponse)).ConfigureAwait(false);
        }
    }
}
