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
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserCustomListsReorderPostResponse)).ConfigureAwait(false);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktUserCustomListsReorderPostResponse userCustomListsReorderPostResponse = new TraktUserCustomListsReorderPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_CUSTOM_LISTS_REORDER_POST_RESPONSE_PROPERTY_NAME_UPDATED:
                            userCustomListsReorderPostResponse.Updated = await jsonReader.ReadAsInt32Async(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.USER_CUSTOM_LISTS_REORDER_POST_RESPONSE_PROPERTY_NAME_SKIPPED_IDS:
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
